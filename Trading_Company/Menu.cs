using System;
using DAL.ADO;
using System.Configuration;
using DTO;

namespace Trading_Company
{
    public static class Menu
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["TraidingCompany(CS)"].ConnectionString;
        static bool res = true;

        public static void ShowMenu()
        {
            while (res)
            {
                Console.WriteLine(@"
            ____________________TRAIDING COMPANY________________ 
        1 - Customers
        2 - Users
        3 - Roles
        4 - Orsers
      0 - return
");
                string choice = Console.ReadLine();
                Console.WriteLine("\t");
                switch (choice)
                {
                    case "1":
                        MenuCustomers(connStr);
                        break;
                    case "2":
                        MenuUsers(connStr);
                        break;
                    case "3":
                        MenuRoles(connStr);
                        break;
                    case "4":
                        MenuOrsers(connStr);
                        break;
                    case "0":
                        res = false;
                        break;
                }
            }
        }

        private static void MenuOrsers(string connStr)
        {
            var ordersDal = new OrdersDAL(connStr);
            while (res)
            {
                Console.WriteLine(@"
            ________________TRAIDING COMPANY___________________
                *_*_*_Orders_*_*_*
                1 - Create
                2 - Read
                3 - Update
                4 - Delete
              0 - Show main menu
");
                string choise= Console.ReadLine();
                Console.WriteLine("\t");
                switch (choise)
                {
                    case "1":
                        OrdersCommand.CreateOrder(ordersDal);
                        break;
                    case "2":
                        OrdersCommand.GetAllOrders(ordersDal);
                        break;
                    case "3":
                        OrdersCommand.UpdateOrder(ordersDal);
                        break;
                    case "4":
                        OrdersCommand.DeleteOrder(ordersDal);
                        break;
                    case "0":
                        ShowMenu();
                        res = false;
                        break;
                }
            }
        }

        private static void MenuRoles(string connStr)
        {
            var rolesDal = new RolesDAL(connStr);
            while (res)
            {
                Console.WriteLine(@"
            _________TRAIDING COMPANY_________
                ***ROLES***
                1 - Create
                2 - Read
                3 - Update
                4 - Delete
              0 - Show main menu
");
                string f = Console.ReadLine();
                Console.WriteLine("\t");
                switch (f)
                {
                    case "1":
                        RolesCommand.CreateRole(rolesDal);
                        break;
                    case "2":
                        RolesCommand.GetAllRoles(rolesDal);
                        break;
                    case "3":
                        RolesCommand.UpdateRole(rolesDal);
                        break;
                    case "4":
                        RolesCommand.DeleteRole(rolesDal);
                        break;
                    case "0":
                        ShowMenu();
                        res = false;
                        break;
                }
            }
        }

        private static void MenuUsers(string connStr)
        {
            var usersDal = new UsersDAL(connStr);
            while (res)
            {
                Console.WriteLine(@"
            ___________TRAIDING COMPANY________
                ***Users***
                1 - Create
                2 - Read
                3 - Update
                4 - Delete
              0 - Show main menu
");
                string choise= Console.ReadLine();
                Console.WriteLine("\t");
                switch (choise)
                {
                    case "1":
                        UsersCommand.CreateUser(usersDal);
                        break;
                    case "2":
                        UsersCommand.GetAllUsers(usersDal);
                        break;
                    case "3":
                        UsersCommand.UpdateUser(usersDal);
                        break;
                    case "4":
                        UsersCommand.DeleteUser(usersDal);
                        break;
                    case "0":
                        ShowMenu();
                        res = false;
                        break;
                }
            }
        }

        private static void MenuCustomers(string connStr)
        {
            var customersDal = new CustomersDAL(connStr);
            while (res)
            {
                Console.WriteLine(@"
            ____________TRAIDING COMPANY_____________
                ***Customers***
                1 - Create
                2 - Read
                3 - Update
                4 - Delete
              0 - Show main menu
");
                string choise = Console.ReadLine();
                Console.WriteLine("\t");
                switch (choise)
                {
                    case "1":
                        CustomersCommand.CreateCustomer(customersDal);
                        break;
                    case "2":
                        CustomersCommand.GetAllCustomer(customersDal);
                        break;
                    case "3":
                        CustomersCommand.UpdateCustomer(customersDal);
                        break;
                    case "4":
                        CustomersCommand.DeleteCustomer(customersDal);
                        break;
                    case "0":
                        ShowMenu();
                       res = false;
                        break;
                }
            }
        }
    }
}
