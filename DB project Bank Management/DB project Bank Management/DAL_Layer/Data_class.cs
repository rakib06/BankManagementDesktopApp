using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity_Layer;
using MySql.Data.MySqlClient;
namespace DAL_Layer
{
    public class Data_class
    {
        Entity_class entitylayer = new Entity_class();
        MySqlConnection conn;
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        public string dbconnect()
        {
            string message = null;
            string connstring = "SERVER =" + entitylayer.server + ";PORT = " + entitylayer.port + ";USERID = " + entitylayer.username + ";PASSWORD = " + entitylayer.password;
            try
            {

                conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                message = "Connect";

            }
            catch (Exception ex)
            {

                message = ex.ToString();
                Console.WriteLine(message);
            }
            return message;
        }


        public string add_admin(string name,string username, string password)
        {
            bool b = true;
            string message = dbconnect();
            b = check_username(username);
            if (b == false)
            {
                message = "Same username exist";
            }
            else
            {
                try
                {
                    dbconnect();
                    string query = "INSERT INTO `" + entitylayer.schema + "`.`" + entitylayer.admin + "` (`name`,`username`, `password`) VALUES ('"+name+"','" + username + "','" + password + "'); ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    //return reader.RecordsAffected.ToString();
                    if (reader.RecordsAffected == 1)
                    {
                        message = "Successfull";
                    }
                    else if (reader.RecordsAffected == 0)
                    {
                        message = "Try again";

                    }
                }
                catch (Exception e)
                {
                    message = e.ToString();
                }
            }
            conn.Close();
            return message;
        }

