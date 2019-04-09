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
    public class CreateModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string desc { get; set; }

        [BindProperty(SupportsGet = true)]
        public int pric { get; set; }

        [BindProperty(SupportsGet = true)]
        public string stat { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SorbyBrand { get; set; }
        public string Message { get; set; } = "Initial Request";
        public void OnGet()
        {





        }



        public void OnPostView(int id)
        {

            var context = new EfstoreContext();
            ProductService PS = new ProductService(context);
            Products smallProd = new Products();

            

            smallProd.ClothingID = 35;
            smallProd.Description = desc;
            smallProd.price = pric;
            smallProd.status = "Instock";
            smallProd.name = name;
            PS.Add(smallProd);






        }



    }
}
