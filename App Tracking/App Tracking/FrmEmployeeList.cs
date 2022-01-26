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
using DAL.DAO;
using DAL.DTO;

namespace App_Tracking
{
    public partial class FrmEmployeeList : Form
    {
        EmployeeDTO dto = new EmployeeDTO();
        bool ComboFull = false;
        EmployeeDetailDTO detail = new EmployeeDetailDTO();

        public FrmEmployeeList()
        {
            InitializeComponent();
        }
        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void cboDepartament_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboFull)
            {
                cboPosition.DataSource = dto.positions.Where(x => x.DEPARTAMENT_ID == Convert.ToInt32(cboDepartament.SelectedValue)).ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<EmployeeDetailDTO> list = dto.Detail;
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
            dgvEmployeeList.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtSurName.Text = "";
            txtUserNo.Text = "";
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            dgvEmployeeList.DataSource = dto.Detail;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmEmployee frmEmployee = new FrmEmployee();
            this.Hide();
            frmEmployee.ShowDialog();
            this.Visible = true;
            LoadDataGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.Id == 0)
            {
                MessageBox.Show("Please Select An Employee On Table");
            }
            else
            {
                FrmEmployee frm = new FrmEmployee();
                this.Hide();
                frm.IsUpdate = true;
                frm.detail = detail;
                frm.ShowDialog();
                this.Visible = true;
            }
            LoadDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You To Delete This Employee ?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                EmployeeBLL.DeleteEmployee(detail.Id);
                MessageBox.Show("Employee Was Deleted");
            }
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            dto = EmployeeBLL.GetAll();
            dgvEmployeeList.DataSource = dto.Detail;
            dgvEmployeeList.Columns[0].Visible = false;
            dgvEmployeeList.Columns[1].Visible = false;
            dgvEmployeeList.Columns[2].HeaderText = "Name";
            dgvEmployeeList.Columns[3].HeaderText = "SurName";
            dgvEmployeeList.Columns[4].HeaderText = "Department";
            dgvEmployeeList.Columns[5].HeaderText = "Position";
            dgvEmployeeList.Columns[6].Visible = false;
            dgvEmployeeList.Columns[7].Visible = false;
            dgvEmployeeList.Columns[8].Visible = false;
            dgvEmployeeList.Columns[9].HeaderText = "Salary";
            dgvEmployeeList.Columns[10].Visible = false;
            dgvEmployeeList.Columns[11].Visible = false;
            dgvEmployeeList.Columns[12].HeaderText = "Adress";
            dgvEmployeeList.Columns[13].HeaderText = "Bhirt Day";
            ComboFull = false;
            cboDepartament.DataSource = dto.Departaments;
            cboDepartament.DisplayMember = "DEPARTAMENT_NAME";
            cboDepartament.ValueMember = "ID";
            cboPosition.DataSource = dto.positions;
            cboPosition.DisplayMember = "POSITION_NAME";
            cboPosition.ValueMember = "ID";
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            ComboFull = true;
        }

        private void txtUserNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void dgvEmployeeList_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            detail.Id = Convert.ToInt32(dgvEmployeeList.Rows[e.RowIndex].Cells[0].Value);
            detail.UserNo = Convert.ToInt32(dgvEmployeeList.Rows[e.RowIndex].Cells[1].Value);
            detail.Name = dgvEmployeeList.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.SurName = dgvEmployeeList.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.DepartmentID = Convert.ToInt32(dgvEmployeeList.Rows[e.RowIndex].Cells[6].Value);
            detail.PositionID = Convert.ToInt32(dgvEmployeeList.Rows[e.RowIndex].Cells[7].Value);
            detail.Salary = Convert.ToInt32(dgvEmployeeList.Rows[e.RowIndex].Cells[8].Value);
            detail.Password = dgvEmployeeList.Rows[e.RowIndex].Cells[8].Value.ToString();
            detail.IsAdmin = Convert.ToBoolean(dgvEmployeeList.Rows[e.RowIndex].Cells[10].Value);
            detail.ImagePath = dgvEmployeeList.Rows[e.RowIndex].Cells[11].Value.ToString();
            detail.Adress = dgvEmployeeList.Rows[e.RowIndex].Cells[12].Value.ToString();
            detail.BhirtDay = Convert.ToDateTime(dgvEmployeeList.Rows[e.RowIndex].Cells[13].Value);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}