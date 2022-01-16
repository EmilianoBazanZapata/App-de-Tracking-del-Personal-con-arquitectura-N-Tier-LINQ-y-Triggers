using DAL.DAO;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DAL;

namespace BLL
{
    public class EmployeeBLL : EmployeeContext
    {
        public static EmployeeDTO GetAll()
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.Departaments = DepartamentDAO.GetDepartament();
            employeeDTO.positions = PositionDAO.GetPositions();
            employeeDTO.Detail = EmployeeDAO.GetUsers();
            return employeeDTO;
        }

        public static void AddEmployee(USERS emp)
        {
            EmployeeDAO.AddEmployee(emp);
        }

        public static bool IsUnique(int v)
        {
            List<USERS> emp = EmployeeDAO.GetUsers(v);

            if (emp.Count > 0)
            {
                return false;
            }
            else 
            {
                return true;    
            }
        }

        public static List<USERS> getEmployees(int v, string text)
        {
           return EmployeeDAO.GetEmployees(v,text);
        }
    }
}
