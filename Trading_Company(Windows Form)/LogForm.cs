using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DAL.ADO;
using BusinessLogic.Concrete;


namespace Trading_Company_Windows_Form_
{
    public partial class LogForm : Form
    {
        static string connStr = ConfigurationManager.ConnectionStrings["TradingCompany(CS)"].ConnectionString;
        static public UsersDAL user = new UsersDAL(connStr);
        public AuthManager authManager = new AuthManager(user);
        public LogForm()
        {
            InitializeComponent();
        }
        
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void input_Click(object sender, EventArgs e)
        {
            string log = login.Text;
            string pas = password.Text;
            bool u = authManager.Login(log, pas);
            if (u == true)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Error");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterForm r = new RegisterForm();
            r.Show();
        }
    }
}
