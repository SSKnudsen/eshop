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

            UserinformationService ser1 = new UserinformationService(ctx);


            Userinformation sb = new Userinformation();
            //sb.id = 1;
            sb.fullname = "Hansen";
            sb.Address = "Hansenvej 1";
            sb.dateofbirth = DateTime.Now;
            sb.CountryCode = 1100;
            sb.city = "hansenberg";
            sb.gender = "M";
            sb.paymentO = "MasterCard";

            
            ser1.Add(sb);



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
    

