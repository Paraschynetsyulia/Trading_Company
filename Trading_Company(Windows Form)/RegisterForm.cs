using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Concrete;
using DAL.ADO;
using DTO;
using System.Configuration;

namespace Trading_Company_Windows_Form_
{
    public partial class RegisterForm : Form
    {
        static string connStr = ConfigurationManager.ConnectionStrings["TradingCompany(CS)"].ConnectionString;
        static public UsersDAL user = new UsersDAL(connStr);
        public AuthManager authManager = new AuthManager(user);
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_TradingCompany_CS_DataSet1.Roles". При необходимости она может быть перемещена или удалена.
            this.rolesTableAdapter1.Fill(this._TradingCompany_CS_DataSet1.Roles);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inpuut_Click(object sender, EventArgs e)
        {
            int role = Convert.ToInt32(idr.SelectedText);
            string fname = FName.Text;
            string lname = LName.Text;
            string log = textlog.Text;
            byte[] pas = Convert.FromBase64String(textpas.Text);
            var userIdent = authManager.GetUsers().SingleOrDefault(x => x.Login == log);
            if (userIdent != null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                UsersDTO user = new UsersDTO()
                {
                    RoleID = role,
                    FirstName = fname,
                    LastName = lname,
                    Login = log,
                    Password = pas
                };
                authManager.CreateUser(user);
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogForm lg = new LogForm();
            lg.Show();
        }
    }
}
