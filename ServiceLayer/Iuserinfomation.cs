using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebstoreConsole.Entities;

namespace ServiceLayer
{
    public interface Iuserinfomation
    {


        List<userinformation> GetUserinformation();
        userinformation GetuserinfById(int Id);
        userinformation Update(userinformation updateProducts);
        userinformation Add(userinformation P);
        userinformation Delete(int id);
        int Commit();




    }
}
