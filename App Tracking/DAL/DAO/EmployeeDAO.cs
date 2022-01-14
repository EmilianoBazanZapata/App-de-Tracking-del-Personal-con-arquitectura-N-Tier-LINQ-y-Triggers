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
    }
}
