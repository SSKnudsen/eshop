using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
   public interface Iproduct
    {
        IQueryable<Products> GetProducts();
        List<Products> GetProductsByprice(int name);
        IQueryable<Products> GetProductsByQuantity(int name);
        
        List<Products> GetProductsByDSC();
        Products GetProductById(int Id);
        Products Update(Products updateProducts);
        Products Add(Products P);
        Products Delete(int id);
        int Commit();




    }
}
