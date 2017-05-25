using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class Check_Auth
    {
        public string checkAuth(string login, string password)
        {
            bool guestcheck = (login == "guest") & (password == "123");
            bool admincheck = (login == "admin") & (password == "321");
            if (!guestcheck&&!admincheck)
            {
                throw new ArgumentException("login or password is not correct");
            }
            string response = login;
            return response;
        }
    }
}
