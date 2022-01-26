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
        public bool IsUpdate = false;
        PermissionDetailDTO detail = new PermissionDetailDTO();
        public FrmPermissionList()
        {
            InitializeComponent();
        }
        private void FrmPermissionList_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
            dgvPermissionList.Columns[0].Visible = false;
            dgvPermissionList.Columns[1].Visible = false;
            dgvPermissionList.Columns[2].HeaderText = "Name";
            dgvPermissionList.Columns[3].HeaderText = "SurName";
            dgvPermissionList.Columns[4].HeaderText = "Departmetn Name";
            dgvPermissionList.Columns[5].HeaderText = "Position Name";
            dgvPermissionList.Columns[6].Visible = false;
            dgvPermissionList.Columns[7].Visible = false;
            dgvPermissionList.Columns[8].HeaderText = "Start Date";
            dgvPermissionList.Columns[9].HeaderText = "End Date";
            dgvPermissionList.Columns[10].HeaderText = "Permission Day Amount";
            dgvPermissionList.Columns[11].HeaderText = "State";
            dgvPermissionList.Columns[12].Visible = false;
            dgvPermissionList.Columns[13].HeaderText = "Explanation";
            dgvPermissionList.Columns[14].Visible = false;
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
            if (!UserStatic.IsAdmin) 
            {
                pnlAdmin.Visible = false;
                btnApprove.Visible = false;
                btnDisapprove.Visible = false;
                btnDelete.Visible = false;
            }
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
                list = list.Where(x => x.StartDate < Convert.ToDateTime(dtpFinish.Value) &&
                                     x.StartDate > Convert.ToDateTime(dtpStart.Value)).ToList();
            }
            if (rbDeliveryDate.Checked)
            {
                list = list.Where(x => x.EndDate < Convert.ToDateTime(dtpFinish.Value) &&
                                     x.EndDate > Convert.ToDateTime(dtpStart.Value)).ToList();
            }
            if (cboState.SelectedIndex != -1)
            {
                list = list.Where(x => x.State == Convert.ToInt32(cboState.SelectedValue)).ToList();
            }
            if (txtDayAmount.Text.Trim() != "")
            {
                list = list.Where(x => x.PermissionDayAmount == Convert.ToInt32(txtDayAmount.Text)).ToList();
            }
            dgvPermissionList.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDayAmount.Text = "";
            txtName.Text = "";
            txtSurName.Text = "";
            txtUserNo.Text = "";
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            cboState.SelectedIndex = -1;
            rbStartDate.Checked = false;
            rbDeliveryDate.Checked = false;
            dtpStart.Value = DateTime.Today;
            dtpFinish.Value = DateTime.Today;
            dgvPermissionList.DataSource = dto.Permissions;
        }
        private void dgvPermissionList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.PermissionId = Convert.ToInt32(dgvPermissionList.Rows[e.RowIndex].Cells[0].Value);
            detail.UserNo = Convert.ToInt32(dgvPermissionList.Rows[e.RowIndex].Cells[1].Value);
            detail.StartDate = Convert.ToDateTime(dgvPermissionList.Rows[e.RowIndex].Cells[8].Value);
            detail.EndDate = Convert.ToDateTime(dgvPermissionList.Rows[e.RowIndex].Cells[9].Value);
            detail.PermissionDayAmount = Convert.ToInt32(dgvPermissionList.Rows[e.RowIndex].Cells[10].Value);
            detail.State = Convert.ToInt32(dgvPermissionList.Rows[e.RowIndex].Cells[12].Value);
            detail.Explanation = dgvPermissionList.Rows[e.RowIndex].Cells[13].Value.ToString();
        }
        private void btnNew_Click_1(object sender, EventArgs e)
        {
            FrmPermission frmPermission = new FrmPermission();
            this.Hide();
            frmPermission.ShowDialog();
            this.Visible = true;
            LoadDataGrid();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (detail.PermissionId == 0)
            {
                MessageBox.Show("Please Select A Permission From Table");
            }
            else if (detail.State == PermissionStates.Approved || detail.State == PermissionStates.Disapproved) 
            {
                MessageBox.Show("You Can Not Any Approved Or Disapproved Permission");
            }
            else
            {
                FrmPermission frm = new FrmPermission();
                frm.IsUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            }
            LoadDataGrid();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure To Delete This Permission ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (detail.State == PermissionStates.Approved || detail.State == PermissionStates.Disapproved)
                {
                    MessageBox.Show("You Cannot Delete Approved Or Disapproved Permissions");
                }
                else
                {
                    PermissionBLL.DeletePermission(detail.Id);
                    MessageBox.Show("Permission Was Deleted");
                }
            }
            LoadDataGrid();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApprove_Click_1(object sender, EventArgs e)
        {
            PermissionBLL.UpdatePermissionFrm(detail.PermissionId, PermissionStates.Approved);
            MessageBox.Show("Approved");
            LoadDataGrid();
        }

        private void btnDisapprove_Click_1(object sender, EventArgs e)
        {
            PermissionBLL.UpdatePermissionFrm(detail.PermissionId, PermissionStates.Disapproved);
            MessageBox.Show("Disapproved");
            LoadDataGrid();
        }
        private void LoadDataGrid() 
        {
            dto = PermissionBLL.GetAll();
            if (!UserStatic.IsAdmin) 
            {
                dto.Permissions = dto.Permissions.Where(x=>x.Id == UserStatic.EmployeeId).ToList();
            }
            dgvPermissionList.DataSource = dto.Permissions;
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void txtDayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }
    }
}
