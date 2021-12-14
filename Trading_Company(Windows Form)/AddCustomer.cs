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
    public partial class AddCustomer : Form
    {
        static string connStr = ConfigurationManager.ConnecrionStrings["TradingCompany(CS)"].ConnectionString;
        static public CustomersDAL cust = new CustomersDAL(connStr);
        static public OrdersDAL ord = new OrdersDAL(connStr);
        static public UsersDAL us = new UsersDAL(connStr);
        static public RolesDAL rol = new RolesDAL(connStr);
        public CustomersManager customersManager = new CustomersManager(cust, ord, us, rol);
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomersList g = new CustomersList();
            int id = Convert.ToInt32(IDOrder.SelectedText);
            string Fname = FName.Text;
            string Lname = LName.Text;
            int disK= Convert.ToInt32(Disc.SelectedText);
            CustomersDTO cust = new CustomersDTO()
            {
                OrderID = id,
                FirstName = Fname,
                LastName = Lname,
                Discount = disK,

            };
            customersManager.AddCustomer(cust);
            this.Close();
        }
    }
}
