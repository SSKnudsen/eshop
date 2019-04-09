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

        

        public userinformation one()
        {
            EfstoreContext efx = new EfstoreContext();
           // UserinformationService ser1 = new UserinformationService(efx);


            userinformation sb = new userinformation();
            ////sb.id = 1;
            //sb.fullname = "Hansen";
            //sb.Address = "Hansenvej 1";
            //sb.dateofbirth = DateTime.Now;
            //sb.CountryCode = 1100;
            //sb.city = "hansenberg";
            //sb.gender = "M";
            //sb.paymentO = "MasterCard";
            //ser1.Add(sb);

            ShopbasketService sb1 = new ShopbasketService(efx);
            sb1.Delete(0);

            return sb;


            
            //Shopbasket sb = new Shopbasket();
            

            //IQueryable<Products> ps =       prod1.GetProductById(2);



            //var context = new EfstoreContext();
            //var studentsWithSameName = context.Products
            //                                  .Where(s => s.ClothingID == 2)
            //                                  .ToList();

            //List<Products> pd = studentsWithSameName.ToList<Products>();


        }
    }




}
    

