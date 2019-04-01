using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using WebstoreConsole.Entities;

namespace Web1
{
    

    public class Page1Model : PageModel
    {
        public ProductService PS;


        public void OnGet()
        {

            List<Products> pr = GetProducts();
            int products = GetProducts().Count;
            int x = 0; 
            foreach(Products p in pr) {
                while (products > x)
                {
                    ViewData["ClothingID "] = pr[x].ClothingID;
                    ViewData["name "] = pr[x].name;
                    ViewData["Description "] = pr[x].Description;
                    ViewData["Price "] = pr[x].price;
                    ViewData["status"] = pr[x].status;
                    x++;
                }
                }
                
        }

        private List<Products> GetProducts()
        {
            var context = new EfstoreContext();
             PS  = new ProductService(context);
              List<Products> pd =       PS.GetProducts();

           return pd;

        }

        private List<Products> GetProduct(int i)
        {
            var context = new EfstoreContext();
            PS = new ProductService(context);
            List<Products> pd = PS.GetProductById(i);

            return pd;

        }


    }
}