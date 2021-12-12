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
    public class UsersDAL : IUsersDAL
    {
        private string _connStr;
        public UsersDAL(string connStr)
        {
            this._connStr = connStr;
        }

        public UsersDTO CreateUser(UsersDTO user)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = "INSERT into Users (UserID,FirstName, LastName,Login,Password) output INSERTED.UserID values (@idRole,@firstName,@lastName,@log,@passw)";

                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@idRole", user.RoleID);
                comm.Parameters.AddWithValue("@firstName", user.FirstName);
                comm.Parameters.AddWithValue("@lastName", user.LastName);
                comm.Parameters.AddWithValue("@log", user.Login);
                comm.Parameters.AddWithValue("@passw", user.Password);


                user.UserID = (int)comm.ExecuteScalar();
                conn.Close();

                return user;

            }
        }
        public void DeleteUser(int userId)
        {
                using (SqlConnection conn = new SqlConnection(this._connStr))
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "DELETE from Users WHERE UserID = @id";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@id", userId);
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
        }

        public List<UsersDTO> GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Users";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                var user = new List<UsersDTO>();
                while (reader.Read())
                {
                    user.Add(new UsersDTO
                    {
                        UserID = (int)reader["UserID"],
                        RoleID = (int)reader["RoleID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Login = reader["Login"].ToString(),
                        Password = reader["Password"].ToString(),
                        RowInsertTime = DateTime.Parse(reader["RowInsertTime"].ToString())
                    });
                }
                conn.Close();
                return user;
            }
        }

        public UsersDTO GetUserbyID(int userId)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = $"select * from Users where UserID = {userId}";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                UsersDTO myUser = new UsersDTO();
                while (reader.Read())
                {
                    myUser = new UsersDTO
                    {
                        UserID = (int)reader["UserID"],
                    };
                }
                return myUser;
            }
        }

        public UsersDTO UpdateUser(UsersDTO user, int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "UPDATE Users set  RoleID, FirsName, LastName,Login,Password = @id_rol,@firsn,@lastn,@log,@passw";

                comm.Parameters.Clear();

                comm.Parameters.AddWithValue("@id_rol", user.RoleID);
                comm.Parameters.AddWithValue("@firsn", user.FirstName);
                comm.Parameters.AddWithValue("@lastn", user.LastName);
                comm.Parameters.AddWithValue("@log", user.Login);
                comm.Parameters.AddWithValue("@passw", user.Password);


                conn.Open();

                user.UserID = (int)comm.ExecuteScalar();
                conn.Close();
                return user;
            }
        }
    }
}
