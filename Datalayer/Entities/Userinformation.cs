using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebstoreConsole.Entities
{
   public class Userinformation
    {
        public Int32 id { get; set; }
        public string fullname { get; set; }
        public DateTime dateofbirth { get; set; }
        public string Address { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public int CountryCode { get; set; }
        public string email { get; set; }
        public string paymentO { get; set; }



    }
}
