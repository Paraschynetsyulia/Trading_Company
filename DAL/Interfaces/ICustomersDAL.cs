using System.Collections.Generic;
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
        List<CustomersDTO> GetCustomerbyIDOrder(int id);
    }
}
