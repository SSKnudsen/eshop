using Datalayer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstoreConsole.Entities;

namespace WebstoreConsole
{
    public class normal1
    {

        private readonly EfstoreContext _ctx;

        public ProductService prod1;

        public List<Products> one()
        {


            Products ps = new Products();

           //IEnumerable<Products> p = prod1.GetProducts();

            var context = new EfstoreContext();
            var studentsWithSameName = context.Products
                                              .Where(s => s.ClothingID == 2)
                                              .ToList();

            List<Products> pd = studentsWithSameName.ToList<Products>();
            return pd;

        }
    }




}
    

