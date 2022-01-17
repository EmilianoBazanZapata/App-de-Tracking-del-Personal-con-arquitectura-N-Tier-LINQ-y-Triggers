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
                        join d in db.DEPARTAMENTS on e.DEPARTAMENT_ID equals d.ID
                        join t in db.POSITIONS on e.POSITION_ID equals t.ID
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
                            DepartmentName = d.DEPARTAMENT_NAME,
                            PositionName = t.POSITION_NAME,
                            Explanation = p.PERMISSION_EXPLANATION,
                            DayAmount = p.PERMISSION_DAY,
                            DepartmentId = e.DEPARTAMENT_ID,
                            PositionId = e.POSITION_ID
                        }).OrderBy(x => x.StartDate).ToList();
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
                dto.DepartmentName = item.DepartmentName;
                dto.PositionName = item.PositionName;
                dto.DepartmentID = item.DepartmentId;
                dto.PositionID = item.PositionId;
                dto.State = item.StateId;
                dto.StateName = item.StateName;
                dto.Explanation = item.Explanation;
                dto.PermissionId = item.PermissionId;
                permissions.Add(dto);
            }
            return permissions;
        }

        public static void UpdatePermissionFrm(int permissionId, int approved)
        {
            try
            {
                PERMISSIONS ps = db.PERMISSIONS.First(x => x.ID == permissionId);
                ps.PERMISSION_STATE = approved;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void UpdatePermission(PERMISSIONS permission)
        {
            try
            {
                PERMISSIONS pr = db.PERMISSIONS.First(x => x.ID == permission.ID);
                pr.PERMISSION_START_DATE = permission.PERMISSION_START_DATE;
                pr.PERMISSION_END_DATE = permission.PERMISSION_END_DATE;
                pr.PERMISSION_EXPLANATION = permission.PERMISSION_EXPLANATION;
                pr.PERMISSION_DAY = permission.PERMISSION_DAY;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
