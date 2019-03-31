
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
            var SelectProduct = context.Products
                                              .Where(s => s.ClothingID == Id)
                                              .ToList();
            List<Products> pd = SelectProduct.ToList<Products>();
            return pd;

        }

        public List<Products> GetProducts()
        {
            var context = new EfstoreContext();
            var SelectProduct = context.Products
                                              .Select(x => x)
                                              .ToList();
            List<Products> pd = SelectProduct.ToList<Products>();
            return pd;




            
        }

        public List<Products> GetProductsByname(string name)
        {
            var context = new EfstoreContext();
            var SelectProduct = context.Products
                                              .Where(s => s.name == name)
                                              .ToList();
            List<Products> pd = SelectProduct.ToList<Products>();
            return pd;

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

        IQueryable<Products> Iproduct.GetProducts()
        {
            throw new NotImplementedException();
        }

        IQueryable<Products> Iproduct.GetProductsByname(string name)
        {
            throw new NotImplementedException();
        }
    }
}
