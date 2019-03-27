using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
    public class ShopbasketService : IShopBasket
    {

        private readonly EfstoreContext _ctx;

        public ShopbasketService(EfstoreContext ctx)
        {
            _ctx.Database.EnsureCreated();
            _ctx = ctx;

        }


        public Shopbasket Add(Shopbasket P)
        {
            _ctx.shopbaskets.Add(P);
            return P;
        }

        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }

        public Shopbasket Delete(int id)
        {
            var m = GetOrderById(id);
            if (m != null)
            {
                _ctx.shopbaskets.Remove(m);
            }
            return m;
        }

        public IQueryable<Shopbasket> GetOrders()
        {
            return _ctx.shopbaskets;

        }



        public Shopbasket GetOrderById(int Id)
        {
            return _ctx.shopbaskets.Find(Id);
        }

        public Shopbasket Update(Shopbasket updateShopbasket)
        {
            _ctx.shopbaskets.Update(updateShopbasket);

            return updateShopbasket;
        }

        public IQueryable<Shopbasket> GetShopBasket()
        {
            return _ctx.shopbaskets;
        }
        

        public Shopbasket GetShopBasketById(int Id)
        {

            return _ctx.shopbaskets.Find(Id);
           

        }
    }
}
    