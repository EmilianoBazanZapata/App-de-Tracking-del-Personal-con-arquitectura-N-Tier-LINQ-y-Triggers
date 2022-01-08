using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
namespace BLL
{
    public class PositionBLL
    {
        public static void AddPosition(POSITIONS position)
        {
            PositionDAO.AddPosition(position);
        }
    }
}
