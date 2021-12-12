using System;
using DAL.ADO;
using DTO;

namespace Trading_Company
{
    public class OrdersCommand
    {
        public static void DeleteOrder(OrdersDAL orderDal)
        {
            Console.WriteLine("_________Delete Order_________");
            Console.WriteLine("Input order id: ");
            string idstr = Console.ReadLine();
            int id = Convert.ToInt32(idstr);
            orderDal.DeleteOrder(id);
            Console.WriteLine("Deleted!!!!!!!!!");
        }
        public static void UpdateOrder(OrdersDAL orderDal)
        {
            Console.WriteLine("Input order id: ");
            string idstr = Console.ReadLine();
            int id = Convert.ToInt32(idstr);

            OrdersDTO myOrder = orderDal.GetOrderbyID(id);

            if (myOrder is null)
            {
                Console.WriteLine("Invalid input!\n");
                return;
            }

            Console.WriteLine("Updating order:",
            myOrder.OrderName);
            try
            {
                //myOrder.RowUpdateTime = DateTime.UtcNow;
                Console.WriteLine("Input new order: ");
                myOrder.OrderName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("ERROR.");
            }
            myOrder = orderDal.UpdateOrder(myOrder, id);
            Console.WriteLine($"Updated !!!");
        }
        public static void CreateOrder(OrdersDAL orderDal)
        {
            Console.WriteLine("Creating New order");
            Console.WriteLine("Input order name: ");
            string orderName = Console.ReadLine();

            OrdersDTO myOrder = new OrdersDTO
            {
                OrderName = orderName
            };

            try
            {
                myOrder = orderDal.CreateOrder(myOrder);
                Console.WriteLine($"New order id is {myOrder.OrderID}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error.");
            }
        }

        public static void GetAllOrders(OrdersDAL orderDal)
        {
            var order = orderDal.GetAllOrders();
            Console.WriteLine("Orders:");
            foreach (var c in order)
            {
                Console.WriteLine($" {c.OrderID,7} |  {c.OrderName,25} |    {c.Price,7} |{c.RowInsertTime,15} | ");
            }
        }
    }
}
