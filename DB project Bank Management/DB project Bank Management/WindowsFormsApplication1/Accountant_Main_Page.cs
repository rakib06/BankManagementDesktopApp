using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using BO_Layer;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    public partial class Accountant_Main_Page : MetroForm
    {
        BO_class bo;
        DataSet ds;
        DataSet dt;
        public Accountant_Main_Page(BO_class bo1)
        {
            InitializeComponent();
            bo = bo1;
        }
        public void combo_bank()
        {
            ds = bo.get_combo_bank_accountant(bo.mainname);
            bank_name_box.DisplayMember = "bank_name";
            bank_name_box.ValueMember = "id";
            bank_name_box.DataSource = ds.Tables["bank"];

        }
        private void Accountant_Main_Page_Load(object sender, EventArgs e)
        {
            //metroPanel3.Hide();
           // depositePanel2.Hide();
            //transferPanel.Hide();
           // LoanPanel4.Hide();
            combo_bank();
            MessageBox.Show("Welcome Accountant \n" + bo.mainname);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            transferPanel.Show();
            LoanPanel4.Hide();
            depositePanel2.Hide();
            
            metroPanel3.Hide();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            Home ds = new Home();
            ds.Show();
            this.Hide();

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.Show();
        }

        private void metroComboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (account_id_type.Text.ToString() == "Autometic")
            {
                manualLabel.Hide();
                manualTextbox.Hide();
            }
            else
            {
                manualLabel.Show();
                manualTextbox.Show();

            }
        }

        private void STAFF_Click(object sender, EventArgs e)
        {
            metroPanel3.Show();
            LoanPanel4.Hide();
            depositePanel2.Hide();
            transferPanel.Hide();
          //  metroPanel3.Hide();

        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            metroPanel3.Hide();
        }
        string message1,message2;
       
        private void addButton2_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(manualTextbox.Text);
            int bank_id = Convert.ToInt32(bank_name_box.SelectedValue);
           // MessageBox.Show("" + bank_id);
            double balance=0.00;

            string username=usernamebox.Text.ToString();
            string password = passwordbox.Text.ToString();
            string confirmpass=confirmpass_box.Text.ToString();
            string name=nameBox.Text.ToString();
            string address = address_box.Text.ToString();
            string contact_info = contact_box.Text.ToString();

            if ( id==0||  username == "" || password == "" || confirmpass == "" || name == "" || bank_id == 0 || address == ""||contact_info=="")
            {
                MessageBox.Show(this, "Fill up every blank.", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }

            else if (password != confirmpass)
            {
                MessageBox.Show(this, "password don't match ", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
                
            else
            {
                //add account
                message1=bo.add_account_manual(id,bank_id,balance);
                MessageBox.Show(message1);
                //add client 
                message2=bo.add_client(id, username, password, name, address, contact_info);
                MessageBox.Show(message2);
            }
            nameBox.Clear();
            address_box.Clear();
            confirmpass_box.Clear();
            passwordbox.Clear();
            contact_box.Clear();
            usernamebox.Clear();
            manualTextbox.Clear();

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            LoanPanel4.Show();
            depositePanel2.Hide();
            transferPanel.Hide();
            metroPanel3.Hide();
            
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            depositePanel2.Show();
            LoanPanel4.Hide();
            
            transferPanel.Hide();
            metroPanel3.Hide();

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void depositePanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoanPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton6_Click_1(object sender, EventArgs e)
        {
            string ms="";
            int account_no = Convert.ToInt32(loanTextBox2.Text);
            double amount = Convert.ToDouble(loanTextBox1.Text);
            string activities = metroComboBox1.Text.ToString();
            string comment = loan_comment.Text.ToString();
            if (account_no == null || amount == null || activities == "")
            {
                MessageBox.Show(this, "Fill up every blank.", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else 
            {
               ms= bo.add_loan(activities, amount, account_no, comment);
               MessageBox.Show(ms);
            }
            loanTextBox2.Clear();
            loanTextBox1.Clear();
            loan_comment.Clear();
            
            
        }

        private void AddButton1_Click(object sender, EventArgs e)
        {
            string ms = "";
            int account_no = Convert.ToInt32(Dep_account_no.Text);
            double amount = Convert.ToDouble(Dep_amount.Text);
            string activities = metroComboBox2.Text.ToString();
            string comment = Dep_comment.Text.ToString();
            if (account_no == null || amount == null || activities == "")
            {
                MessageBox.Show(this, "Fill up every blank.", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                ms = bo.add_deposite(activities, amount, account_no, comment);
               // MessageBox.Show(ms);
            }
            Dep_account_no.Clear();
            Dep_amount.Clear();
            Dep_comment.Clear();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            string ms = "";
            int sender_account_id = Convert.ToInt32(sender_text.Text);
            int receiver_acc_id = Convert.ToInt32(toText.Text);
            double amount = Convert.ToDouble(amountTextBox3.Text);
            string comment = commentTextBox1.Text.ToString();
            ms=bo.add_transfer(receiver_acc_id, amount, sender_account_id, comment);
            MessageBox.Show(ms);
            sender_text.Clear();
            toText.Clear();
            amountTextBox3.Clear();
            commentTextBox1.Clear();


        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
             string username = bo.mainname;
           try{
            //   MessageBox.Show(username);
                string query = "Select * from bank_management.loan  " +
      "where  1 " ;
     //  "(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "');";

                //" or transfer.sender_account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "');";


                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=1234";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            string username = bo.mainname;
            try
            {
                //   MessageBox.Show(username);
                string query = "Select * from bank_management.transfer  " +
      "where  1 ";
                //  "(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "');";

                //" or transfer.sender_account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "');";


                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=1234";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            string username = bo.mainname;
            try
            {
                //   MessageBox.Show(username);
                string query = "Select * from bank_management.savings  " +
      "where  1 ";
                //  "(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "');";

                //" or transfer.sender_account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "');";


                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=1234";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
