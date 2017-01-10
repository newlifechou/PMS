﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocGenerator;
using gn = DocGenerator.DocModels;

namespace DocGeneratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainGenerator = new GeneralGenerator();
            TestProdct(mainGenerator);
            Console.Read();
        }

        private static void TestProdct(GeneralGenerator mainGenerator)
        {
            IDoc<gn.MaterialOrder> generator = new GeneratorMaterialOrder();
            var model = new gn.MaterialOrder();
            model.ID = Guid.NewGuid();
            model.CreateTime = DateTime.Now;
            model.Creator = "leon.chiu";
            model.State = 1;
            model.Supplier = "PMS-Chengdu Casting Division";
            model.SupplierAbbr = "SJ";
            model.SupplierReceiver = "Mr. Wang";
            model.SupplierEmail = "sj_materials@163.com";
            model.SupplierAddress = "Chengdu,Sichuan CHINA";
            model.OrderPO = DateTime.Now.ToString("yyMMdd") + "_" + model.SupplierAbbr;
            model.Remark = "PMI to provide:lalalalalalalalala";

            for (int i = 0; i < 3; i++)
            {
                var modelItem = new gn.MaterialOrderItem()
                {
                    ID = Guid.NewGuid(),
                    CreateTime = DateTime.Now,
                    Creator = "leon.chiu",
                    State = 1,
                    Composition = "Ge20As35Se45",
                    Purity = "99.995%",
                    Description = "",
                    ProvideRawMaterial = "",
                    DeliveryDate = DateTime.Now.AddDays(10),
                    UnitPrice = 2300,
                    Weight = 1.6
                };
                model.MaterialOrders.Add(modelItem);
            }

            for (int i = 0; i < 100; i++)
            {

                mainGenerator.Generate<gn.MaterialOrder>(generator, model, nameof(DocTemplateEnum.MaterialOrder), "MO" + i.ToString());
            }
            Console.WriteLine("文档在:" + mainGenerator.TargetFolder);
        }
    }
}
