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
    public partial class Admin : MetroForm
    {
        BO_class bo;
        DataSet ds;
        DataSet dt;
        public int id_b;
        string welcome;
        string message;
        public Admin(BO_class bo1)
        {
            InitializeComponent();
            bo = bo1;
        }
       
        public void combo_bank()
        {
            ds = bo.get_combo_bank(bo.mainname);
            bank_name_box.DisplayMember = "bank_name";
            bank_name_box.ValueMember = "id";
            bank_name_box.DataSource = ds.Tables["bank"];
            
        }
        public void combo_bank_acc()
        {
            ds = bo.get_combo_bank(bo.mainname);
            bank_combo_ACC.DisplayMember = "bank_name";
            bank_combo_ACC.ValueMember = "id";
            bank_combo_ACC.DataSource = ds.Tables["bank"];
            combo_branch();
            
        }
        public void combo_branch()
        {
            id_b=Convert.ToInt32(bank_combo_ACC.SelectedValue);
            //welcome = bo.welcome(bo.mainname);
            MessageBox.Show("Welcome Admin");
            ds = bo.get_combo_branch(id_b);
            branch_box_acc.DisplayMember = "name";
            branch_box_acc.ValueMember = "id";
            branch_box_acc.DataSource = ds.Tables["branch"];
            
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            combo_bank();
           
            combo_bank_acc();
            metroPanel3.Hide();
            metroPanel2.Hide();
            show();
        }

        

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.Show();

        }

        private void addButton2_Click(object sender, EventArgs e)
        {
            string staff_name = nameBox.Text.ToString();
            string password = passwordbox.Text.ToString();
            string username = username_box.Text.ToString();
            string confirmpass = confirmpass_box.Text.ToString();
            string contact_acc = contact_accountan_box.Text.ToString();
            int bank_id = Convert.ToInt32(bank_combo_ACC.SelectedValue);
            int branch_id = Convert.ToInt32(branch_box_acc.SelectedValue);
            MessageBox.Show(""+branch_id);

            string message, message_bank;
            if (staff_name == "" || password == "" || username == "" || password == "" || confirmpass == "" || contact_acc == "" || bank_id == 0 || branch_id == 0)
            {
                MessageBox.Show(this, "Fill up every blank.", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }

            else if (password != confirmpass)
            {
                MessageBox.Show(this, "password don't match ", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            else
            {
                message = bo.add_staff(staff_name, username, password,branch_id,contact_acc);
              
                if (message == "Successfull" )
                {
                    MessageBox.Show(this, "Saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show(message);
                }

            }
        }
        
        private void AddButton1_Click(object sender, EventArgs e)
        {
            string branch_name = branch_name_box.Text.ToString();
            string location = location_box.Text.ToString();
            string contact_branch = contact_branch_box.Text.ToString();
            id_b = Convert.ToInt32(bank_name_box.SelectedValue);
            message = bo.add_branch(branch_name, location, contact_branch, id_b);
            MessageBox.Show(message);
            branch_name_box.Clear();
            location_box.Clear();
            contact_branch_box.Clear();
            combo_branch();

        }

        private void statusButton4_Click(object sender, EventArgs e)
        {

        }

        private void Add_staff_button_Click(object sender, EventArgs e)
        {
            
            metroPanel3.Show();
            metroPanel2.Hide();
            dataGridView1.Hide();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            metroPanel3.Hide();
        }

        private void add_branch_button_Click(object sender, EventArgs e)
        {
            metroPanel2.Show();
            metroPanel3.Hide();
            dataGridView1.Hide();
        }

        private void branch_close_button_Click(object sender, EventArgs e)
        {
            metroPanel2.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            show();
        }
            public void show(){
            try
            {
                //where bank.id=branch.bank_id1 and branch.id=accountant.current_branch and accountant.username='" + username + "';";
                //   MessageBox.Show(username);
                string query = "Select distinct accountant.name as 'Staff Name',accountant.username,branch.name as 'Current Branch Name', bank.bank_name as 'Bank Name', accountant.contact_info as 'Contact info' from bank_management.accountant, bank_management.branch, bank_management.bank,  bank_management.admin where bank.id=branch.bank_id1 and branch.id=accountant.current_branch and bank.admin= '" + bo.mainname + "'";
     
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
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.Show();
        }

       

        
    }
}
