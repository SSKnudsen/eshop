using NUnit.Framework;
using ServiceLayer;
using System.Collections.Generic;
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

        

        }





        [Test]
        public void ServiceLayerProdTest()
        {
           List<Products> ps1 = PS.GetProductById(2);
            foreach (Products m in ps1)
            {
                Assert.NotNull(m.ClothingID);
                Assert.Negative(m.ClothingID);
      
            }


            }

        [Test]
        public void ServicelayerProdInfTest()
        {
            Assert.Pass();
        }



    }
}