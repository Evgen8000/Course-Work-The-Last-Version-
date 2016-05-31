using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    [Serializable]
    public class Account
    {
        public string Login;
        public string Password;
        public bool IsAdmin;

        public Account(string login, string pass, bool admin = false)
        {
            Login = login;
            Password = pass;
            IsAdmin = admin;
        }
    }
}
