﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Xceed.Words.NET;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImportTargetPhotoIntoReport
{
    class PhotoProcess
    {

        private List<string> DocxFiles;
        private List<string> JpegFiles;

        public bool HasWaterPrint { get; set; }
        public bool IsOpenOutputDirectory { get; set; }

        public PhotoProcess()
        {
            DocxFiles = new List<string>();
            JpegFiles = new List<string>();
            targetFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            HasWaterPrint = true;
            IsOpenOutputDirectory = true;
        }

        public event EventHandler<PhotoProcessEventArgs> ChangeStatus;
        /// <summary>
        /// 加载所有的docx，jpeg文件到处理列表
        /// </summary>
        /// <param name="docxFolder"></param>
        /// <param name="jpegFolder"></param>
        public void LoadFile(string docxFolder, string jpegFolder)
        {
            if (!Directory.Exists(docxFolder) || !Directory.Exists(jpegFolder))
            {
                throw new DirectoryNotFoundException("没有找到docx或者jpeg文件夹");
            }
            else
            {
                DocxFiles = GetDocxFullNames(docxFolder);
                JpegFiles = GetJPEGFullNames(jpegFolder);
                TriggerEvent("文件载入完毕");

                TriggerEvent($"图片文件夹中有{DocxFiles.Count}个docx文件");

                TriggerEvent($"图片文件夹中有{JpegFiles.Count}个jpg文件");


                //在docxfolder中创建targetfolder
                targetFolder = Path.Combine(docxFolder, "追加照片后的报告");
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }
                TriggerEvent($"目标文件夹创建完毕{targetFolder}");

            }
        }

        private string targetFolder;

        private void TriggerEvent(string msg)
        {
            ChangeStatus?.Invoke(this, new PhotoProcessEventArgs() { Message = msg });
        }

        public void Process()
        {

            foreach (var docx in DocxFiles)
            {
                if (!File.Exists(docx))
                {
                    TriggerEvent($"没有找到对应的{Path.GetFileNameWithoutExtension(docx)}文件");
                    continue;
                }

                string product_id = GetProductIDFromDocxName(docx).Replace('_', '-');
                if (product_id != "")
                {
                    bool hasFind = false;
                    //查找180608-AB-1-R
                    foreach (var img in JpegFiles)
                    {
                        if (img.Contains($"{product_id}-R"))
                        {
                            AppendJPGIntoDocx(docx, img, targetFolder);
                            hasFind = true;
                            break;
                        }
                    }
                    //如果没有找到，继续查找180608-AB-1
                    if (!hasFind)
                    {
                        foreach (var img in JpegFiles)
                        {
                            if (img.Contains($"{product_id}"))
                            {
                                AppendJPGIntoDocx(docx, img, targetFolder);
                                hasFind = true;
                                break;
                            }
                        }
                    }

                    if (!hasFind)
                    {
                        TriggerEvent($"{Path.GetFileNameWithoutExtension(docx)}没有找到对应的jpg图片");
                    }

                }
                else
                {
                    TriggerEvent($"{Path.GetFileNameWithoutExtension(docx)}产品ID解析有问题");
                }

            }

            if (IsOpenOutputDirectory)
            {
                System.Diagnostics.Process.Start(targetFolder);
            }
        }

        /// <summary>
        /// 追加图片到文档结尾并另存
        /// </summary>
        /// <param name="docxFile"></param>
        /// <param name="jpegFile"></param>
        /// <param name="targetFolder"></param>
        public void AppendJPGIntoDocx(string docxFile, string jpegFile, string targetFolder)
        {
            if (File.Exists(docxFile) && File.Exists(jpegFile))
            {
                DocX doc = DocX.Load(docxFile);

                doc.InsertSectionPageBreak();
                doc.InsertParagraph("CSCAN IMAGE", false, new Formatting() { Size = 20 }).Alignment = Alignment.center;


                Xceed.Words.NET.Image img;
                //图片追加处理
                string img_file = jpegFile;
                if (HasWaterPrint)
                {
                    img_file = AddWaterPrintToImage(jpegFile);
                }
                img = doc.AddImage(img_file);

                var pic = img.CreatePicture();
                doc.InsertParagraph().AppendPicture(pic).Alignment = Alignment.center;




                string targetFile = Path.GetFileName(docxFile);
                string newDocxFile = Path.Combine(targetFolder, targetFile);
                doc.SaveAs(newDocxFile);
            }
            else
            {
                throw new FileNotFoundException("docx文档和jpeg文档没有找到");
            }
        }

        /// <summary>
        /// 获取文档名列表
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public List<string> GetDocxFullNames(string folderPath)
        {
            return GetFileInFolder(folderPath, "*.docx");
        }
        /// <summary>
        /// 获取图片名列表
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public List<string> GetJPEGFullNames(string folderPath)
        {
            return GetFileInFolder(folderPath, "*.jpg");

        }
        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        private List<string> GetFileInFolder(string folderPath, string condition)
        {
            if (!Directory.Exists(folderPath))
            {
                return null;
            }
            var files = Directory.GetFiles(folderPath, condition, SearchOption.TopDirectoryOnly);
            return files.ToList();
        }
        /// <summary>
        /// 从docx文件名获取id
        /// </summary>
        /// <param name="docxName"></param>
        /// <returns></returns>
        public string GetProductIDFromDocxName(string docxName)
        {
            return GetProductIDFromFileName(docxName, @"\d{6}_\w{2}_\d{1}");
        }
        /// <summary>
        /// 从jpg文件名中获取id
        /// </summary>
        /// <param name="docxName"></param>
        /// <returns></returns>
        public string GetProductIDFromJPEGName(string jpgName)
        {
            return GetProductIDFromFileName(jpgName, @"\d{6}-\w{2}-\d{1}");
        }


        private string GetProductIDFromFileName(string fileName, string pattern)
        {
            if (string.IsNullOrEmpty(fileName) && string.IsNullOrEmpty(pattern))
            {
                return string.Empty;
            }

            var match = Regex.Match(fileName, pattern);

            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 在图片左上角插入文件名
        /// </summary>
        /// <param name="jpgName"></param>
        /// <returns></returns>
        private string AddWaterPrintToImage(string jpgName)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(jpgName);
            Graphics g = Graphics.FromImage(img);
            string product_id = Path.GetFileNameWithoutExtension(jpgName);
            System.Drawing.Font font = new System.Drawing.Font("Arial", 15);
            g.DrawString(product_id, font, Brushes.Orange, 10, 10);
            MemoryStream ms = new MemoryStream();
            string tmp = Path.Combine(Environment.CurrentDirectory, "tmp", "tmp.jpg");
            img.Save(tmp);
            g.Dispose();
            return tmp;
        }


    }
}