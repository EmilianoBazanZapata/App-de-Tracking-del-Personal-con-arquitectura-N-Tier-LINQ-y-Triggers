using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class EmployeeDAO : EmployeeContext
    {
        public static void AddEmployee(USERS emp)
        {
            try
            {
                db.USERS.InsertOnSubmit(emp);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<USERS> GetUsers(int v)
        {
            try
            {
                return db.USERS.Where(x=>x.ID == v).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<EmployeeDetailDTO> GetUsers()
        {
            List<EmployeeDetailDTO> employeelist = new List<EmployeeDetailDTO>();
            var list = (from e in db.USERS 
                        join d in db.DEPARTAMENTS on e.DEPARTAMENT_ID equals d.ID
                        join p in db.POSITIONS on e.POSITION_ID equals p.ID
                        select new 
                        {
                            UserNo = e.USER_NO,
                            Name = e.NAME,
                            SurName = e.SURNAME,
                            EmployeeID = e.ID,
                            Password = e.PASSWORD,
                            DepatmentName = d.DEPARTAMENT_NAME,
                            PositionName = p.POSITION_NAME,
                            DepartmentID = d.ID,
                            PositionID = p.ID,
                            IsAdmin = e.IS_ADMIN,
                            Salary = e.SALARY,
                            ImagePath = e.IMAGE_PATH,
                            BirthDay = e.BIRTH_DAY,
                            Adress = e.ADRESS
                        }).OrderBy(x=>x.UserNo).ToList();
            foreach (var item in list)
            {
                EmployeeDetailDTO dto = new EmployeeDetailDTO();
                dto.Name = item.Name;
                dto.SurName = item.SurName;
                dto.UserNo = item.UserNo;
                dto.Id = item.EmployeeID;
                dto.Password = item.Password;
                dto.DepartmentID = item.DepartmentID;
                dto.DepartmentName = item.DepatmentName;
                dto.PositionID = item.PositionID;
                dto.PositionName = item.PositionName;
                dto.IsAdmin = item.IsAdmin;
                dto.Salary = item.Salary;
                dto.BhirtDay = item.BirthDay;
                dto.Adress = item.Adress;
                employeelist.Add(dto);
            }
            return employeelist;
        }

        public static List<USERS> GetEmployees(int v, string text)
        {
            try
            {
                List<USERS> list = db.USERS.Where(x=>x.USER_NO == v && x.PASSWORD == text).ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
