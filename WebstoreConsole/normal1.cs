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

        

        public List<Products> one()
        {
            EfstoreContext ctx = new EfstoreContext();
            ProductService prod1  = new ProductService(ctx);
        List<Products> ps =       prod1.GetProductById(2);



            //var context = new EfstoreContext();
            //var studentsWithSameName = context.Products
            //                                  .Where(s => s.ClothingID == 2)
            //                                  .ToList();

            //List<Products> pd = studentsWithSameName.ToList<Products>();
            return ps;

        }
    }




}
    

