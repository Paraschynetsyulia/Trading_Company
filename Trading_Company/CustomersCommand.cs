using System;
using DAL.ADO;
using DTO;
using System.Configuration;

namespace Trading_Company
{
   public  class CustomersCommand
   {
        public static void CreateCustomer(CustomersDAL customerDal)
        {
            string connStr = ConfigurationManager.ConnectionStrings["TraidingCompany(CS)"].ConnectionString;
            var orderDal = new OrdersDAL(connStr);
            Console.WriteLine("Creating new customer");
            Console.WriteLine("Select a order: ");
            OrdersCommand.GetAllOrders(orderDal);
            string orderId = Console.ReadLine();
            int orderId2 = Convert.ToInt32(orderId);
            Console.WriteLine("Input First Name: ");
            string _firstName = Console.ReadLine();
            Console.WriteLine("Input Last Name: ");
            string _lastName = Console.ReadLine();
            Console.WriteLine("Input discount: ");
            int _discount= Console.Read();


            CustomersDTO myCustomer= new CustomersDTO
            {
                OrderID = orderId2,
                FirstName = _firstName,
                LastName = _lastName,
                Discount = _discount
            };

            try
            {
                myCustomer = customerDal.CreateCustomer(myCustomer);
                Console.WriteLine($"New customer ID is {myCustomer.CustomerID}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error.");
            }
        }
        public static void DeleteCustomer(CustomersDAL customerDal)
        {
            Console.WriteLine("Delete");
            Console.WriteLine("Input customer id: ");
            string idstr = Console.ReadLine();
            int id = Convert.ToInt32(idstr);
            customerDal.DeleteCustomer(id);
            Console.WriteLine("Deleted");
        }

        public static void GetAllCustomer(CustomersDAL customerDal)
        {
            var customer = customerDal.GetAllCustomers();
            Console.WriteLine("Customers:");
            foreach (var p in customer)
            {
                Console.WriteLine($"{p.CustomerID,7}|{p.OrderID,7}|{p.FirstName,7}|{p.LastName,13}|{p.Discount,7}|{p.RowInsertTime,15}|");
            }
        }

        public static void UpdateCustomer(CustomersDAL customerDal)
        {
            Console.WriteLine("Updating customer");
            Console.WriteLine("Input customer id: ");
            string connStr = ConfigurationManager.ConnectionStrings["TraidingCompany(CS)"].ConnectionString;
            var cDal = new CustomersDAL(connStr);
            GetAllCustomer(customerDal);

            string idstr = Console.ReadLine();
            int id = Convert.ToInt32(idstr);

            CustomersDTO myCustomer = customerDal.GetCustomerbyID(id);
            myCustomer.RowUpdateTime = DateTime.UtcNow;

            if (myCustomer is null)
            {
                Console.WriteLine("Invalid input!\n");
                return;
            }

            Console.WriteLine(" Updating user:",
            myCustomer.OrderID,
            myCustomer.FirstName,
            myCustomer.LastName,
            myCustomer.Discount
            );
            while (true)
            {
                Console.WriteLine(@"
        1 - update OrderID
        2 - update FirsName
        3 - update LastName
");

                string m = Console.ReadLine();
                Console.WriteLine("\t");
                switch (m)
                {
                    case "1":
                        myCustomer.RowUpdateTime = DateTime.UtcNow;
                        Console.WriteLine("Input OrderID: ");
                        var orDal = new OrdersDAL(connStr);
                        OrdersCommand.GetAllOrders(orDal);
                        string idst = Console.ReadLine();
                        int idr = Convert.ToInt32(idst);
                        myCustomer.CustomerID = idr;
                        myCustomer = customerDal.UpdateCustomer(myCustomer, idr);
                        Console.WriteLine($"Updated successfully!");
                        break;

                    case "2":
                        Console.WriteLine("Input new First Name: ");
                        myCustomer.FirstName = Console.ReadLine();
                        //myCustomer.RowUpdateTime = DateTime.UtcNow;
                        myCustomer = customerDal.UpdateCustomer(myCustomer, id);
                        Console.WriteLine($"Updated successfully!");
                        break;

                    case "3":
                        Console.WriteLine("Input new Last Name: ");
                        myCustomer.LastName = Console.ReadLine();
                       // myCustomer.RowUpdateTime = DateTime.UtcNow;
                        myCustomer = customerDal.UpdateCustomer(myCustomer, id);
                        Console.WriteLine($"Updated successfully!");
                        break;
                    case "0": return;

                }
            }
        }
    }
}
