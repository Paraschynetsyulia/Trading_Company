using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DAL.ADO;
using DAL.Interfaces;
using System.Configuration;
using Unity;
using Unity.Injection;

namespace Trading_Company_Windows_Form_
{
    static class Program
    {
        public static IUnityContainer Container;
        private static string connStr;
        [STAThread]
        static void Main()
        {
            string connStr = ConfigurationManager.ConnectionStrings["TraidingCompany(CS)"].ConnectionString;
            ConfigureUnity();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogForm lf= Container.Resolve<LogForm>();
            if (lf.ShowDialog() == DialogResult.OK)
            {
                Application.Run(Container.Resolve<CustomerList>());
            }
            else
            {
                Application.Exit();
            }
        }
        private static void ConfigureUnity()
        {
            Container = new IUnityContainer();
            Container.RegisterInstance<string>("connStr", connStr);
            Container.RegisterType<IUsersDAL, UsersDAL>(new InjectionConstructor(new ResolveParameter("connStr")))
                     .RegisterType<ICustomersDAL, CustomersDAL>()
                     .RegisterType<IOrdersDAL, OrdersDAL>()
                     .RegisterType<IRolesDAL, RolesDAL>()
                     .RegisterType<IAuthManager, AuthManager>()
                     .RegisterType<ICustomersManager, CustomersManager>();
        }
    }
}
