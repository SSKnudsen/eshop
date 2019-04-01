using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
    public interface Iuserinfomation
    {


        List<Userinformation> GetUserinformation();
        Userinformation GetuserinfById(int Id);
        Userinformation Update(Userinformation updateProducts);
        Userinformation Add(Userinformation P);
        Userinformation Delete(int id);
        int Commit();




    }
}
