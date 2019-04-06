using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer;
using StackExchange.Profiling;
using WebstoreConsole.Entities;

namespace Web1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EfstoreContext _db;

        private readonly IMemoryCache _cache;
        public IndexModel(EfstoreContext ctx, IMemoryCache cache)
        {
            _cache = cache;
            //ctx.Database.EnsureCreated();
            _db = ctx;

        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }






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

        [BindProperty(SupportsGet = true)]
        public string SorbyBrand { get; set; }

        public void onPost()
        {
                    }

        
        public void OnGet()
        {
           



            prod = _db.prod.ToList();


            foreach (Products p in prod) { 

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            Response.Cookies.Append("MyCookie", p.name + p.price, cookieOptions);

            }

            using (MiniProfiler.Current.Step("InitUser"))
            {
                string one = "";
                SorbyBrand = one;


                List<Products> pr = GetProducts();
                int products = GetProducts().Count;
                
                foreach (Products p in pr)
                {

                   

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

            var cacheEntry = DateTime.Now;
            _cache.Set<DateTime>("Time", cacheEntry);
            var context = new EfstoreContext();
            PS = new ProductService(context);
            List<Products> pd = PS.GetProducts();
            var myEntry = _cache.Get("myKey");
          //  var myEntry = _cache.Get<DateTime>("myKey");
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
