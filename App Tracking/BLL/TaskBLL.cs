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
    public class TaskBLL
    {
        public static TaskDTO GetAll()
        {
            TaskDTO taskDTO = new TaskDTO();
            taskDTO.Employees = EmployeeDAO.GetUsers();
            taskDTO.Departaments = DepartamentDAO.GetDepartament();
            taskDTO.Positions = PositionDAO.GetPositions();
            taskDTO.TaskStates = TaskDAO.GetTasksStates();
            taskDTO.Tasks = TaskDAO.GetTasks();
            return taskDTO; 
        }

        public static void AddTask(TASKS task)
        {
            TaskDAO.AddTask(task);
        }

        public static void UpdateTask(TASKS update)
        {
            TaskDAO.UpdateTask(update);
        }
    }
}