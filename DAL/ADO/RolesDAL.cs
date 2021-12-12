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
    public class RolesDAL : IRolesDAL
    {
        private string _connStr;
        public RolesDAL(string connStr)
        {
            this._connStr = connStr;
        }
        public RolesDTO CreateRole(RolesDTO role)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = "INSERT INTO Roles(RoleName) output INSERT.RoleID values (@RoleName)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@RoleName", role.RoleName);
                role.RoleID = (int)comm.ExecuteScalar();
                conn.Close();
                return role;
            }
        }

        public void DeleteRole(int roleId)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "DELETE FROM Roles(RoleName) WHERE RoleID= @ID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ID", roleId);

                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public List<RolesDTO> GetAllRoles()
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Roles";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                var roles = new List<RolesDTO>();
                while (reader.Read())
                {
                    roles.Add(new RolesDTO
                    {
                        RoleID = (int)reader["RoleID"],
                        RoleName = reader["RoleName"].ToString(),
                        RowInsertTime = DateTime.Parse(reader["RowInsertTime"].ToString()),

                    });

                }
                conn.Close();
                return roles;
            }

        }

        public RolesDTO GetRolebyID(int roleId)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = $"SELECT *FROM Roles WHERE RoleID={roleId}";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                RolesDTO myRole = new RolesDTO();
                while (reader.Read())
                {
                    myRole = new RolesDTO
                    {
                        RoleID = (int)reader["RoleID"]
                    };
                }
                return myRole;
            }
        }

        public RolesDTO UpdateRole(RolesDTO role, int ID)
        {
            using (SqlConnection conn = new SqlConnection(this._connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = $"UPDATE Roles set RoleName=@rol,RowUpdateTime=@rowut WHERE RoleID={ID}";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@rol", role.RoleName);
                comm.Parameters.AddWithValue("@rowut", role.RowUpdateTime);
                conn.Open();
                role.RoleID = comm.ExecuteNonQuery();
                conn.Close();
                return role;
            }
        }
    }
}
