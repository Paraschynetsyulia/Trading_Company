using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Interfaces;
using System.Data.SqlClient;

namespace DAL.ADO
{
    public class CustomersDAL : ICustomersDAL
    {
        private string _connStr;
        public CustomersDAL(string connStr)
        {
            this._connStr = connStr;
        }
        public CustomersDTO CreateCustomer(CustomersDTO customer)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = "INSERT into Customers (CustomerID,FirstName, LastName,Discount) output INSERTED.CustomerID values (@idOrder,@firstName,@lastName,@discount)";

                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@idOrder", customer.OrderID);
                comm.Parameters.AddWithValue("@firstName", customer.FirstName);
                comm.Parameters.AddWithValue("@lastName", customer.LastName);
                comm.Parameters.AddWithValue("@discount", customer.Discount);


                customer.CustomerID = (int)comm.ExecuteScalar();
                conn.Close();

                return customer;

            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "DELETE from Customers WHERE CustomerID = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", customerId);
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public List<CustomersDTO> GetAllCustomers()
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Customers";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                var customer= new List<CustomersDTO>();
                while (reader.Read())
                {
                    customer.Add(new CustomersDTO
                    {
                        CustomerID = (int)reader["CustomerID"],
                        OrderID = (int)reader["OrderID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Discount = (int)reader["Discount"],
                        RowInsertTime = DateTime.Parse(reader["RowInsertTime"].ToString())
                    });
                }
                conn.Close();
                return customer;
            }

        }

        public CustomersDTO GetCustomerbyID(int customerId)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = $"select * from Customers where CustomerID = {customerId}";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                CustomersDTO myCustomer= new CustomersDTO();
                while (reader.Read())
                {
                    myCustomer = new CustomersDTO
                    {
                        CustomerID = (int)reader["CustomerID"],
                    };
                }
                return myCustomer;
            }
        }

        public CustomersDTO UpdateCustomer(CustomersDTO customer, int ID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "UPDATE Customers set  OrderID, FirsName, LastName,Discount = @id_order,@firsn,@lastn,@disc";

                comm.Parameters.Clear();

                comm.Parameters.AddWithValue("@id_order", customer.OrderID);
                comm.Parameters.AddWithValue("@firsn", customer.FirstName);
                comm.Parameters.AddWithValue("@lastn", customer.LastName);
                comm.Parameters.AddWithValue("@disc", customer.Discount);


                conn.Open();

                customer.CustomerID = (int)comm.ExecuteScalar();
                conn.Close();
                return customer;
            }
        }
    }
}
