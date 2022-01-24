using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;

namespace BLL
{
    public class DepartamentBLL
    {
        public static void AddDepartament(DEPARTAMENTS departament)
        {
            DepartamentDAO.AddDepartament(departament);
        }

        public static List<DEPARTAMENTS> GetDepartamentList()
        {
            return DepartamentDAO.GetDepartament();
        }

        public static void UpdateDepartment(DEPARTAMENTS detail)
        {
            DepartamentDAO.UpdateDepartment(detail);
        }

        public static void DeleteDepartment(int Id)
        {
            DepartamentDAO.DeleteDepartment(Id);
        }
    }
}
