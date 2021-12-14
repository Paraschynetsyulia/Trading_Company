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
using Configuration;

namespace Trading_Company_Windows_Form_
{
    public partial class CustForm : Form
    {
        static string connStr = ConfigurationManager.ConnecrionStrings["TradingCompany(CS)"].ConnectionString;
        static public CustomersDAL cust = new CustomersDAL(connStr);
        static public OrdersDAL ord = new OrdersDAL(connStr);
        static public UsersDAL us = new UsersDAL(connStr);
        static public RolesDAL rol = new RolesDAL(connStr);
        public CustomersManager customersManager = new CustomersManager(cust, ord, us, rol);
        public CustForm()
        {
            InitializeComponent();
        }

        private void CustForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_TradingCompany_CS_DataSet1.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this._TradingCompany_CS_DataSet1.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_TradingCompany_CS_DataSet1.Customers". При необходимости она может быть перемещена или удалена.
            this.customersTableAdapter.Fill(this._TradingCompany_CS_DataSet1.Customers);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = customersManager.GetListCustomers();
            dataGridView1.DataSource = bs;
            dataGridView1.Refresh();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            customersManager.DeleteCustomer(id);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AddCustomer a = new AddCustomer();
            a.Show();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = customersManager.GetListCustomers();
            dataGridView1.DataSource = bs;
            dataGridView1.Refresh();
        }
    }
}
