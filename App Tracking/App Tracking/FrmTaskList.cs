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
using DAL.DAO;
using DAL.DTO;

namespace App_Tracking
{
    public partial class FrmTaskList : Form
    {
        TaskDTO dto = new TaskDTO();
        TaskDetailDTO detail = new TaskDetailDTO();
        
        public FrmTaskList()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }
        private void FrmTaskList_Load(object sender, EventArgs e)
        {
            //pnlAdmin.Hide();
            dto = TaskBLL.GetAll();
            if (!UserStatic.IsAdmin)
            {
                dto.Tasks = dto.Tasks.Where(x => x.Id == UserStatic.EmployeeId).ToList();
            }
                dgvTaskList.DataSource = dto.Tasks;
            dgvTaskList.Columns[0].Visible = false;
            dgvTaskList.Columns[1].Visible = false;
            dgvTaskList.Columns[2].HeaderText = "Name";
            dgvTaskList.Columns[3].HeaderText = "SurName";
            dgvTaskList.Columns[4].HeaderText = "Department";
            dgvTaskList.Columns[5].HeaderText = "Position";
            dgvTaskList.Columns[6].Visible = false;
            dgvTaskList.Columns[7].Visible = false;
            dgvTaskList.Columns[8].Visible = false;
            cboTaskState.DataSource = dto.TaskStates;
                cboTaskState.DisplayMember = "STATE_NAME";
                cboTaskState.ValueMember = "ID";
                cboDepartament.SelectedIndex = -1;
            if (!UserStatic.IsAdmin) 
            {
                btnNew.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                pnlAdmin.Visible = false;
                btnApprove.Text = "Delivery";
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<TaskDetailDTO> list = dto.Tasks;
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
            if (rbtStartDate.Checked) 
            {
                list = list.Where(x => x.TaskStartDate > Convert.ToDateTime(dtpStart.Value) && x.TaskStartDate < Convert.ToDateTime(dtpFinish.Value)).ToList();
            }
            if (rbtDeliveryDate.Checked)
            {
                list = list.Where(x => x.TaskDeliveryDate > Convert.ToDateTime(dtpStart.Value) && x.TaskDeliveryDate < Convert.ToDateTime(dtpFinish.Value)).ToList();
            }
            if(cboTaskState.SelectedIndex != -1) 
            {
                list = list.Where(x=>x.TaskId == Convert.ToInt32(cboTaskState.SelectedValue)).ToList();
            }
            dgvTaskList.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtSurName.Text = "";
            txtUserNo.Text = "";
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            dtpStart.Value = DateTime.Today;
            dtpFinish.Value = DateTime.Today;
            cboTaskState.SelectedIndex = -1;
            rbtDeliveryDate.Checked = false;
            rbtStartDate.Checked = false;
            dgvTaskList.DataSource = dto.Tasks;
        }
        private void dgvTaskList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.Id = Convert.ToInt32(dgvTaskList.Rows[e.RowIndex].Cells[0].Value.ToString());
            detail.UserNo = Convert.ToInt32(dgvTaskList.Rows[e.RowIndex].Cells[1].Value.ToString());
            detail.Name = dgvTaskList.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.SurName = dgvTaskList.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.TaskId = Convert.ToInt32(dgvTaskList.Rows[e.RowIndex].Cells[8].Value.ToString());
            detail.Title = dgvTaskList.Rows[e.RowIndex].Cells[9].Value.ToString();
            detail.Content = dgvTaskList.Rows[e.RowIndex].Cells[10].Value.ToString();
            detail.TaskStartDate = Convert.ToDateTime(dgvTaskList.Rows[e.RowIndex].Cells[13].Value);
            detail.TaskDeliveryDate = Convert.ToDateTime(dgvTaskList.Rows[e.RowIndex].Cells[14].Value);
        }


        private void btnApprove_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            FrmTask frmTask = new FrmTask();
            this.Hide();
            frmTask.ShowDialog();
            this.Visible = true;
            LoadDataGrid();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (detail.TaskId == 0)
            {
                MessageBox.Show("Please Select A Task On Table");
            }
            else
            {
                FrmTask frm = new FrmTask();
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
            DialogResult result = MessageBox.Show("Are You Sure To Delete This Task ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                TaskBLL.DeleteTask(detail.Id);
                MessageBox.Show("Task Was Deleted");
                LoadDataGrid();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadDataGrid() 
        {
            dto = TaskBLL.GetAll();
            dgvTaskList.DataSource = dto.Tasks;
            dgvTaskList.Columns[0].Visible = false;
            dgvTaskList.Columns[1].Visible = false;
            dgvTaskList.Columns[2].HeaderText = "Name";
            dgvTaskList.Columns[3].HeaderText = "SurName";
            dgvTaskList.Columns[4].HeaderText = "Department";
            dgvTaskList.Columns[5].HeaderText = "Position";
            dgvTaskList.Columns[6].Visible = false;
            dgvTaskList.Columns[7].Visible = false;
            dgvTaskList.Columns[8].Visible = false;
            cboTaskState.DataSource = dto.TaskStates;
            cboTaskState.DisplayMember = "STATE_NAME";
            cboTaskState.ValueMember = "ID";
            cboDepartament.SelectedIndex = -1;
        }

        private void btnApprove_Click_1(object sender, EventArgs e)
        {
            if (UserStatic.IsAdmin && detail.TaskStateId == TaskStates.OnEmployee && detail.Id != UserStatic.EmployeeId)
            {
                MessageBox.Show("Before Approve A Task Employee Have To Delivery Task");
            }
            else if (UserStatic.IsAdmin && detail.TaskStateId == TaskStates.Approved)
            {
                MessageBox.Show("This Task Is Ready Approved");
            }
            else if (!UserStatic.IsAdmin && detail.TaskStateId == TaskStates.Delivered)
            {
                MessageBox.Show("This Task Is Ready Delivered");
            }
            else if (!UserStatic.IsAdmin && detail.TaskStateId == TaskStates.Approved)
            {
                MessageBox.Show("This Task Is Ready Approved");
            }
            else 
            {
                TaskBLL.ApproveTask(detail.TaskId,UserStatic.IsAdmin);
                MessageBox.Show("Task Was Updated");
                LoadDataGrid();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.ExcelExport(dgvTaskList);
        }
    }
}
