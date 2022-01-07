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
    }
}
