using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using WebstoreConsole.Entities;

namespace Web1.Pages
{
    public class UserinformationModel : PageModel
    {

        public UserinformationService US;

        public void OnGet()
        {
            List< Userinformation> pr = Getuserinf();
            int products = Getuserinf().Count;
            int x = 0;
            foreach (Userinformation p in pr)
            {
                while (products > x)
                {
                    //ViewData["ClothingID "] = pr[x].ClothingID;
                    ViewData["name "] = pr[x].fullname;
                    ViewData["Address "] = pr[x].Address;
                    ViewData["city "] = pr[x].city;
                    ViewData["Gender "] = pr[x].gender;
                    ViewData["Date"] = pr[x].dateofbirth;
                    ViewData["email "] = pr[x].email;
                    ViewData["Payment"] = pr[x].paymentO;

                    x++;
                }


            }
        }


        private List<Userinformation> Getuserinf()
        {
            var context = new EfstoreContext();
            US = new UserinformationService(context);
            List<Userinformation> pd = US.GetUserinformation();

            return pd;

        }

        private Userinformation GetUserInfOne(int i)
        {
            var context = new EfstoreContext();
            US = new UserinformationService(context);
            Userinformation pd = US.GetuserinfById(i);

            return pd;

        }



    }
}