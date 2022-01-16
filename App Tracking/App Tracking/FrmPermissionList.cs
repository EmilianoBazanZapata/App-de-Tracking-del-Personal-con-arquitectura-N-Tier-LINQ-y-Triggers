using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.DTO;
using DAL;
using BLL;

namespace App_Tracking
{
    public partial class FrmPermissionList : Form
    {
        PermissionDTO dto = new PermissionDTO();
        bool ComboFull = false;
        public FrmPermissionList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmPermission frmPermission = new FrmPermission();
            this.Hide();
            frmPermission.ShowDialog();
            this.Visible = true;
        }

        private void FrmPermissionList_Load(object sender, EventArgs e)
        {
            dto = PermissionBLL.GetAll();
            dgvPermissionList.DataSource = dto.Permissions;
            dgvPermissionList.Columns[0].Visible = false;
            dgvPermissionList.Columns[1].HeaderText = "User No";
            dgvPermissionList.Columns[2].HeaderText = "Name";
            dgvPermissionList.Columns[3].HeaderText = "SurName";
            dgvPermissionList.Columns[4].Visible = false;
            dgvPermissionList.Columns[5].Visible = false;
            dgvPermissionList.Columns[6].Visible = false;
            dgvPermissionList.Columns[7].Visible = false;
            dgvPermissionList.Columns[8].HeaderText = "Start Date";
            dgvPermissionList.Columns[9].HeaderText = "End Date";
            dgvPermissionList.Columns[10].Visible = false;
            dgvPermissionList.Columns[11].HeaderText = "Day Amount";
            dgvPermissionList.Columns[12].HeaderText = "State";
            dgvPermissionList.Columns[13].Visible = false;
            ComboFull = false;
            cboDepartament.DataSource = dto.Departments;
            cboDepartament.DisplayMember = "DEPARTAMENT_NAME";
            cboDepartament.ValueMember = "ID";
            cboPosition.DataSource = dto.Positions;
            cboPosition.DisplayMember = "POSITION_NAME";
            cboPosition.ValueMember = "ID";
            cboState.DataSource = dto.States;
            cboState.DisplayMember = "STATE_NAME";
            cboState.ValueMember = "ID";
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            cboState.SelectedIndex = -1;
            ComboFull = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<PermissionDetailDTO> list = dto.Permissions;
            if (txtUserNo.Text.Trim() != "")
            {
                list = list.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            }
            if (txtName.Text.Trim() != "")
            {
                list = list.Where(x => x.Name.Contains(txtName.Text)).ToList();
            }
            if (txtSurName.Text.Trim() != "")
            {
                list = list.Where(x => x.SurName.Contains(txtSurName.Text)).ToList();
            }
            if (cboDepartament.SelectedIndex != -1)
            {
                list = list.Where(x => x.DepartmentID == Convert.ToInt32(cboDepartament.SelectedValue)).ToList();
            }
            if (cboPosition.SelectedIndex != -1)
            {
                list = list.Where(x => x.PositionID == Convert.ToInt32(cboPosition.SelectedValue)).ToList();
            }
            if (rbStartDate.Checked) 
            {
                list = list.Where(x=>x.StartDate < Convert.ToDateTime(dtpFinish.Value) && 
                                     x.StartDate > Convert.ToDateTime(dtpStart.Value)).ToList();
            }
            if (rbDeliveryDate.Checked)
            {
                list = list.Where(x => x.EndDate < Convert.ToDateTime(dtpFinish.Value) &&
                                     x.EndDate > Convert.ToDateTime(dtpStart.Value)).ToList();
            }
            if (cboState.SelectedIndex != -1) 
            {
                list = list.Where(x=>x.State == Convert.ToInt32(cboState.SelectedValue)).ToList();
            }
            if (txtDayAmount.Text.Trim()!="")
            {
                list = list.Where(x => x.PermissionDayAmount == Convert.ToInt32(txtDayAmount.Text)).ToList();
            }
            dgvPermissionList.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDayAmount.Clear();
            txtName.Clear();
            txtSurName.Clear();
            txtUserNo.Clear();
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            cboState.SelectedIndex = -1;
            rbStartDate.Checked = false;
            rbDeliveryDate.Checked = false;
            dtpStart.Value = DateTime.Today;
            dtpFinish.Value = DateTime.Today;
            dgvPermissionList.DataSource = dto.Permissions;
        }
    }
}
