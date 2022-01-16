using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PermissionDAO : EmployeeContext
    {
        public static void AddPermision(PERMISSIONS permission)
        {
            try
            {
                db.PERMISSIONS.InsertOnSubmit(permission);
                db.SubmitChanges(); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
