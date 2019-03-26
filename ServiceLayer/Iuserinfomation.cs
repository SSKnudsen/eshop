using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
    public interface Iuserinfomation
    {


        IQueryable<Userinformation> GetUserinformation();
        IQueryable<Userinformation> GetProductsByname(string name);
        Userinformation GetProductById(int Id);
        Userinformation Update(Userinformation updateProducts);
        Userinformation Add(Userinformation P);
        Userinformation Delete(int id);
        int Commit();




    }
}
