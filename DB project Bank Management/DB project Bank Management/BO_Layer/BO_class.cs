using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Layer;
using System.Data;
namespace BO_Layer
{
    public class BO_class
    {
        Data_class dallayer = new Data_class();
        public string mainname = "";
        public string bank_name = "";
        public string branch_name = "";
        public string add_admin(string name, string username, string password)
        {
            return dallayer.add_admin(name, username, password);
        }

        public string add_bank(string bank_name, string main_location, string contact_info, string username)
        {
            return dallayer.add_bank(bank_name, main_location, contact_info, username);
        }
        public string add_branch( string name,string location, string contact_info, int bank_id)
        {
            return dallayer.add_branch( name,location, contact_info, bank_id);
        }
        public string add_staff(string staff_name, string username, string password, int branch_id, string contact_info)
        {
            return dallayer.add_staff(staff_name, username, password, branch_id, contact_info);
        }
        public int accountant_login(string username, string password)
        {
            return dallayer.accountant_login(username, password);
        }
        public int client_login(string username, string password)
        {
            return dallayer.client_login(username, password);
        }
        public int admin_login(string username, string password)
        {
            return dallayer.admin_login(username, password);
        }
        public DataSet get_combo_bank(string username)
        {
            return dallayer.get_combo_bank(username);

        }
        public DataSet get_combo_bank_accountant(string username)
        {
            return dallayer.get_combo_bank_accountant(username);
        }
        public string add_account_manual(int acc_no, int bank_id, double balance)
        {
            return dallayer.add_account_manual(acc_no, bank_id, balance);
        }

        public string add_client(int account_id, string username, string password, string name, string address, string contact_info)
        {
            return dallayer.add_client(account_id, username, password, name, address, contact_info);
        }
        public DataSet get_combo_branch(int bank_id)
        {
            return dallayer.get_combo_branch(bank_id);

        }
        public string add_deposite(string activities, double amount, int account_id, string comment)
        {
            return dallayer.add_deposite(activities, amount, account_id, comment);
        }
        public string add_loan(string activities, double amount, int account_id, string comment)
        {
            return dallayer.add_loan(activities, amount, account_id, comment);
        }
        public string add_transfer(int receiver_acc_id, double amount, int sender_account_id, string comment)
        {
            return dallayer.add_transfer(receiver_acc_id, amount, sender_account_id, comment);
        }
    }
}
