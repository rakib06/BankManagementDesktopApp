using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Entity_class
    {


        public string server = "127.0.0.1";
        public string port = "3306";
        public string schema = "bank_management";
        public string username = "root";
        public string password = "1234";

        //table name
        public string admin = "Admin";
        public string account = "account";
        public string accountant = "accountant";
        public string bank = "bank";
        public string branch = "branch";
        public string client = "client";
        public string loan = "loan";
        public string savings = "savings";
        public string transfer = "transfer";

    }
}
