using DAL.DTO;
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

        public static List<STATETS_PERMISSIONS> GetStates()
        {
            return db.STATETS_PERMISSIONS.ToList(); 
        }

        public static List<PermissionDetailDTO> GetPermissions()
        {
            List<PermissionDetailDTO> permissions = new List<PermissionDetailDTO>();
            var list = (from p in db.PERMISSIONS
                        join s in db.STATETS_PERMISSIONS on p.PERMISSION_STATE equals s.ID
                        join e in db.USERS on p.EMPLOYEE_ID equals e.ID
                        select new 
                        {
                            UserNo = e.USER_NO,
                            Name = e.NAME,
                            SurName = e.SURNAME,
                            StateName = s.STATE_NAME,
                            StateId = p.PERMISSION_STATE,
                            StartDate = p.PERMISSION_START_DATE,
                            EndDate = p.PERMISSION_END_DATE,
                            EmployeeId = p.EMPLOYEE_ID,
                            PermissionId = p.ID,
                            Explanation = p.PERMISSION_EXPLANATION,
                            DayAmount = p.PERMISSION_DAY,
                            DepartmentId = e.DEPARTAMENT_ID,
                            PositionId = e.POSITION_ID
                        }).OrderBy(x=>x.StartDate).ToList();
            foreach (var item in list)
            {
                PermissionDetailDTO dto = new PermissionDetailDTO();
                dto.UserNo = item.UserNo;
                dto.Name = item.Name;
                dto.SurName = item.SurName;
                dto.Id = item.EmployeeId;
                dto.StartDate = item.StartDate;
                dto.PermissionDayAmount = item.DayAmount;
                dto.EndDate = item.EndDate;
                dto.DepartmentID = item.DepartmentId;
                dto.PositionID = item.PositionId;
                dto.State = item.StateId;
                dto.StateName = item.StateName;
                dto.Explanation = item.Explanation;
                permissions.Add(dto);
            }
            return permissions;
        }
    }
}
