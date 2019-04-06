using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebstoreConsole.Entities
{
   public class userinformation
    {
        



        
        public Int32 id { get; set; }
        [BindProperty]
        [StringLength(50, ErrorMessage = "El campo {0} no puede tener mas de 50 caracteres")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string fullname { get; set; }
        public DateTime dateofbirth { get; set; }
        [BindProperty]
        [Required]
        public string Address { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        [BindProperty]
        [Required]
        public int CountryCode { get; set; }
        public string email { get; set; }
        [Required]
        public string paymentO { get; set; }



    }
}
