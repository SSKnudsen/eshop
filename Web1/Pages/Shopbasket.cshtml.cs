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
    public class ShopbasketModel : PageModel
    {
        private readonly EfstoreContext _db;

        public ShopbasketModel(EfstoreContext ctx)
        {
            //ctx.Database.EnsureCreated();
            _db = ctx;

        }




        public ShopbasketService SS;

        public List<Shopbasket> SB { get; set; }
        public ProductService PS;


        [BindProperty(SupportsGet = true)]
        public int ClothingID { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Checkout_id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string OrderLines { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Product_id { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Quantity { get; set; }




        public void OnGet()
        {
            SB = _db.Shop.ToList();


            List<Shopbasket> pr = GetProdBaskets();
            int products = GetProdBaskets().Count;
            int x = 0;
            foreach (Shopbasket p in pr)
            {
                while (products > x)
                {
                    //ViewData["ClothingID "] = pr[x].ClothingID;
                    ViewData["name "] = pr[x].Name;
                    ViewData["Description "] = pr[x].Quantity;
                    ViewData["Price "] = pr[x].OrderLines;
                    x++;
                }


            }
        }


        private List<Shopbasket> GetProdBaskets()
        {
            var context = new EfstoreContext();
            SS = new ShopbasketService(context);
            List<Shopbasket> pd = SS.GetShopBasket();

            return pd;

        }

        private List<Shopbasket> GetProdBasket(int i)
        {
            var context = new EfstoreContext();
            SS = new ShopbasketService(context);
            List<Shopbasket> pd = SS.GetShopBasketById(i);

            return pd;

        }


        
    }
}