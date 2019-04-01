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
        public ShopbasketService SS;


        public void OnGet()
        {
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