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
            ctx.Database.EnsureCreated();
            _ctx = ctx;

        }


        public Shopbasket Add(Shopbasket P)
        {
            _ctx.shopbaskets.Add(P);
            Commit();
            return P;
        }

        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }

        public Shopbasket Delete(int id)
        {
            var m = GetOrderById(4);
            if (m != null)
            {
                _ctx.shopbaskets.Remove(m);
            }
            return m;
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

        public List<Shopbasket> GetShopBasket()
        {
            var context = new EfstoreContext();
            var SelectProduct = context.shopbaskets
                                              .Select(x => x)
                                              .ToList();
            List<Shopbasket> pd = SelectProduct.ToList<Shopbasket>();
            return pd;



         //   return _ctx.shopbaskets;
        }
        

        public List<Shopbasket> GetShopBasketById(int Id)
        {
            var context = new EfstoreContext();
            var SelectShopBasket = context.shopbaskets                
                                                .Where(s => s.ClothingID == Id)
                                               .ToList();
              List<Shopbasket> pd = SelectShopBasket.ToList<Shopbasket>();
            return pd;
            
        }

        

        Shopbasket IShopBasket.GetShopBasketById(int Id)
        {
            throw new NotImplementedException();
        }



        //private List<Shopbasket> GetProdBasket(int id)
        //{

        //}


    }
}
    