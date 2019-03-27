
using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
    public class ProductService : Iproduct
    {

        private readonly EfstoreContext _ctx;

        public ProductService(EfstoreContext ctx)
        {
            _ctx.Database.EnsureCreated();
            _ctx = ctx;

        }





        public Products Add(Products P)
        {
            _ctx.Products.Add(P);
            return P;
        }

        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }

        public Products Delete(int id)
        {
            var m = GetProductById(id);
            if (m != null)
            {
                _ctx.Products.Remove(m);
            }
            return m;
        }

        
        
        public Products GetProductById(int Id)
        {
            return _ctx.Products.Find(2);
        }

        public IQueryable<Products> GetProducts()
        {
            return _ctx.Products;
        }

        public IQueryable<Products> GetProductsByname(string name)
        {
            throw new NotImplementedException();
        }

        public Products Update(Products updateProducts)
        {
            _ctx.Products.Update(updateProducts);

            return updateProducts;
        }
    }
}
