using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Datalayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using WebstoreConsole.Datalayer;

namespace Web1.Pages
{
    public class CheckoutModel : PageModel
    {

        public OrderService OS;
        [Required]
        [BindProperty(SupportsGet = true)]
        public int ClothingID { get; set; }


        [BindProperty(SupportsGet = true)]
        [Required]
        [MinLength(2)]
        public string fullname { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "Error1 ")]
        public string Address { get; set; }


        [BindProperty(SupportsGet = true)]
        [Required]
        public string Email { get; set; }


        [BindProperty(SupportsGet = true)]
        [Required]
        public int paymentO { get; set; }










        public void OnGet()
        {

        }
        public void OnPost(string fullname, string Address,String Email, string paymentO)
        {
            var context = new EfstoreContext();
            OS = new OrderService(context);
            Orders ord = new Orders();

            // ord.OrderId = 34;
            
           
            //SS.Add(sb);
        }
    }
}