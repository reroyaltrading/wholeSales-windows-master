using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WholeSalesWarehousing.Model;
using WholeSalesWarehousing.Views;

namespace WholeSalesWarehousing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String base_url = "http://wholesalecompany.ca";
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            Login login = Login.DoLogin(username, password, base_url);

            if (login.auth)
            {
                FormMain main = new FormMain(login);
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid user or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
