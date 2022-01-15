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
        public FrmTaskList()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTaskList_Load(object sender, EventArgs e)
        {
            //pnlAdmin.Hide();   
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
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmTask frmTask = new FrmTask();
            this.Hide();
            frmTask.ShowDialog();
            this.Visible = true;
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
            txtName.Clear();
            txtSurName.Clear();
            txtUserNo.Clear();
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            dtpStart.Value = DateTime.Today;
            dtpFinish.Value = DateTime.Today;
            cboTaskState.SelectedIndex = -1;
            rbtDeliveryDate.Checked = false;
            rbtStartDate.Checked = false;
            dgvTaskList.DataSource = dto.Tasks;
        }
    }
}
