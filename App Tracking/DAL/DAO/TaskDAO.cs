using DAL.DTO;
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

        public static List<TaskDetailDTO> GetTasks()
        {
            List<TaskDetailDTO> tasklist = new List<TaskDetailDTO>();

            var list = (from t in db.TASKS
                        join s in db.STATES on t.TASK_STATE equals s.ID
                        join e in db.USERS on t.EMPLOYEE_ID equals e.ID
                        join d in db.DEPARTAMENTS on e.DEPARTAMENT_ID equals d.ID
                        join p in db.POSITIONS on e.POSITION_ID equals p.ID
                        select new
                        {
                            TaskID = t.ID,
                            Title = t.TASK_TITLE,
                            Content = t.TASK_CONTENT,
                            StartDate = t.TASK_START,
                            DeliveryDate = t.TASK_DELIVERY_DATE,
                            TaskStateName = s.STATE_NAME,
                            TaskStateId = t.TASK_STATE,
                            UserNo = e.USER_NO,
                            Name = e.NAME,
                            EmployeeId = t.EMPLOYEE_ID,
                            SurName = e.SURNAME,
                            PositionName = p.POSITION_NAME,
                            DepartmentName = d.DEPARTAMENT_NAME,
                            PositionId = p.ID,
                            DepartmentId = d.ID
                        }).OrderBy(x=>x.StartDate).ToList();
            foreach (var item in list)
            {
                TaskDetailDTO dto = new TaskDetailDTO();
                dto.TaskId = item.TaskID;
                dto.Title = item.Title;
                dto.Content = item.Content;
                dto.TaskStartDate = item.StartDate; 
                dto.TaskDeliveryDate = item.DeliveryDate;
                dto.TaskStateName = item.TaskStateName;
                dto.UserNo = item.UserNo;
                dto.Name = item.Name;
                dto.SurName = item.SurName;
                dto.DepartmentName = item.DepartmentName;
                dto.PositionName = item.PositionName;
                dto.PositionID = item.PositionId;
                dto.DepartmentID = item.DepartmentId;
                dto.Id = item.EmployeeId;
                tasklist.Add(dto);
            }
            return tasklist;
        }

        public static void DeleteTask(int id)
        {
            try
            {
                TASKS p = db.TASKS.First(x => x.ID == id);
                db.TASKS.DeleteOnSubmit(p);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void UpdateTask(TASKS update)
        {
            try
            {
                TASKS ts = db.TASKS.First(x=>x.ID == update.ID);
                ts.TASK_TITLE = update.TASK_TITLE;
                ts.TASK_CONTENT = update.TASK_CONTENT;
                ts.TASK_STATE = update.TASK_STATE;
                ts.EMPLOYEE_ID = update.EMPLOYEE_ID;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
