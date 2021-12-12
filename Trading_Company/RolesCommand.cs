using System;
using DAL.ADO;
using DTO;

namespace Trading_Company
{
    public class RolesCommand
    {
        public static void DeleteRole(RolesDAL rolesDal){
            Console.WriteLine("_________Delete Role_________");
            Console.WriteLine("Input role id: ");
            string idstr = Console.ReadLine();
            int id = Convert.ToInt32(idstr);
            rolesDal.DeleteRole(id);
            Console.WriteLine("Deleted!!!!!!!!!");
        }
        public static void UpdateRole(RolesDAL rolesDal)
        {
            Console.WriteLine("Input role id: ");
            string idstr = Console.ReadLine();
            int id = Convert.ToInt32(idstr);

            RolesDTO myRole = rolesDal.GetRolebyID(id);

            if (myRole is null)
            {
                Console.WriteLine("Invalid input!\n");
                return;
            }

            Console.WriteLine("Updating role:",
            myRole.RoleName);
            try
            {
                myRole.RowUpdateTime = DateTime.UtcNow;
                Console.WriteLine("Input new role: ");
                myRole.RoleName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("ERROR.");
            }
            myRole = rolesDal.UpdateRole(myRole, id);
            Console.WriteLine($"Updated !!!");
        }
        public static void CreateRole(RolesDAL roleDal)
        {
            Console.WriteLine("Creating New role");
            Console.WriteLine("Input role name: ");
            string roleName = Console.ReadLine();

            RolesDTO myRole = new RolesDTO
            {
                RoleName = roleName
            };

            try
            {
                myRole = roleDal.CreateRole(myRole);
                Console.WriteLine($"New role id is {myRole.RoleID}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error.");
            }
        }

        public static void GetAllRoles(RolesDAL roleDal)
        {
            var role = roleDal.GetAllRoles();
            Console.WriteLine("Category:");
            foreach (var c in role)
            {
                Console.WriteLine($" {c.RoleID,7} |  {c.RoleName,25} |  {c.RowInsertTime,15} | ");
            }
        }
    }
}
