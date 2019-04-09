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

        [BindProperty]
        public List<Products> prod { get; set; }
        [BindProperty]
        public List<Products> prod2 { get; set; }
        [BindProperty]
        public List<Products> prod3 { get; set; }
        public ProductService PS;
        public ShopbasketService SS;
        public List<Products> final; 



        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string sortOrder { get; set; }

        [BindProperty(SupportsGet = true)]
       public string desc { get; set; }

        [BindProperty(SupportsGet = true)]
        public int pric { get; set; }

        [BindProperty(SupportsGet = true)]
        public string stat { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SorbyBrand { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Color { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Size { get; set; }


        [BindProperty(SupportsGet = true)]
        public string Brand { get; set; }
   


        public string Message { get; set; } = "Initial Request";



        public void OnPostSearchDSC()
        {
            prod = _db.prod.ToList();

                var context = new EfstoreContext();
                PS = new ProductService(context);

                List<Products> PS1 = PS.GetProducts();


               final = PS1.OrderByDescending(s => s.price).ToList<Products>();
           

            prod2 = final;

        }

        public void OnPostSearchASC()
        {
            prod = _db.prod.ToList();

            var context = new EfstoreContext();
            PS = new ProductService(context);

            List<Products> PS1 = PS.GetProducts();


            var orderByResult = from s in PS1
                                orderby s.price
                                select s;

            final =   orderByResult.ToList<Products>();


            prod2 = final;

        }

        public void OnPostSearch(string SearchString)
        {
            prod = _db.prod.ToList();
            

            if (!String.IsNullOrEmpty(SearchString))
            {

                var context = new EfstoreContext();
                PS = new ProductService(context);


                List<Products> PS1 = PS.GetProducts();

                final = PS1.Where(s => s.Description.Contains(SearchString)).ToList<Products>();           }

                 prod2 = final;
          
            
        }


        public void OnPostSearchColor(string SearchString)
        {
            prod = _db.prod.ToList();


            if (!String.IsNullOrEmpty(SearchString))
            {

                var context = new EfstoreContext();
                PS = new ProductService(context);

                List<Products> PS1 = PS.GetProducts();


                final = PS1.Where(s => s.Color.Contains(SearchString)).ToList<Products>();
            }

            prod2 = final;


        }




        public void OnPostSearchBrand(string SearchString)
        {
            prod = _db.prod.ToList();


            if (!String.IsNullOrEmpty(SearchString))
            {

                var context = new EfstoreContext();
                PS = new ProductService(context);

                List<Products> PS1 = PS.GetProducts();

                final =  PS1.Where(s => s.Brand.Contains(SearchString)).ToList<Products>();
                prod2 = final;
            }

          


        }






        public void OnPostBasket(int id)
        {


            prod = _db.prod.ToList();


            var context = new EfstoreContext();
            SS = new ShopbasketService(context);

            Shopbasket sb = new Shopbasket();
            foreach (Products p in prod)
            {
                sb.ClothingID = p.ClothingID;
                sb.Name = p.name;
                sb.Quantity = 1;
                sb.OrderLines = "1";
                sb.Product_id = 1;
            }
            SS.Add(sb);
            
        }

        public void OnPostShoppingbasket(int id)
        {



         ///   SS.Add(id);
        }


        public void OnPostRegisterAsync()
        {
            
        }
            





        public  void OnGet(string sortOrder)
        {

            prod = _db.prod.ToList();




            //< a asp - action = "Index" asp - route - sortOrder = "@ViewData["SortBySTAT"]" > @Html.DisplayNameFor(model => model.stat) </ a >

            //    switch (sortOrder)
            //{
            //    case "name_desc":
            //        students = students.OrderByDescending(s => s.LastName);
            //        break;
            //    case "Date":
            //        students = students.OrderBy(s => s.EnrollmentDate);
            //        break;
            //    case "date_desc":
            //        students = students.OrderByDescending(s => s.EnrollmentDate);
            //        break;
            //    default:
            //        students = students.OrderBy(s => s.LastName);
            //        break;
            //}

            ViewData["CurrentFilter"] = sortOrder;
            prod2 = GetProductsSearch(sortOrder);

           
                   
            
            foreach (Products p in prod) { 

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
        Response.Cookies.Append("MyCookie", p.name + p.price, cookieOptions);

            }

            //foreach (Products p in prod)
            //{

            //    var cookieOptions = new CookieOptions
            //    {
            //        Expires = DateTime.Now.AddDays(30)
            //    };
            //    Response.Cookies.Append("MyCookie", p.name + p.price, cookieOptions);

            //}



        }
        //    return View(await students.AsNoTracking().ToListAsync());
        //}
        //ViewData["CurrentFilter"] = searchString;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        students = students.Where(s => s.LastName.Contains(searchString)
        //                               || s.FirstMidName.Contains(searchString));
        //    }





        //    using (MiniProfiler.Current.Step("InitUser"))
        //    {
        //        string one = "";
        //        SorbyBrand = one;


        //        List<Products> pr = GetProducts();
        //        int products = GetProducts().Count;

        //        foreach (Products p in pr)
        //        {



        //             id = p.ClothingID;
        //             name = p.name;
        //             desc = p.Description;
        //             pric = p.price;
        //             stat = p.status;

        //            ViewData["ClothingID "] = id;
        //            ViewData["name "] = name;
        //            ViewData["Description "] = desc;
        //            ViewData["Price "] = pric;
        //            ViewData["status"] = stat;


        //        }

        //    }
        //}

        public  List<Products> GetProductsSearch(string searchString)
        {
            var context = new EfstoreContext();
            PS = new ProductService(context);
            List<Products> pd = PS.GetProducts();
            List<Products> pd2;
            var Products = from s in context.prod
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Products = Products.Where(s => s.Description.Contains(searchString));
                                     
            }

            ViewData["CurrentFilter"] = searchString;
            //prod = _db.prod.ToList();

            //IEnumerable<Products> prod2 = prod.OrderByDescending(s => s.price);

            return Products.ToList<Products>();
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
