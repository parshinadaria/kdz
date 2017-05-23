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
            string response = "OK";
            if (!((login== "guest")&&(password== "123"))||((login == "admin") && (password == "321")))
            {
                response = "login or password is not correct";
            }
            return response;
        }
    }
}
