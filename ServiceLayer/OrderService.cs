using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Datalayer;

namespace ServiceLayer
{
    public class OrderService : Iorders
    {
        private readonly EfstoreContext _ctx;

        public OrderService(EfstoreContext ctx)
        {
            ctx.Database.EnsureCreated();
            _ctx = ctx;
        }


        public Orders Add(Orders P)
        {
            _ctx.Orders.Add(P);
            return P;
        }

        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }

        public Orders Delete(int id)
        {
            var m = GetOrderById(id);
            if (m != null)
            {
                _ctx.Orders.Remove(m);
            }
            return m;
        }

        public IQueryable<Orders> GetOrders()
        {
            return _ctx.Orders;

        }


        public IQueryable<Orders> GetOrdersByname(string name)
        {
            throw new NotImplementedException();
        }

        public Orders GetOrderById(int Id)
        {
            return _ctx.Orders.Find(Id);
        }

        public Orders Update(Orders updateOrders)
        {
            _ctx.Orders.Update(updateOrders);

            return updateOrders;
        }
    }
}
