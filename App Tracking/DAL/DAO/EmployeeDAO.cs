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

        public static void UpdateEmployee(POSITIONS p)
        {
            try
            {
                List<USERS> list = db.USERS.Where(x=>x.POSITION_ID == p.ID).ToList();
                foreach (var item in list)
                {
                    item.DEPARTAMENT_ID = (int)p.DEPARTAMENT_ID;
                }
                db.SubmitChanges();
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
                dto.ImagePath = item.ImagePath;
                employeelist.Add(dto);
            }
            return employeelist;
        }

        public static void DeleteEmployee(int id)
        {
            try
            {
                USERS emp = db.USERS.First(x=>x.ID == id);
                db.USERS.DeleteOnSubmit(emp);
                db.SubmitChanges();
                //List<TASKS> tasks = db.TASKS.Where(x => x.EMPLOYEE_ID == id).ToList();
                //db.TASKS.DeleteAllOnSubmit(tasks);
                //db.SubmitChanges();
                //List<PERMISSIONS> permissions = db.PERMISSIONS.Where(x => x.EMPLOYEE_ID == id).ToList();
                //db.PERMISSIONS.DeleteAllOnSubmit(permissions);
                //db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void UpdateEmployee(USERS emp)
        {
            try
            {
                USERS em = db.USERS.First(x => x.ID == emp.ID);
                em.USER_NO = emp.USER_NO;
                em.SURNAME = emp.SURNAME;
                em.NAME = emp.NAME;
                em.PASSWORD = emp.PASSWORD;
                em.IS_ADMIN = emp.IS_ADMIN;
                em.BIRTH_DAY = emp.BIRTH_DAY;
                em.ADRESS = emp.ADRESS;
                em.DEPARTAMENT_ID = emp.DEPARTAMENT_ID;
                em.POSITION_ID = emp.POSITION_ID;
                em.SALARY = emp.SALARY;
                em.IMAGE_PATH = emp.IMAGE_PATH; 
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void UpdateEmployee(int Id, int Amount)
        {
            try
            {
                USERS em = db.USERS.First(x=>x.ID == Id);
                em.SALARY = Amount;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
