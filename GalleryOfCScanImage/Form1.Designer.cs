﻿namespace GalleryOfCScanImage
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TxtImageFolder = new System.Windows.Forms.TextBox();
            this.BtnSelectImageFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtOutputFolder = new System.Windows.Forms.TextBox();
            this.BtnSelectOutputFolder = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.DtpStart = new System.Windows.Forms.DateTimePicker();
            this.DtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkIsOpen = new System.Windows.Forms.CheckBox();
            this.TxtStatus = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片文件位置";
            // 
            // TxtImageFolder
            // 
            this.TxtImageFolder.Location = new System.Drawing.Point(121, 30);
            this.TxtImageFolder.Name = "TxtImageFolder";
            this.TxtImageFolder.Size = new System.Drawing.Size(461, 25);
            this.TxtImageFolder.TabIndex = 1;
            // 
            // BtnSelectImageFolder
            // 
            this.BtnSelectImageFolder.Location = new System.Drawing.Point(588, 30);
            this.BtnSelectImageFolder.Name = "BtnSelectImageFolder";
            this.BtnSelectImageFolder.Size = new System.Drawing.Size(77, 25);
            this.BtnSelectImageFolder.TabIndex = 2;
            this.BtnSelectImageFolder.Text = "选择";
            this.BtnSelectImageFolder.UseVisualStyleBackColor = true;
            this.BtnSelectImageFolder.Click += new System.EventHandler(this.BtnSelectImageFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "输出文件位置";
            // 
            // TxtOutputFolder
            // 
            this.TxtOutputFolder.Location = new System.Drawing.Point(121, 66);
            this.TxtOutputFolder.Name = "TxtOutputFolder";
            this.TxtOutputFolder.Size = new System.Drawing.Size(461, 25);
            this.TxtOutputFolder.TabIndex = 1;
            // 
            // BtnSelectOutputFolder
            // 
            this.BtnSelectOutputFolder.Location = new System.Drawing.Point(588, 68);
            this.BtnSelectOutputFolder.Name = "BtnSelectOutputFolder";
            this.BtnSelectOutputFolder.Size = new System.Drawing.Size(77, 25);
            this.BtnSelectOutputFolder.TabIndex = 2;
            this.BtnSelectOutputFolder.Text = "选择";
            this.BtnSelectOutputFolder.UseVisualStyleBackColor = true;
            this.BtnSelectOutputFolder.Click += new System.EventHandler(this.BtnSelectOutputFolder_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(569, 166);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(115, 34);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.Text = "开始";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // DtpStart
            // 
            this.DtpStart.Location = new System.Drawing.Point(122, 102);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(200, 25);
            this.DtpStart.TabIndex = 4;
            this.DtpStart.ValueChanged += new System.EventHandler(this.DtpStart_ValueChanged);
            // 
            // DtpEnd
            // 
            this.DtpEnd.Location = new System.Drawing.Point(382, 102);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(200, 25);
            this.DtpEnd.TabIndex = 4;
            this.DtpEnd.ValueChanged += new System.EventHandler(this.DtpEnd_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "绑定时间范围";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtpEnd);
            this.groupBox1.Controls.Add(this.TxtImageFolder);
            this.groupBox1.Controls.Add(this.DtpStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BtnSelectImageFolder);
            this.groupBox1.Controls.Add(this.BtnSelectOutputFolder);
            this.groupBox1.Controls.Add(this.TxtOutputFolder);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 148);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本设置";
            // 
            // ChkIsOpen
            // 
            this.ChkIsOpen.AutoSize = true;
            this.ChkIsOpen.Checked = true;
            this.ChkIsOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkIsOpen.Location = new System.Drawing.Point(453, 175);
            this.ChkIsOpen.Name = "ChkIsOpen";
            this.ChkIsOpen.Size = new System.Drawing.Size(104, 19);
            this.ChkIsOpen.TabIndex = 6;
            this.ChkIsOpen.Text = "生成后打开";
            this.ChkIsOpen.UseVisualStyleBackColor = true;
            // 
            // TxtStatus
            // 
            this.TxtStatus.Location = new System.Drawing.Point(13, 206);
            this.TxtStatus.Multiline = true;
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.ReadOnly = true;
            this.TxtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtStatus.Size = new System.Drawing.Size(671, 139);
            this.TxtStatus.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TSProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(699, 25);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(127, 20);
            this.toolStripStatusLabel1.Text = "前提:连接PMS服务";
            // 
            // TSProgressBar
            // 
            this.TSProgressBar.Name = "TSProgressBar";
            this.TSProgressBar.Size = new System.Drawing.Size(300, 19);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 387);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TxtStatus);
            this.Controls.Add(this.ChkIsOpen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超声图片汇集工具-230mm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtImageFolder;
        private System.Windows.Forms.Button BtnSelectImageFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtOutputFolder;
        private System.Windows.Forms.Button BtnSelectOutputFolder;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.DateTimePicker DtpStart;
        private System.Windows.Forms.DateTimePicker DtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkIsOpen;
        private System.Windows.Forms.TextBox TxtStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar TSProgressBar;
    }
}
