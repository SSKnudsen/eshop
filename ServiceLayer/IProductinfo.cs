using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
  public  interface IProductinfo
    {

        IQueryable<Productinfo> GetProdinfo();
        IQueryable<Productinfo> GetProductinfoByname(string name);
        Productinfo GetProductinfoById(int Id);
        Productinfo Update(Productinfo updateProducts);
        Productinfo Add(Productinfo P);
        Productinfo Delete(int id);
        int Commit();



    }
}
