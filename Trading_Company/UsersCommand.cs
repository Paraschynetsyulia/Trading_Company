using System;
using DAL.ADO;
using DTO;
using System.Configuration;

namespace Trading_Company
{
   public  class UsersCommand
    {
        public static void CreateUser(UsersDAL userDal)
        {
            string connStr = ConfigurationManager.ConnectionStrings["TraidingCompany(CS)"].ConnectionString;
            var rolesDal = new RolesDAL(connStr);
            Console.WriteLine("Creating new user");
            Console.WriteLine("Select a role: ");
            RolesCommand.GetAllRoles(rolesDal);
            string _roleId = (Console.ReadLine());
            int _roleId2 = Convert.ToInt32(_roleId);
            Console.WriteLine("Input First Name: ");
            string _firstName = Console.ReadLine();
            Console.WriteLine("Input Last Name: ");
            string _lastName = Console.ReadLine();
            Console.WriteLine("Input Login: ");
            string _log = Console.ReadLine();
            Console.WriteLine("Input Password: ");
            string _passw = Console.ReadLine();

            UsersDTO myUser = new UsersDTO
            {
                RoleID = _roleId2,
                FirstName = _firstName,
                LastName = _lastName,
                Login = _log,
                Password = _passw
            };

            try
            {
                myUser = userDal.CreateUser(myUser);
                Console.WriteLine($"New PersonID is {myUser.UserID}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error.");
            }
        }
        public static void DeleteUser(UsersDAL userDal)
        {
            Console.WriteLine("Deleting user");
            Console.WriteLine("Input user id: ");
            string idstr = Console.ReadLine();
            int id = Convert.ToInt32(idstr); 
            userDal.DeleteUser(id);
            Console.WriteLine("Deleted");
        }

        public static void GetAllUsers(UsersDAL userDal)
        {
            var user = userDal.GetAllUsers();
            Console.WriteLine("Users:");
            foreach (var p in user)
            {
                Console.WriteLine($"{p.UserID,7}|{p.RoleID,7}|{p.FirstName,7}|{p.LastName,13}|{p.Login,22}|{p.Password,15}|{p.RowInsertTime,15}| {p.RowUpdateTime,15} |");
            }
        }

        public static void UpdateUser(UsersDAL userDal)
        {
            Console.WriteLine("Updating user");
            Console.WriteLine("Input user id: ");
            string connStr = ConfigurationManager.ConnectionStrings["TraidingCompany(CS)"].ConnectionString;
            var uDal = new UsersDAL(connStr);
            GetAllUsers(userDal);

            string idstr = Console.ReadLine();
            int id = Convert.ToInt32(idstr);

            UsersDTO myUser = userDal.GetUserbyID(id);
            myUser.RowUpdateTime = DateTime.UtcNow;

            if (myUser is null)
            {
                Console.WriteLine("Invalid input!\n");
                return;
            }

            Console.WriteLine(" Updating user:",
            myUser.RoleID,
            myUser.FirstName,
            myUser.LastName,
            myUser.Login,
            myUser.Password
            );
            while (true)
            {
                Console.WriteLine(@"
        1 - update RoleID
        2 - update FirsName
        3 - update LastName
        4 - update Login
        5 - update Password
");

                string m = Console.ReadLine();
                Console.WriteLine("\t");
                switch (m)
                {
                    case "1":
                        myUser.RowUpdateTime = DateTime.UtcNow;
                        Console.WriteLine("Input RolesID: ");
                        var rolDal = new RolesDAL(connStr);
                        RolesCommand.GetAllRoles(rolDal);
                        string idst = Console.ReadLine();
                        int idr = Convert.ToInt32(idstr);
                        myUser.RoleID = idr;
                        myUser = userDal.UpdateUser(myUser, id);
                        Console.WriteLine($"Updated successfully!");
                        break;

                    case "2":
                        Console.WriteLine("Input new First Name: ");
                        myUser.FirstName = Console.ReadLine();
                        myUser.RowUpdateTime = DateTime.UtcNow;
                        myUser =userDal.UpdateUser(myUser, id);
                        Console.WriteLine($"Updated successfully!");
                        break;

                    case "3":
                        Console.WriteLine("Input new Last Name: ");
                        myUser.LastName = Console.ReadLine();
                        myUser.RowUpdateTime = DateTime.UtcNow;
                        myUser = userDal.UpdateUser(myUser, id);
                        Console.WriteLine($"Updated successfully!");
                        break;

                    case "4":
                        Console.WriteLine("Input new Login: ");
                        myUser.Login = Console.ReadLine();
                        myUser.RowUpdateTime = DateTime.UtcNow;
                        myUser = userDal.UpdateUser(myUser, id);
                        Console.WriteLine($"Updated successfully!");
                        break;

                    case "5":
                        Console.WriteLine("Input new Password: ");
                        myUser.RowUpdateTime = DateTime.UtcNow;
                        myUser = userDal.UpdateUser(myUser, id);
                        Console.WriteLine($"Updated successfully!");
                        break;
                    case "0": return;

                }
            }
        }
    }
}
