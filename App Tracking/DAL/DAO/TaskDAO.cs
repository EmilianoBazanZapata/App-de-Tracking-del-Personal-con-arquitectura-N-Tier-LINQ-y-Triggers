using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class TaskDAO : EmployeeContext
    {
        public static List<STATES> GetTasksStates()
        {
            return db.STATES.ToList();  
        }

        public static void AddTask(TASKS task)
        {
            try
            {
                db.TASKS.InsertOnSubmit(task);
                db.SubmitChanges(); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
