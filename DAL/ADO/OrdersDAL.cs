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
    public class OrdersDAL : IOrdersDAL
    {
        private string _connStr;
        public OrdersDAL(string connStr)
        {
            this._connStr = connStr;
        }
        public OrdersDTO CreateOrder(OrdersDTO order)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = "INSERT INTO Orders(OrderName,Price) output INSERT.OrderID values (@OrderName,@Price)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@OrderName", order.OrderName);
                comm.Parameters.AddWithValue("@Price", order.Price);
                order.OrderID = (int)comm.ExecuteScalar();
                conn.Close();
                return order;
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "DELETE FROM Orders(OrderName,Price) WHERE OrderID= @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", orderId);

                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public List<OrdersDTO> GetAllOrders()
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Orders";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                var order = new List<OrdersDTO>();
                while (reader.Read())
                {
                    order.Add(new OrdersDTO
                    {
                        OrderID = (int)reader["OrderID"],
                        OrderName = reader["OrderName"].ToString(),
                        Price = (int)reader["Price"],
                        RowInsertTime = DateTime.Parse(reader["RowInsertTime"].ToString()),

                    });

                }
                conn.Close();
                return order;
            }
        }

        public OrdersDTO GetOrderbyID(int orderId)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = $"SELECT *FROM Orders WHERE OrderID={orderId}";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                OrdersDTO myOrder = new OrdersDTO();
                while (reader.Read())
                {
                    myOrder = new OrdersDTO
                    {
                        OrderID = (int)reader["OrderID"]
                    };
                }
                return myOrder;
            }
        }

        public OrdersDTO UpdateOrder(OrdersDTO order, int ID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = $"UPDATE Orders set OrderName=@or,Price=@price, RowInsertTime=@rowut WHERE OrderID={ID}";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@or", order.OrderName);
                comm.Parameters.AddWithValue("@rowut", order.RowInsertTime);
                comm.Parameters.AddWithValue("@price", order.Price);
                conn.Open();
                order.OrderID = comm.ExecuteNonQuery();
                conn.Close();
                return order;
            }
        }
    }
}
