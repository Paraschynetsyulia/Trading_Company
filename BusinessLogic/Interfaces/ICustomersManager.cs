using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BusinessLogic.Interfaces
{
    public interface ICustomersManager
    {
        CustomersDTO AddCustomer(CustomersDTO customer);
        CustomersDTO GetCustomersbyID(int customerID);
        void DeleteCustomer(int customerID);
        CustomersDTO UpdateCustomer(CustomersDTO c, int id);
        List<CustomersDTO> GetListCustomers();
        List<CustomersDTO> Search(int id);
        List<OrdersDTO>GetSort();
        List<RolesDTO> GetListRoles();
        List<OrdersDTO> GetListOrders();
    }
}
