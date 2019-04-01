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
            ctx.Database.EnsureCreated();
            _ctx = ctx;

        }
                          


        public Userinformation Add(Userinformation P)
        {
            _ctx.userinformtation.Add(P);
            Commit();
            return P;

        }

        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }

        public Userinformation Delete(int id)
        {
            Userinformation m = GetuserinfById(id);
            if (m != null)
            {
                _ctx.userinformtation.Remove(m);
            }
            return m;
        }

        public Userinformation GetuserinfById(int Id)
        {

            //var context = new EfstoreContext();
            //var SelectProduct = context.userinf
            //                                  .Select(x => x.id = Id)
            //                                  .ToList();
            Userinformation pd = new Userinformation();// SelectProduct.ToList<Userinformation>();
            return pd;
        }
        

        public List<Userinformation> GetUserinformation()
        {

            var context = new EfstoreContext();
            var SelectProduct = context.userinformtation
                                              .Select(x => x)
                                              .ToList();
            List<Userinformation> pd = SelectProduct.ToList<Userinformation>();
            return pd;


        }

        public Userinformation Update(Userinformation updateuserinf)
        {
            _ctx.userinformtation.Update(updateuserinf);

            return updateuserinf;
        }
    }
}
