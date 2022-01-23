using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PositionDAO : EmployeeContext
    {
        public static void AddPosition(POSITIONS position)
        {
            try
            {
                db.POSITIONS.InsertOnSubmit(position);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<PositionDTO> GetPositions()
        {
            try
            {
                //hago un select de las dos tablas para ver la informacion
                var list = (from p in db.POSITIONS
                            join dp in db.DEPARTAMENTS on p.DEPARTAMENT_ID equals dp.ID
                            select new
                            {
                                positionID = p.ID,
                                positionName = p.POSITION_NAME,
                                departmenName = dp.DEPARTAMENT_NAME,
                                departmenID = dp.ID
                            }).OrderBy(x => x.positionID).ToList();
                List<PositionDTO> positionList = new List<PositionDTO>();
                foreach (var item in list) 
                {
                    PositionDTO position = new PositionDTO();
                    position.ID = item.positionID;
                    position.POSITION_NAME= item.positionName;
                    position.DepartmentName = item.departmenName;
                    position.DEPARTAMENT_ID = item.departmenID;
                    positionList.Add(position);
                }  
                return positionList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void UpdatePosition(POSITIONS ps)
        {
            try
            {
                POSITIONS p = db.POSITIONS.First(x=>x.ID == ps.ID);
                p.POSITION_NAME = ps.POSITION_NAME;
                p.DEPARTAMENT_ID = ps.DEPARTAMENT_ID;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
