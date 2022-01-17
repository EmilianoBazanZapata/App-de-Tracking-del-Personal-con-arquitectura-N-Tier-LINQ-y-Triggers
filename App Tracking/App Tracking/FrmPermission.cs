using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using DAL.DTO;

namespace App_Tracking
{
    public partial class FrmPermission : Form
    {
        TimeSpan PermissionDay;

        public bool IsUpdate = false;
        public PermissionDetailDTO detail = new PermissionDetailDTO();

        public FrmPermission()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Close();
        }

        private void FrmPermission_Load(object sender, EventArgs e)
        {
            txtUserNo.Text = UserStatic.UserNo.ToString();
            if (IsUpdate == true)
            {
                dtpStartDate.Value = detail.StartDate;
                dtpEndDate.Value = detail.EndDate;
                txtDayAmount.Text = detail.PermissionDayAmount.ToString();
                txtExplication.Text = detail.Explanation.ToString();
                txtUserNo.Text = detail.UserNo.ToString();
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            PermissionDay = dtpEndDate.Value.Date - dtpStartDate.Value.Date;
            txtDayAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            PermissionDay = dtpEndDate.Value.Date - dtpStartDate.Value.Date;
            txtDayAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDayAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Change End Or Start");
            }
            else if (Convert.ToInt32(txtDayAmount.Text) <= 0)
            {
                MessageBox.Show("Permission Day Must Be Bigger Than 0");
            }
            else if (txtExplication.Text.Trim() == "")
            {
                MessageBox.Show("Explination Is Empty");
            }
            else
            {
                PERMISSIONS Permission = new PERMISSIONS();
                if (!IsUpdate)
                {
                    Permission.EMPLOYEE_ID = UserStatic.EmployeeId;
                    Permission.PERMISSION_STATE = 1;
                    Permission.PERMISSION_START_DATE = dtpStartDate.Value.Date;
                    Permission.PERMISSION_END_DATE = dtpEndDate.Value.Date;
                    Permission.PERMISSION_DAY = Convert.ToInt32(txtDayAmount.Text);
                    Permission.PERMISSION_EXPLANATION = txtExplication.Text;
                    PermissionBLL.AddPermission(Permission);
                    MessageBox.Show("Permission Was Added");
                    dtpStartDate.Value = DateTime.Today;
                    dtpEndDate.Value = DateTime.Today;
                    txtExplication.Clear();
                    txtDayAmount.Text = "0";
                }
                else if(IsUpdate)
                {
                    DialogResult reult = MessageBox.Show("Are You Sure","Warning",MessageBoxButtons.YesNo);
                    if (reult == DialogResult.Yes) 
                    {
                        Permission.ID = detail.PermissionId;
                        Permission.PERMISSION_EXPLANATION = txtExplication.Text;
                        Permission.PERMISSION_START_DATE = dtpStartDate.Value;
                        Permission.PERMISSION_END_DATE = dtpEndDate.Value;
                        Permission.PERMISSION_DAY = Convert.ToInt32(txtDayAmount.Text);
                        PermissionBLL.UpdatePermission(Permission);
                        MessageBox.Show("Permission Was Updated");
                        this.Close();
                    }
                }
            }
        }
    }
}
