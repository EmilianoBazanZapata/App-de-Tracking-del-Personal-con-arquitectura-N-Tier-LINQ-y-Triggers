using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class SalaryDAO : EmployeeContext
    {
        public static List<MONTHS> GetMonths()
        {
            return db.MONTHS.ToList();
        }

        public static void AddSalary(SALARIES salary)
        {
            try
            {
                db.SALARIES.InsertOnSubmit(salary);
                db.SubmitChanges(); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<SalaryDetailDTO> GetSalaries()
        {
            List<SalaryDetailDTO> salarylist = new List<SalaryDetailDTO>();
            var list = (from s in db.SALARIES
                        join e in db.USERS on s.ID equals e.ID
                        join m in db.MONTHS on s.MONTH_ID equals m.ID
                        join d in db.DEPARTAMENTS on e.DEPARTAMENT_ID equals d.ID
                        join p in db.POSITIONS on e.POSITION_ID equals p.ID
                        select new 
                        {
                            UserNo = e.USER_NO,
                            Name = e.NAME,
                            SurName = e.SURNAME,
                            Amount = s.AMOUNT,
                            Year = s.YEAR,
                            MonthName = m.MONTH_NAME,
                            MonthId = s.MONTH_ID,
                            SalaryId = s.ID,
                            DepartmentId = e.DEPARTAMENT_ID,
                            PositionID = e.POSITION_ID,
                            PositionName = p.POSITION_NAME,
                            DepartmentName = d.DEPARTAMENT_NAME,
                            EmployeeId = s.EMPLOYEE_ID
                        }).OrderBy(x=>x.Year).ToList();
            foreach (var s in list) 
            {
                SalaryDetailDTO dto = new SalaryDetailDTO();
                dto.UserNo = s.UserNo; 
                dto.Name = s.Name;
                dto.SurName = s.SurName;
                dto.EmployeeId = s.EmployeeId;
                dto.SalaryAmount = s.Amount;
                dto.SalaryYear = s.Year;
                dto.MonthName = s.MonthName;
                dto.MonthId = s.MonthId;
                dto.SalaryId = s.SalaryId;
                dto.DepartmentId = s.DepartmentId;
                dto.PositionId = s.PositionID;
                dto.OldSalary = s.Amount;
                dto.DepartmentName = s.DepartmentName;
                dto.PositionName = s.PositionName;
                salarylist.Add(dto);
            }
            return salarylist;
        }

        public static void UpdateSalary(SALARIES salary)
        {
            try
            {
                SALARIES sl = db.SALARIES.First(x=>x.ID == salary.ID);
                sl.AMOUNT = salary.AMOUNT;
                sl.YEAR = salary.YEAR;
                sl.MONTH_ID = salary.MONTH_ID;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
