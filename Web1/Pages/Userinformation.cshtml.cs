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
        private readonly EfstoreContext _db;

        public UserinformationModel(EfstoreContext ctx)
        {
            //ctx.Database.EnsureCreated();
            _db = ctx;

        }


        [BindProperty]
        public List<userinformation> Userinf  { get; set; }
        public UserinformationService US;

        [BindProperty(SupportsGet = true)]
        public Int32 id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string fullname { get; set; }
        [BindProperty(SupportsGet = true)]  
        public DateTime dateofbirth { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Address { get; set; }
        [BindProperty(SupportsGet = true)]
        public string gender { get; set; }
        [BindProperty(SupportsGet = true)]
        public string city { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CountryCode { get; set; }
        [BindProperty(SupportsGet = true)]
        public string email { get; set; }
        [BindProperty(SupportsGet = true)]
        public string paymentO { get; set; }

        public void OnGet()
        {

            Userinf = _db.user.ToList();

            List< userinformation> pr = Getuserinf();
            int products = Getuserinf().Count;
            int x = 0;
            foreach (userinformation p in pr)
            {
                while (products > x)
                {
                    ViewData["id "] = p.id;
                    ViewData["fullname "] = pr[x].fullname;
                    ViewData["Address "] = pr[x].Address;
                    ViewData["city "] = pr[x].city;
                    ViewData["gender "] = pr[x].gender;
                    ViewData["Date"] = pr[x].dateofbirth;
                    ViewData["email "] = pr[x].email;
                    ViewData["Payment"] = pr[x].paymentO;

                    x++;
                }


            }
        }


        private List<userinformation> Getuserinf()
        {
          //  _db.user.ToList();


            var context = new EfstoreContext();
            US = new UserinformationService(context);
            List<userinformation> pd = US.GetUserinformation();

            return pd;

        }

        private userinformation GetUserInfOne(int i)
        {
            var context = new EfstoreContext();
            US = new UserinformationService(context);
            userinformation pd = US.GetuserinfById(i);

            return pd;

        }



    }
}