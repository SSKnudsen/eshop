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
                          


        public userinformation Add(userinformation P)
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

        public userinformation Delete(int id)
        {
            userinformation m = GetuserinfById(id);
            if (m != null)
            {
                _ctx.userinformtation.Remove(m);
            }
            return m;
        }

        public userinformation GetuserinfById(int Id)
        {

            //var context = new EfstoreContext();
            //var SelectProduct = context.userinf
            //                                  .Select(x => x.id = Id)
            //                                  .ToList();
            userinformation pd = new userinformation();// SelectProduct.ToList<Userinformation>();
            return pd;
        }
        

        public List<userinformation> GetUserinformation()
        {
            var context = new EfstoreContext();
            var SelectProduct = context.userinformtation
                                              .Select(x => x)
                                              .ToList();
            List<userinformation> pd = SelectProduct.ToList<userinformation>();
            return pd;


        }

        public userinformation Update(userinformation updateuserinf)
        {
            _ctx.userinformtation.Update(updateuserinf);

            return updateuserinf;
        }
    }
}
