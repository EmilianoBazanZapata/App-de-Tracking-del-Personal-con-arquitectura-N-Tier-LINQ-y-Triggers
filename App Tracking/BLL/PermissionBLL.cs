using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DAO;
namespace BLL
{
    public class PermissionBLL
    {
        public static void AddPermission(PERMISSIONS permission)
        {
            PermissionDAO.AddPermision(permission);
        }
    }
}
