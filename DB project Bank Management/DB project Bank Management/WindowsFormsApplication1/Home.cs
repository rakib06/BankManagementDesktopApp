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
namespace WindowsFormsApplication1
{
    public partial class Home : MetroForm
    {
        BO_class bo = new BO_class();
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
             
            metroTextBox6.PasswordChar = '*';
            metroTextBox6.MaxLength = 14;
             passwordbox.PasswordChar = '*';
            passwordbox.MaxLength = 14;
           lpassbox.PasswordChar = '*';
            lpassbox.MaxLength = 14;
            keybox.PasswordChar = '*';
            keybox.MaxLength = 14;

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
           

            string username = lusernamebox.Text;
            string password = lpassbox.Text;
            string type = loginasCombobox.Text;
            // -------------------------  Login --------------------------//
            if ( username == "" || password == "" || type=="")
            {
                MessageBox.Show(this, "Fill up every blank.", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
            else if (type == "Admin")
            {
                int t = bo.admin_login(username, password);
                if (t == 0)
                {

                    MessageBox.Show(this, "Wrong Combination", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else if (t == 1)
                {
                    bo.mainname = username;
                    Admin admin = new Admin(bo);
                    admin.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show(this, "Wrong Combination", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else if (type == "Accountant")
            {
                int t = bo.accountant_login(username, password);
                if (t == 0)
                {

                    MessageBox.Show(this, "Wrong Combination", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else if (t == 1)
                {

                    bo.mainname = username;
                    Accountant_Main_Page acc= new Accountant_Main_Page(bo);
                    acc.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show(this, "Wrong Combination", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else if (type == "Client")
            {
                int t = bo.client_login(username, password);
                if (t == 0)
                {

                    MessageBox.Show(this, "Wrong Combination", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else if (t == 1)
                {
                    bo.mainname = username;
                    Client client = new Client(bo);
                    client.Show();
                    this.Hide();
                }
                else
                MessageBox.Show(this, "Wrong Combination", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel15_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string key = keybox.Text;
            string name = namebox.Text;
            string username = usernamebox.Text;
            string password = passwordbox.Text;
            string confirmpass = metroTextBox6.Text;
            //send it to the database
            string bank_name = bankbox.Text;
            string location = locationbox.Text;
            string contact_info = contactbox.Text;
            //admin id = where username=this name
            string message,message_bank;
            if (key == "" || name == "" || username == "" || password == "" || confirmpass == "" || bank_name == "" || location == "" || contact_info == "")
            {
                MessageBox.Show(this, "Fill up every blank.", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }

            else if (password != confirmpass)
            {
                MessageBox.Show(this, "password don't match ", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else if (key != "1234")
            {
                MessageBox.Show(this, "access key don't match ", "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                message = bo.add_admin(name, username, password);
                message_bank = bo.add_bank(bank_name, location, contact_info, username);
                if (message == "Successfull" && message_bank == "Successfull")
                {
                    MessageBox.Show(this, "Saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show(this, message_bank, "Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                }
                keybox.Clear();
                namebox.Clear();
                usernamebox.Clear();
                passwordbox.Clear();
                metroTextBox6.Clear();
                bankbox.Clear();
                locationbox.Clear();
                contactbox.Clear();
               // InitializeComponent();
            }
                
        }

        private void metroTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroTextBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
