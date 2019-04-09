using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer;
using WebstoreConsole.Entities;

namespace Web1.Pages
{
    public class EditModel : PageModel
    {



        public List<Products> prod { get; set; }
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Description { get; set; }
        [BindProperty(SupportsGet = true)]
        public int price { get; set; }
        [BindProperty(SupportsGet = true)]
        public string status { get; set;  }
            



        private readonly EfstoreContext _db;
        public ProductService PS;

        private readonly IMemoryCache _cache;
        public EditModel(EfstoreContext ctx, IMemoryCache cache)
        {
            _cache = cache;
            //ctx.Database.EnsureCreated();
            _db = ctx;

        }


        public void OnGet()
        {
            List<Products> pr = _db.prod.ToList();

            

            foreach (Products p in pr)
            {



                id = p.ClothingID;
                name = p.name;
                Description = p.Description;
                price = p.price;
                status = p.status;


                ViewData["ClothingID "] = id;
                ViewData["name "] = name;
                ViewData["Description "] =  Description;
                ViewData["Price "] = price;
                ViewData["status"] = status;

            }





        }

        private List<Products> GetProduct(int i)
        {
            var context = new EfstoreContext();
            PS = new ProductService(context);
            List<Products> pd = PS.GetProducts();
                        
            var SelectProduct = context.Products
                                              .Where(s => s.ClothingID == i)
                                              .ToList();
            List<Products> ps = SelectProduct.ToList<Products>();
            return ps;



        }

    }
}