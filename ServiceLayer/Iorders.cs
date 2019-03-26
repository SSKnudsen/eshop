using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Datalayer;

namespace ServiceLayer
{
   public interface Iorders
    {

        IQueryable<Orders> GetOrders();
        IQueryable<Orders> GetOrdersByname(string name);
        Orders GetOrderById(int Id);
        Orders Update(Orders updateOrders);
        Orders Add(Orders P);
        Orders Delete(int id);
        int Commit();









    }
}
