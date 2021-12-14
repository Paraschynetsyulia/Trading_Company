using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DTO;
using DAL.Interfaces;

namespace BusinessLogic.Concrete
{
    public class CustomersManager : ICustomersManager
    {
        private readonly ICustomersDAL customerDAL;
        private readonly IOrdersDAL orderDAL;
        private readonly IRolesDAL roleDAL;
        public CustomersManager(ICustomersDAL customer, IOrdersDAL order, IRolesDAL role )
        {
            customerDAL = customer;
            orderDAL = order;
            roleDAL = role;
        }
        public CustomersDTO AddCustomer(CustomersDTO customer)
        {
            return customerDAL.CreateCustomer(customer);
        }

        public void DeleteCustomer(int customerID)
        {
            customerDAL.DeleteCustomer(customerID);
        }

        public CustomersDTO GetCustomersbyID(int customerID)
        {
            return customerDAL.GetCustomerbyID(customerID);
        }

        public List<CustomersDTO> GetListCustomers()
        {
            return customerDAL.GetAllCustomers();
        }

        public List<OrdersDTO> GetListOrders()
        {
            return orderDAL.GetAllOrders();
        }

        public List<RolesDTO> GetListRoles()
        {
            return roleDAL.GetAllRoles();
        }

        public List<OrdersDTO> GetSort()
        {
            List<OrdersDTO> price = orderDAL.GetAllOrders().OrderBy(p => p.Price).ToList();
            return price;
        }

        public CustomersDTO UpdateCustomer(CustomersDTO c, int id)
        {
            return customerDAL.UpdateCustomer(c, id);
        }

        public List<CustomersDTO> Search(int id)
        {
            return customerDAL.GetCustomerbyIDOrder(id);
        }
    }
}