        //...................Check username if there is already same name exist at the sign up time.........//
        bool check_username(string username)
        {
            bool b = true;
            string message = dbconnect();
            try
            {
                string query = "SELECT * FROM `" + entitylayer.schema + "`.`" + entitylayer.admin + "` where `" + entitylayer.admin + "`.username = '" + username + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                Console.WriteLine(reader.RecordsAffected.ToString());
                int count = 0;
                while (reader.Read())
                {
                    count += 1;
                }
                if (count > 0)
                {
                    b = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                b = false;

            }
            conn.Close();
            return b;
        }
        //-----------------------------------------WELCOME
       /* public string welcome(string username)
        {
            string message = dbconnect();
            try
            {
                dbconnect();
                string query = "Select distinct name from `" + entitylayer.schema + "`.`" + entitylayer.admin + "`where username='" +username+"' ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    message = query;
                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();
            }

            conn.Close();
            return message;
        }
        */
        public string add_bank(string bank_name, string main_location, string contact_info,string username)
        {
           
            string message = dbconnect();
            
            
                try
                {
                    dbconnect();
                    string query = "INSERT INTO `" + entitylayer.schema + "`.`" + entitylayer.bank + "` (`bank_name`,`main_location`, `contact_info`,`admin`) VALUES ('" + bank_name + "','" + main_location + "','" + contact_info + "','" + username + "'); ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    //return reader.RecordsAffected.ToString();
                    if (reader.RecordsAffected == 1)
                    {
                        message = "Successfull";
                    }
                    else if (reader.RecordsAffected == 0)
                    {
                        message = "Try again";

                    }
                }
                catch (Exception e)
                {
                    message = e.ToString();
                }
            
            conn.Close();
            return message;
        }
        public string add_branch(string name, string location, string contact_info, int bank_id)
        {

            string message = dbconnect();


            try
            {
                dbconnect();
                string query = "INSERT INTO `" + entitylayer.schema + "`.`" + entitylayer.branch + "` (`name`,`location`, `contact_info`,`bank_id1`) VALUES ('"+name+"','" + location + "','" + contact_info + "','" + bank_id + "'); ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    message = "Successfull";
                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();
            }

            conn.Close();
            return message;
        }
        public string add_account_manual( int acc_no,int bank_id, double balance)
        {

            string message = dbconnect();


            try
            {
                dbconnect();
                string query = "INSERT INTO `" + entitylayer.schema + "`.`" + entitylayer.account + "` (`id`,`bank_id`, `balance`) VALUES ('" + acc_no + "','" + bank_id + "','" + balance + "'); ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    message = "Successfull";
                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();
            }

            conn.Close();
            return message;
        }
        public string add_client(int account_id,string username, string password,string name, string address ,string contact_info)
        {

            string message = dbconnect();


            try
            {
                dbconnect();
                string query = "INSERT INTO `" + entitylayer.schema + "`.`" + entitylayer.client + "` (`account_id`,`username`, `password`,`name`,`address`,`contact_info`) VALUES ('" + account_id + "','" + username + "','" + password+ "','" + name + "','" + address + "','" + contact_info + "'); ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    message = "Successfull";
                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();
            }

            conn.Close();
            return message;
        }
        public string add_staff(string staff_name, string username, string password, int branch_id, string contact_info)
        {

            string message = dbconnect();


            try
            {
                dbconnect();
                string query = "INSERT INTO `" + entitylayer.schema + "`.`" + entitylayer.accountant + "` (`name`,`username`, `password`,`current_branch`,`contact_info`) VALUES ('" + staff_name + "','" + username + "','" + password + "','" + branch_id + "','" + contact_info+ "'); ";
                
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    message = "Successfull";
                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();
              
            }

            conn.Close();
            return message;
        }

        //----------------------------------------------ADJUST...................................//
        public string adjust_balance(string activities, double amount, int account_id)
        {

            string message = dbconnect();

            

            try
            {
                dbconnect();
                string query = "";
                if (activities == "Return"|| activities=="Deposite")
                {
                     query = "SET SQL_SAFE_UPDATES=0; update `" + entitylayer.schema + "`.`" + entitylayer.account + "` set balance = balance + '"+amount+"' where id ='" + account_id + "'; ";

                }
                else if (activities == "Borrow" || activities == "Withdraw")
                {
                     query = "SET SQL_SAFE_UPDATES=0; update `" + entitylayer.schema + "`.`" + entitylayer.account + "` set balance = balance - '"+amount+"' where id ='" + account_id + "'; ";

                }
               
               
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    message = "Successfull";
                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();

            }

            conn.Close();
            return message;
        }

        public string adjust_sender(double amount, int account_id)
        {

            string message = dbconnect();



            try
            {
                dbconnect();
                string query = "";
               
                  
                
                    query = "SET SQL_SAFE_UPDATES=0; update `" + entitylayer.schema + "`.`" + entitylayer.account + "` set balance = balance - '" + amount + "' where id ='" + account_id + "'; ";

                


                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    message = "Successfull";
                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();

            }

            conn.Close();
            return message;
        }
        public string adjust_receiver( double amount, int account_id)
        {

            string message = dbconnect();



            try
            {
                dbconnect();
                string query = "";
               
                    query = "SET SQL_SAFE_UPDATES=0; update `" + entitylayer.schema + "`.`" + entitylayer.account + "` set balance = balance + '" + amount + "' where id ='" + account_id + "'; ";

               


                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    message = "Successfull";
                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();

            }

            conn.Close();
            return message;
        }
        //--------------------------------------------LOAN----------------------------//
        public string add_loan(string activities, double amount, int account_id,string comment)
        {

            string message = dbconnect();


            try
            {
                dbconnect();
                
                string query = "INSERT INTO `" + entitylayer.schema + "`.`" + entitylayer.loan + "` (`date`, `amount`,`activities`,`comment`,`account_id`) VALUES ( now(),'" + amount + "','" + activities + "','" + comment + "','" + account_id + "'); ";
                
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                  //  adjust_balance( activities,  amount, account_id);
                    message = "Successfull";

                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();

            }

            conn.Close();
            return message;
        }
        //-----------------------------ADD DEPOSITE -------------------------------//
        public string add_deposite(string activities, double amount, int account_id, string comment)
        {

            string message = dbconnect();


            try
            {
                dbconnect();

                string query = "INSERT INTO `" + entitylayer.schema + "`.`" + entitylayer.savings + "` (`date`, `amount`,`activities`,`comment`,`account_id`) VALUES ( now(),'" + amount + "','" + activities + "','" + comment + "','" + account_id + "'); ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    adjust_balance(activities, amount, account_id);
                    message = "Successfull";

                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();

            }

            conn.Close();
            return message;
        }
        //---------------------------------ADD trnasfer -------------------------------------//
        public string add_transfer(int receiver_acc_id, double amount, int sender_account_id, string comment)
        {

            string message = dbconnect();


            try
            {
                dbconnect();

                string query = "INSERT INTO `" + entitylayer.schema + "`.`" + entitylayer.transfer + "` (`receiver_acc_id`,`date`, `amount`,`sender_account_id`,`comment`) VALUES ('"+receiver_acc_id+"', now(),'" + amount + "','" + sender_account_id + "','" + comment + "'); ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                //return reader.RecordsAffected.ToString();
                if (reader.RecordsAffected == 1)
                {
                    adjust_sender(amount,sender_account_id);
                    adjust_receiver(amount, receiver_acc_id);
                    message = "Successfull";

                }
                else if (reader.RecordsAffected == 0)
                {
                    message = "Try again";

                }
            }
            catch (Exception e)
            {
                message = e.ToString();

            }

            conn.Close();
            return message;
        }

        //-------------------------------------- Admin Login ------------------------------//

        public int admin_login(string username, string password)
        {
            dbconnect();
            int t = 100;
            string query = "SELECT * FROM `" + entitylayer.schema + "`.`" + entitylayer.admin + "` where `" + entitylayer.admin + "`.username = '" + username + "' && `" + entitylayer.admin + "`.password = '" + password + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            //return reader.RecordsAffected.ToString();
            int count = 0;
            while (reader.Read())
            {
                count += 1;
            }

            if (count != 0)
            {
                t = 1;
            }
            return t;
        }
        public int accountant_login(string username, string password)
        {
            dbconnect();
            int t = 100;
            string query = "SELECT * FROM `" + entitylayer.schema + "`.`" + entitylayer.accountant + "` where `" + entitylayer.accountant + "`.username = '" + username + "' && `" + entitylayer.accountant + "`.password = '" + password + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            //return reader.RecordsAffected.ToString();
            int count = 0;
            while (reader.Read())
            {
                count += 1;
            }

            if (count != 0)
            {
                t = 1;
            }
            return t;
        }
        public int client_login(string username, string password)
        {
            dbconnect();
            int t = 100;
            string query = "SELECT * FROM `" + entitylayer.schema + "`.`" + entitylayer.client + "` where `" + entitylayer.client + "`.username = '" + username + "' && `" + entitylayer.client + "`.password = '" + password + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            //return reader.RecordsAffected.ToString();
            int count = 0;
            while (reader.Read())
            {
                count += 1;
            }

            if (count != 0)
            {
                t = 1;
            }
            return t;
        }

        public DataSet get_login_type(string username)
        {

            DataSet ds = new DataSet();
            try
            {

                MySqlDataAdapter msdp = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                string query = "SELECT * FROM " + entitylayer.schema + "." + entitylayer.admin + " where username = '" + username + "';";
                dbconnect();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                msdp.SelectCommand = cmd;
                msdp.Fill(ds, "admin");
                dt = ds.Tables["admin"];
                conn.Close();

            }
            catch (Exception e)
            {

                return null;
            }
            return ds;

        }
        //-----------------------------------COMBO

        public DataSet get_combo_bank(string username)
        {
            try
            {

                dbconnect();
                string query = "SELECT * FROM `" + entitylayer.schema + "`.`" + entitylayer.bank + "`where admin= '"+username+"';";
                // MySqlDataAdapter dataadapter = new MySqlDataAdapter(query, conn);
                DataSet ds = null;
                MySqlDataAdapter da_res = null;
                ds = new DataSet();
                da_res = new MySqlDataAdapter(query, conn);
                da_res.Fill(ds, "bank");
                conn.Close();

                return ds;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public DataSet get_combo_bank_accountant(string username)
        {
            try
            {

                dbconnect();
                string query = "SELECT * FROM `" + entitylayer.schema + "`.`" + entitylayer.bank + "`,`" + entitylayer.schema + "`.`" + entitylayer.branch + "`,`" + entitylayer.schema + "`.`" + entitylayer.accountant + "`where bank.id=branch.bank_id1 and branch.id=accountant.current_branch and accountant.username='" + username + "';";
                // MySqlDataAdapter dataadapter = new MySqlDataAdapter(query, conn);
                DataSet ds = null;
                MySqlDataAdapter da_res = null;
                ds = new DataSet();
                da_res = new MySqlDataAdapter(query, conn);
                da_res.Fill(ds, "bank");
                conn.Close();

                return ds;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public DataSet get_combo_branch(int bank_id)
        {
            try
            {

                dbconnect();
                string query = "SELECT * FROM `" + entitylayer.schema + "`.`" + entitylayer.branch + "`where bank_id1= '" + bank_id + "';";
                // MySqlDataAdapter dataadapter = new MySqlDataAdapter(query, conn);
                DataSet ds = null;
                MySqlDataAdapter da_res = null;
                ds = new DataSet();
                da_res = new MySqlDataAdapter(query, conn);
                da_res.Fill(ds, "branch");
                conn.Close();

                return ds;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }
}
