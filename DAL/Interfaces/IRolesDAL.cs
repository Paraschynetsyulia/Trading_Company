using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public interface IRolesDAL
    {
        List<RolesDTO> GetAllRoles();
        RolesDTO GetRolebyID(int roleId);
        RolesDTO UpdateRole(RolesDTO role, int ID);
        RolesDTO CreateRole(RolesDTO role);
        void DeleteRole(int roleId);
    }
}
