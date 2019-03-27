using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
    public class UserinformationService : Iuserinfomation
    {

        private readonly EfstoreContext _ctx;

        public UserinformationService(EfstoreContext ctx)
        {
            _ctx.Database.EnsureCreated();
            _ctx = ctx;

        }
                          


        public Userinformation Add(Userinformation P)
        {
            _ctx.userinf.Add(P);
            return P;

        }

        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }

        public Userinformation Delete(int id)
        {
            var m = GetuserinfById(id);
            if (m != null)
            {
                _ctx.userinf.Remove(m);
            }
            return m;
        }

        public Userinformation GetuserinfById(int Id)
        {
            return _ctx.userinf.Find(Id);
        }

        public IQueryable<Userinformation> GetProductsByname(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Userinformation> GetUserinformation()
        {
            return _ctx.userinf;
        }

        public Userinformation Update(Userinformation updateuserinf)
        {
            _ctx.userinf.Update(updateuserinf);

            return updateuserinf;
        }
    }
}
