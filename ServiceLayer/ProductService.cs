
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
             ctx.Database.EnsureCreated();
            _ctx = ctx;

        }





        public Products Add(Products P)
        {
            _ctx.Products.Add(P);
            Commit();
            return P;
        }

        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }

        public Products Delete(int id)
        {
            throw new NotImplementedException();
        }

        //public Products Delete(int id)
        //{
        //    var m = GetProductById(id);
        //    if (m != null)
        //    {
        //        _ctx.Products.Remove(m);
        //    }
        //    return m;
        //}



        public List<Products> GetProductById(int Id)
        {
            var context = new EfstoreContext();
            var studentsWithSameName = context.Products
                                              .Where(s => s.ClothingID == Id)
                                              .ToList();
            List<Products> pd = studentsWithSameName.ToList<Products>();
            return pd;

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

        Products Iproduct.GetProductById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
