using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.DTO;

namespace App_Tracking
{
    public partial class FrmTask : Form
    {
        TaskDTO dto = new TaskDTO();
        bool ComboFull = false;
        TASKS Task = new TASKS();
        public bool IsUpdate = false;
        public TaskDetailDTO detail = new TaskDetailDTO();
        public FrmTask()
        {
            InitializeComponent();
        }
        private void FrmTask_Load(object sender, EventArgs e)
        {
            dto = TaskBLL.GetAll();
            dgvTaskList.DataSource = dto.Employees;
            dgvTaskList.Columns[0].Visible = false;
            dgvTaskList.Columns[1].Visible = false;
            dgvTaskList.Columns[2].HeaderText = "Name";
            dgvTaskList.Columns[3].HeaderText = "SurName";
            dgvTaskList.Columns[4].Visible = false;
            dgvTaskList.Columns[5].Visible = false;
            dgvTaskList.Columns[6].Visible = false;
            dgvTaskList.Columns[7].Visible = false;
            dgvTaskList.Columns[8].Visible = false;
            dgvTaskList.Columns[9].Visible = false;
            dgvTaskList.Columns[10].Visible = false;
            dgvTaskList.Columns[11].Visible = false;
            dgvTaskList.Columns[12].Visible = false;
            dgvTaskList.Columns[13].Visible = false;
            ComboFull = false;
            cboDepartament.DataSource = dto.Departaments;
            cboDepartament.DisplayMember = "DEPARTAMENT_NAME";
            cboDepartament.ValueMember = "ID";
            cboPosition.DataSource = dto.Positions;
            cboPosition.DisplayMember = "POSITION_NAME";
            cboPosition.ValueMember = "ID";
            cboTaskState.DataSource = dto.TaskStates;
            cboTaskState.DisplayMember = "STATE_NAME";
            cboTaskState.ValueMember = "ID";
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            ComboFull = true;
            if (IsUpdate)
            {
                cboTaskState.Visible = true;
                txtName.Text = detail.Name;
                txtContent.Text = detail.Content;
                txtSurName.Text = detail.SurName;
                txtTitle.Text = detail.Title;
                txtUserNo.Text = detail.UserNo.ToString();
                cboTaskState.DataSource = dto.TaskStates;
                cboTaskState.DisplayMember = "STATE_NAME";
                cboTaskState.ValueMember = "ID";
                cboTaskState.SelectedValue = detail.TaskId;

            }
        }

        private void cboDepartament_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboFull)
            {
                cboPosition.DataSource = dto.Positions.Where(x => x.DEPARTAMENT_ID == Convert.ToInt32(cboDepartament.SelectedValue)).ToList();
                List<EmployeeDetailDTO> list = dto.Employees;
                dgvTaskList.DataSource = list.Where(x => x.DepartmentID == Convert.ToInt32(cboDepartament.SelectedValue)).ToList();
            }
        }

        private void dgvTaskList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtUserNo.Text = dgvTaskList.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dgvTaskList.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurName.Text = dgvTaskList.Rows[e.RowIndex].Cells[3].Value.ToString();
            Task.EMPLOYEE_ID = Convert.ToInt32(dgvTaskList.Rows[e.RowIndex].Cells[0].Value);
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (Task.EMPLOYEE_ID == 0)
            {
                MessageBox.Show("Please Select An Employee On Table");
            }
            else if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Task Title Is Empty");
            }
            else if (txtContent.Text.Trim() == "")
            {
                MessageBox.Show("Task Content Is Empty");
            }
            else
            {
                if (!IsUpdate)
                {
                    Task.TASK_TITLE = txtTitle.Text;
                    Task.TASK_CONTENT = txtContent.Text;
                    Task.TASK_START = DateTime.Today;
                    Task.TASK_STATE = 1;
                    TaskBLL.AddTask(Task);
                    MessageBox.Show("Task Was Added");
                    txtTitle.Text = "";
                    txtContent.Clear();
                    cboDepartament.SelectedIndex = -1;
                    cboPosition.SelectedIndex = -1;
                    Task = new TASKS();
                }
                else if (IsUpdate)
                {
                    DialogResult result = MessageBox.Show("Are You Sure ?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TASKS update = new TASKS();
                        update.ID = detail.TaskId;
                        if (Convert.ToInt32(txtUserNo.Text) != detail.UserNo)
                        {
                            update.EMPLOYEE_ID = Task.EMPLOYEE_ID;
                        }
                        else
                        {
                            update.EMPLOYEE_ID = detail.Id;
                            update.TASK_TITLE = txtTitle.Text;
                            update.TASK_CONTENT = txtContent.Text;
                            update.TASK_STATE = Convert.ToInt32(cboTaskState.SelectedValue);
                            TaskBLL.UpdateTask(update);
                            MessageBox.Show("Task Was Updated");
                            this.Close();
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}