using BLL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Tracking
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (!UserStatic.IsAdmin)
            {
                EmployeeDTO dto = EmployeeBLL.GetAll();
                EmployeeDetailDTO detail = dto.Detail.First(x=>x.Id == UserStatic.EmployeeId);
                FrmEmployee frm = new FrmEmployee();
                frm.detail = detail;
                frm.IsUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            }
            else 
            {
                FrmEmployeeList frmEmployee = new FrmEmployeeList();
                this.Hide();
                frmEmployee.ShowDialog();
                this.Visible = true;
            }
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            FrmTaskList frmTaskList = new FrmTaskList();
            this.Hide();
            frmTaskList.ShowDialog();
            this.Visible = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            FrmSalaryList frmSalaryList = new FrmSalaryList();
            this.Hide();
            frmSalaryList.ShowDialog();
            this.Visible = true;
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            FrmPermissionList frmPermissionList = new FrmPermissionList();
            this.Hide();
            frmPermissionList.ShowDialog();
            this.Visible = true;
        }

        private void btnDepartament_Click(object sender, EventArgs e)
        {
            FrmDepartamentList frmDepartamentList = new FrmDepartamentList();
            this.Hide();
            frmDepartamentList.ShowDialog();
            this.Visible = true;
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            FrmPositionList frmPositionList = new FrmPositionList();
            this.Hide();
            frmPositionList.ShowDialog();
            this.Visible = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!UserStatic.IsAdmin) 
            {
                btnDepartament.Visible = false;
                btnPosition.Visible = false;
            }
        }
    }
}
