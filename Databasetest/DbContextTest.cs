using Datalayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using WebstoreConsole.Entities;


namespace Tests
{
    public class Tests
    {
        public ProductService PS;



        [SetUp]
        public void Setup()
        {




        }

        [Test]
        public void ServiceLayer_Prod_INF_Test()
        {
            var options = new DbContextOptionsBuilder<EfstoreContext>()
                .UseInMemoryDatabase(databaseName: "WebstoreDB").Options;

            using (var op = new EfstoreContext(options))
            {
                
                Productinfo PI = new Productinfo();
                PI.productinfoID = 1;
                PI.Brand = "Adiddas";
                PI.Color = "Black";
                PI.size = "L";
                var PS = new ProductInfoService(op);
                PS.Add(PI);
                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new EfstoreContext(options))
                {
                    Assert.AreEqual(1, context.Prodinfo.Count());
                    Assert.AreEqual(1, context.Prodinfo.Single().productinfoID);
                    Assert.AreEqual("Black", context.Prodinfo.Single().Color);
                }

                {


                }

            }


        }


        [Test]
        public void ServiceLayer_Prod_Test()
        {

            //Arrange
            var options = new DbContextOptionsBuilder<EfstoreContext>()
                .UseInMemoryDatabase(databaseName: "WebstoreDB").Options;

            //ACT
            using (var op = new EfstoreContext(options))
            {

                Products p = new Products();
                p.ClothingID = 1;
                p.name = "Adiddas A1 Running";
                p.Description = "Running Shoe with special Gel";
                p.price = 300;
                p.status = "Instock";
                var op1 = new ProductService(op);
                op1.Add(p);

                //Assert
                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new EfstoreContext(options))
                {
                  //  Assert.AreEqual(1, context.Products.Count());
                   Assert.AreEqual(1, context.Products.Single().ClothingID);
                    Assert.AreNotEqual(0, context.Products.Single().ClothingID);
                }

                {


                }

            }

        }




        /// <summary>
        /// Test af prodinfo
        /// </summary>
        [Test]
        public void DB_Context_test_Prodinf()
        {
            var context = new EfstoreContext();
            var productstestdata = context.Prodinfo
                                              .Where(s => s.productinfoID == 2)
                                              .ToList();
            List<Productinfo> pd = productstestdata.ToList<Productinfo>();

            foreach (Productinfo m in pd)
            {

                Assert.NotNull(m.productinfoID);
                Assert.Positive(m.productinfoID);
                // Assert.Negative(m.ClothingID);
                //  Assert.AreEqual(10, m.size );
                Assert.AreNotEqual(m.size, 1);


            }




        }

        /// <summary>
        /// Test af products
        /// </summary>
        [Test]
        public void DB_Context_testProd()
        {

            var context = new EfstoreContext();
            var productstestdata = context.Products
                                          .Where(s => s.ClothingID == 2)
                                          .ToList();
            List<Products> pd = productstestdata.ToList<Products>();

            foreach (Products m in pd)
            {
                int ms = m.ClothingID;
                Assert.NotNull(m.ClothingID);
                Assert.Positive(m.ClothingID);
                // Assert.Negative(m.ClothingID);
                Assert.AreEqual(m.ClothingID, 2);



            }


        }
    }
}