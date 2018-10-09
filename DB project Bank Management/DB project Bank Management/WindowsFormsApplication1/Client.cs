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
      
    public partial class Client : MetroForm
    {
        BO_class bo;
        public Client(BO_class bo1)
        {
            bo = bo1;

            InitializeComponent();
        }
      
        private void Client_Load(object sender, EventArgs e)
        {
            loan();
          deposite();
          total();
          info();
         // transfer();
        }


        public void total()
        {
            try
            {
                string username = bo.mainname;
                //  MessageBox.Show(username);
                string query = "select distinct balance as Balance from bank_management.account,bank_management.client where client.account_id=account.id and client.username='" + username + "';";

     

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
        public void deposite()
        {
            try
            {
                string username = bo.mainname;
                //  MessageBox.Show(username);
  string query = "SELECT distinct (select sum(savings.amount ) from bank_management.savings  where savings.activities='Deposite' and savings.account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "') )- " +
"(select sum(savings.amount ) from bank_management.savings  where savings.activities='Withdraw' and savings.account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "') )  "+
//"(select sum(transfer.amount ) from bank_management.transfer  where transfer.receiver_acc_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "') ) - " +
//"(select sum(transfer.amount ) from bank_management.transfer  where transfer.sender_account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "') ) " +
"  as Balance from bank_management.loan where loan.account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "')";



                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=1234";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView5.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        public void info()
        {
            try
            {
                string username = bo.mainname;
                //  MessageBox.Show(username);
                string query = "SELECT account_id as ID ,name as Name , address as Address , contact_info as 'Contact Info' FROM bank_management.client where username='" + username + "';";



                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=1234";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView4.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        public void loan()
        {
            
            try
            {
                string username = bo.mainname;
                //  MessageBox.Show(username);
              //  string query = "select distinct balance from bank_management.account,bank_management.client where client.account_id=account.id and client.username='" + username + "';";
                string query = "SELECT distinct (select sum(loan.amount ) from bank_management.loan  where loan.activities='Borrow' and loan.account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "') )- "+
"(select sum(loan.amount ) from bank_management.loan  where loan.activities='Return' and loan.account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "') )  as Due from bank_management.loan where loan.account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "')";



                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=1234";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView3.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            transfer();
        
        }
        public void transfer()
        {
            try
            {
                string username = bo.mainname;
                //  MessageBox.Show(username);
                string query = "Select * from bank_management.transfer  " +
      "where  transfer.receiver_acc_id = " +
       "(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "') " +
      " or transfer.sender_account_id=(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "');";


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
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            try
            {
                string username = bo.mainname;
               // MessageBox.Show(username);
                string query = "Select * from bank_management.savings  " +
      "where  savings.account_id = " +
       "(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "');";

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
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            try
            {
                string username = bo.mainname;
             //   MessageBox.Show(username);
                string query = "Select * from bank_management.loan  " +
      "where  loan.account_id = " +
       "(select client.account_id from bank_management.client , bank_management.account where client.account_id=account.id and client.username='" + username + "');";

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
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

          
          
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
