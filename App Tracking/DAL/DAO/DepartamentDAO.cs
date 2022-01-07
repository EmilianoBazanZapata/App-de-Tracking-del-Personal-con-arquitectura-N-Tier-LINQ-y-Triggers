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
    }
}
