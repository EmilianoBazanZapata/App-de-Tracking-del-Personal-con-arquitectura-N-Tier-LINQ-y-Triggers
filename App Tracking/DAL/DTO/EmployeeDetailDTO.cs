using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class EmployeeDetailDTO
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public bool IsAdmin { get; set; }
        public string ImagePath { get; set; }
        public string Adress { get; set; }
        public DateTime? BhirtDay { get; set; }
    }
}
