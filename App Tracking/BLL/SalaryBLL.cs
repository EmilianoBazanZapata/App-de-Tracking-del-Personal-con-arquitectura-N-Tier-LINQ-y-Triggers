using DAL;
using DAL.DAO;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SalaryBLL
    {
        public static SalaryDTO GetAll()
        {
            SalaryDTO dto = new SalaryDTO();
            dto.Employees = EmployeeDAO.GetUsers();
            dto.Departments = DepartamentDAO.GetDepartament();
            dto.Positions = PositionDAO.GetPositions();
            dto.Months = SalaryDAO.GetMonths();
            dto.Salaries = SalaryDAO.GetSalaries();
            return dto;
        }

        public static void AddSalary(SALARIES salary,bool Control)
        {
            SalaryDAO.AddSalary(salary);
            if (Control)
            {
                EmployeeDAO.UpdateEmployee(salary.EMPLOYEE_ID, salary.AMOUNT);
            }
        }

        public static void UpdateSalary(SALARIES salary, bool Control)
        {
            SalaryDAO.UpdateSalary(salary);
            if (Control) 
            {
                EmployeeDAO.UpdateEmployee(salary.EMPLOYEE_ID,salary.AMOUNT);
            }
        }
    }
}
