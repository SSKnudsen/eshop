using Datalayer;
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
        public ProductService prod1;



        [SetUp]
        public void Setup()
        {
            



        }

        [Test]
        public void DBContexttestProdinf()
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


        [Test]
        public void DBContexttestProd()
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