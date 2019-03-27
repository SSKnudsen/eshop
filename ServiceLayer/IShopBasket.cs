using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
    public interface IShopBasket
    {


        IQueryable<Shopbasket> GetShopBasket();
        Shopbasket GetShopBasketById(int Id);
        Shopbasket Update(Shopbasket updateShopBasket);
        Shopbasket Add(Shopbasket P);
        Shopbasket Delete(int id);
        int Commit();



    }
}
