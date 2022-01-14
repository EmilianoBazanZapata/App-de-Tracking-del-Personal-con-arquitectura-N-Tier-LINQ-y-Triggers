using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.DTO
{
    public class EmployeeDTO
    {
        public List<DEPARTAMENTS> Departaments { get; set; }
        public List<PositionDTO> positions { get; set; }
    }
}
