using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BusinessLogic.Interfaces
{
    public interface IAuthManager
    {
        bool Login(string login, string password);
        UsersDTO GetUsersbyLogin(string login);
        UsersDTO GetUsersbyID(int id);
        List<UsersDTO> GetUsers();
    }
}
