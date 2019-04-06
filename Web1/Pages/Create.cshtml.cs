using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public void OnGet()
        {

                



         }

        public void onPost()
        {
            id = 1;




        }


    }
}
