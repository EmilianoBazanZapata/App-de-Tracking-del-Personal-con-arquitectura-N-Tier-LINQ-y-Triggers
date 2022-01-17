using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;
using DAL.DTO;

namespace BLL
{
    public class PermissionBLL
    {
        public static void AddPermission(PERMISSIONS permission)
        {
            PermissionDAO.AddPermision(permission);
        }

        public static PermissionDTO GetAll()
        {
            PermissionDTO dto = new PermissionDTO();
            dto.Departments = DepartamentDAO.GetDepartament();
            dto.Positions = PositionDAO.GetPositions();
            dto.States = PermissionDAO.GetStates();
            dto.Permissions = PermissionDAO.GetPermissions();
            return dto;
        }

        public static void UpdatePermission(PERMISSIONS permission)
        {
            PermissionDAO.UpdatePermission(permission);
        }

        public static void UpdatePermissionFrm(int permissionId, int approved)
        {
            PermissionDAO.UpdatePermissionFrm(permissionId,approved);
        }
    }
}
