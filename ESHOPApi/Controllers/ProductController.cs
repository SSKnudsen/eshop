using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalayer;
using Datalayer.Entities;
using Microsoft.AspNetCore.Mvc;
using WebstoreConsole.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESHOPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EfstoreContext _context;

        public ProductController(EfstoreContext context)
        {
            _context = context;

            if (_context.prod.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.prod.Add( new Products { name = "Adidas A1", Description ="Test", price= 100, status="Instock"  });

                _context.SaveChanges();
            }
        }
    }
}