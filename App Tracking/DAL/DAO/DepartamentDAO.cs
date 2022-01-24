using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class DepartamentDAO : EmployeeContext
    {
        public static void AddDepartament(DEPARTAMENTS departament)
        {
            try
            {
                db.DEPARTAMENTS.InsertOnSubmit(departament);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<DEPARTAMENTS> GetDepartament()
        {
            return db.DEPARTAMENTS.ToList();
        }

        public static void UpdateDepartment(DEPARTAMENTS detail)
        {
            try
            {
                DEPARTAMENTS dp = db.DEPARTAMENTS.First(x=>x.ID == detail.ID);
                dp.DEPARTAMENT_NAME = detail.DEPARTAMENT_NAME;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void DeleteDepartment(int id)
        {
            try
            {
                DEPARTAMENTS d = db.DEPARTAMENTS.First(x=>x.ID == id);
                db.DEPARTAMENTS.DeleteOnSubmit(d);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}