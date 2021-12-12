using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
   public interface IOrdersDAL
    {
        List<OrdersDTO> GetAllOrders();
        OrdersDTO GetOrderbyID(int orderId);
        OrdersDTO UpdateOrder(OrdersDTO order, int ID);
        OrdersDTO CreateOrder(OrdersDTO order);
        void DeleteOrder(int orderId);
    }
}
