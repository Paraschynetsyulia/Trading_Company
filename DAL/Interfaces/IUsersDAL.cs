using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
   public interface IUsersDAL
    {
        List<UsersDTO> GetAllUsers();
        UsersDTO GetUserbyID(int userId);
        UsersDTO UpdateUser (UsersDTO user, int id);
        UsersDTO CreateUser(UsersDTO user);
        void DeleteUser(int userId);
        bool Login(string login, string password);
        UsersDTO GetUserbyLogin(string login);
    }
}
