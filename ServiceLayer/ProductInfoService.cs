using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
  public  class ProductInfoService : IProductinfo
    {
        private readonly EfstoreContext _ctx;

        public ProductInfoService(EfstoreContext ctx)
        {
            ctx.Database.EnsureCreated();
            _ctx = ctx;
         }




        public Productinfo Add(Productinfo P)
        {
            _ctx.Prodinfo.Add(P);
            Commit();
            return P;
        }

        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }

        public Productinfo Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Productinfo> GetProdinfo()
        {
            throw new NotImplementedException();
        }

        public Productinfo GetProductinfoById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Productinfo> GetProductinfoByname(string name)
        {
            throw new NotImplementedException();
        }

        public Productinfo Update(Productinfo updateProducts)
        {
            throw new NotImplementedException();
        }
    }
}
