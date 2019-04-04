using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer;
using StackExchange.Profiling;
using WebstoreConsole.Entities;

namespace Web1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EfstoreContext _db;

        public IndexModel(EfstoreContext ctx)
        {
            //ctx.Database.EnsureCreated();
            _db = ctx;

        }

        [BindProperty]
        public List<Products> prod { get; set; }
        public ProductService PS;

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



        public void onPost()
        {   

        }

        
        public void OnGet()
        {
            prod = _db.prod.ToList();



            using (MiniProfiler.Current.Step("InitUser"))
            {
                List<Products> pr = GetProducts();
                int products = GetProducts().Count;
                
                foreach (Products p in pr)
                {

                    //ViewData["ClothingID "] = p.ClothingID;
                    //ViewData["name "] = p.name;
                    //ViewData["Description "] = p.Description;
                    //ViewData["Price "] = p.price;
                    //ViewData["status"] = p.status;


                     id = p.ClothingID;
                     name = p.name;
                     desc = p.Description;
                     pric = p.price;
                     stat = p.status;

                    ViewData["ClothingID "] = id;
                    ViewData["name "] = name;
                    ViewData["Description "] = desc;
                    ViewData["Price "] = pric;
                    ViewData["status"] = stat;


                }

            }
        }
       
        public List<Products> GetProducts()
        {
            var context = new EfstoreContext();
            PS = new ProductService(context);
            List<Products> pd = PS.GetProducts();

            return pd;

        }
        
        private IQueryable<Products> GetProduct(int i)
        {
            var context = new EfstoreContext();
            PS = new ProductService(context);
          IQueryable<Products> pd = PS.GetProductById(i);

            return pd;

        }


    }
}
