using Datalayer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstoreConsole.Entities;

namespace WebstoreConsole
{
    class Program
    {
        private readonly EfstoreContext _ctx;
        
        static void Main(string[] args)
        {

            normal1 n = new normal1();
             List<Products>  d = n.one();





        }
    }
}



    