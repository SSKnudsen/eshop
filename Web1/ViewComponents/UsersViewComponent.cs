using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.ViewComponents
{
    public class UsersViewComponent : ViewComponent
    {
        private ProductService _prodService;
        public UsersViewComponent(ProductService userService)
        {
            _prodService = userService;
        }
        public IViewComponentResult InvokeAsync()
        {
            var users = _prodService.GetProducts();
            return View(users);
        }
    }
}