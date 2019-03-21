using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebstoreConsole.Datalayer
{
  public class Orders
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string status { get; set; }
        public DateTime dateoforder { get; set; }




    }
}
