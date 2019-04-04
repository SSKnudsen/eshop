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
        public ShopbasketService SB1;


        [SetUp]
        public void Setup()
        {




        }



        /// <summary>
        /// Tester Servicelaget på products
        /// </summary>
        [Test]
        public void ServiceLayer_Prod_INF_Test()
        {
            var options = new DbContextOptionsBuilder<EfstoreContext>()
                .UseInMemoryDatabase(databaseName: "WebstoreDB").Options;

            using (var op = new EfstoreContext(options))
            {
                
                Productinfo PI = new Productinfo();
               // PI.productinfoID = 1;
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

        /// <summary>
        /// Tester Servicelaget Shopping Basket
        /// </summary>
        [Test]
        public void ServiceLayer_ShopBasket_INF_Test()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EfstoreContext>()
                .UseInMemoryDatabase(databaseName: "WebstoreDB").Options;
            //ACT
            using (var op = new EfstoreContext(options))
            {

                Shopbasket sb = new Shopbasket();
                sb.Product_id = 1;
                sb.Name = "Adiddas";
                sb.OrderLines = "4";
                sb.Quantity = 4;

                var PS = new ShopbasketService(op);
                   PS.Add(sb);

                //Assert
                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new EfstoreContext(options))
                {
                    Assert.AreEqual(1, context.shopbaskets.Count());
                   // Assert.AreEqual("Adiddas", context.shopbaskets.Single().Name);
                    Assert.AreEqual("4", context.shopbaskets.Single().OrderLines);
                }

                {


                }

            }


        }




        /// <summary>
        /// Tester Servicelayer på userinformation
        /// </summary>
        [Test]
        public void ServiceLayer_User_INF_Test()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EfstoreContext>()
                .UseInMemoryDatabase(databaseName: "WebstoreDB").Options;
            //ACT
            using (var op = new EfstoreContext(options))
            {

                 userinformation sb = new userinformation();
                sb.id = 1;
                sb.fullname = "Hansen";
                sb.Address = "Hansenvej 1";
                sb.dateofbirth = DateTime.Now;
                sb.CountryCode = 1100;
                sb.city = "hansenberg";
                sb.gender = "M";
                sb.paymentO = "MasterCard";

                var PS = new UserinformationService(op);
                PS.Add(sb);

                //Assert
                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new EfstoreContext(options))
                {
                    Assert.AreEqual(1, context.userinformtation.Count());
                    Assert.AreEqual("hansenberg", context.userinformtation.Single().city);
                    Assert.AreNotEqual("ansenberg", context.userinformtation.Single().city);
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
        //[Test]
        //public void DB_Context_test_Prodinf()
        //{
        //    var context = new EfstoreContext();
        //    var productstestdata = context.Prodinfo
        //                                      .Where(s => s.productinfoID == 2)
        //                                      .ToList();
        //    List<Productinfo> pd = productstestdata.ToList<Productinfo>();

        //    foreach (Productinfo m in pd)
        //    {

        //        Assert.NotNull(m.productinfoID);
        //        Assert.Positive(m.productinfoID);
        //        // Assert.Negative(m.ClothingID);
        //        //  Assert.AreEqual(10, m.size );
        //        Assert.AreNotEqual(m.size, 1);


        //    }




        //}

        /// <summary>
        /// Test af products
        /// </summary>
        //[Test]
        //public void DB_Context_testProd()
        //{

        //    var context = new EfstoreContext();
        //    var productstestdata = context.Products
        //                                  .Where(s => s.ClothingID == 2)
        //                                  .ToList();
        //    List<Products> pd = productstestdata.ToList<Products>();

        //    foreach (Products m in pd)
        //    {
        //        int ms = m.ClothingID;
        //        Assert.NotNull(m.ClothingID);
        //        Assert.Positive(m.ClothingID);
        //        // Assert.Negative(m.ClothingID);
        //        Assert.AreEqual(m.ClothingID, 2);



        //    }


        //}
    }
}