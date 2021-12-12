using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public interface ICustomersDAL
    {
        List<CustomersDTO> GetAllCustomers();
        CustomersDTO GetCustomerbyID(int customerId);
        CustomersDTO UpdateCustomer(CustomersDTO customer, int ID);
        CustomersDTO CreateCustomer(CustomersDTO customer);
        void DeleteCustomer(int customerId);
    }
}
