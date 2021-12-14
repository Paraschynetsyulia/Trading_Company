using System;
using System.Collections.Generic;
using DAL.Interfaces;
using BusinessLogic.Interfaces;
using DTO;

namespace BusinessLogic.Concrete
{
    public class AuthManager : IAuthManager
    { 
        private readonly IUsersDAL usersDAL;
        public AuthManager(IUsersDAL usersDAL1)
        {
            usersDAL = usersDAL1;
        }
   
        public List<UsersDTO> GetUsers()
        {
            return usersDAL.GetAllUsers();
        }

        public UsersDTO GetUsersbyID(int id)
        {
            return usersDAL.GetUserbyID(id);
        }

        public UsersDTO GetUsersbyLogin(string login)
        {
            return usersDAL.GetUserbyLogin(login);
        }

        public bool Login(string login, string password)
        {
            return usersDAL.Login(login, password);
        }
        public UsersDTO CreateUser(UsersDTO u)
        {
            return usersDAL.CreateUser(u);
        }
    }
}
