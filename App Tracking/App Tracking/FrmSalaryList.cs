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
using DAL.DAO;
using BLL;
using DAL.DTO;

namespace App_Tracking
{
    public partial class FrmSalaryList : Form
    {
        SalaryDTO dto = new SalaryDTO();
        bool ComboFull = false;
        SalaryDetailDTO detail = new SalaryDetailDTO();
        public FrmSalaryList()
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmSalary frmSalary = new FrmSalary();
            this.Hide();
            frmSalary.ShowDialog();
            this.Visible = true;
        }

        private void FrmSalaryList_Load(object sender, EventArgs e)
        {
            dto = SalaryBLL.GetAll();
            dgvSalaryList.DataSource = dto.Salaries;
            dgvSalaryList.Columns[0].Visible = false;
            dgvSalaryList.Columns[1].Visible = false;
            dgvSalaryList.Columns[2].HeaderText = "Name";
            dgvSalaryList.Columns[3].HeaderText = "SurName";
            dgvSalaryList.Columns[4].HeaderText = "Department";
            dgvSalaryList.Columns[5].HeaderText = "Position";
            dgvSalaryList.Columns[6].Visible = false;
            dgvSalaryList.Columns[7].Visible = false;
            dgvSalaryList.Columns[8].HeaderText = "Month";
            dgvSalaryList.Columns[9].HeaderText = "Year";
            dgvSalaryList.Columns[10].Visible = false;
            dgvSalaryList.Columns[11].HeaderText = "Salary";
            dgvSalaryList.Columns[12].Visible = false;
            dgvSalaryList.Columns[13].Visible = false;
            ComboFull = false;
            cboDepartament.DataSource = dto.Departments;
            cboDepartament.DisplayMember = "DEPARTAMENT_NAME";
            cboDepartament.ValueMember = "ID";
            if (dto.Departments.Count > 0) 
            {
                ComboFull = true;
            }
            cboPosition.DataSource = dto.Positions;
            cboPosition.DisplayMember = "POSITION_NAME";
            cboPosition.ValueMember = "ID";
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalaryDetailDTO> list = dto.Salaries;
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
                list = list.Where(x => x.DepartmentId == Convert.ToInt32(cboDepartament.SelectedValue)).ToList();
            }
            if (cboPosition.SelectedIndex != -1)
            {
                list = list.Where(x => x.PositionId == Convert.ToInt32(cboPosition.SelectedValue)).ToList();
            }
            if (txtYear.Text.Trim() != "")
            {
                list = list.Where(x => x.SalaryYear == Convert.ToInt32((txtSurName.Text))).ToList();
            }
            if (cboMonth.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthId == Convert.ToInt32(cboMonth.SelectedValue)).ToList();
            }
            if (txtSalary.Text.Trim() != "") 
            {
                if (rbtMore.Checked)
                {
                    list = list.Where(x=>x.SalaryAmount > Convert.ToInt32(txtSalary.Text)).ToList();
                }
                else if (rbtLess.Checked)
                {
                    list = list.Where(x => x.SalaryAmount < Convert.ToInt32(txtSalary.Text)).ToList();
                }
                else 
                {
                    list = list.Where(x => x.SalaryAmount == Convert.ToInt32(txtSalary.Text)).ToList();
                }
            }
            dgvSalaryList.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtSurName.Clear();
            txtUserNo.Clear();
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            txtYear.Clear();
            cboMonth.SelectedIndex = -1;
            rbtEquals.Checked = false;
            rbtLess.Checked = false;
            rbtMore.Checked = false;
            txtSalary.Clear();
            dgvSalaryList.DataSource = dto.Salaries;
        }

        private void dgvSalaryList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.UserNo = Convert.ToInt32(dgvSalaryList.Rows[e.RowIndex].Cells[1].Value.ToString());
            detail.Name = dgvSalaryList.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.SurName = dgvSalaryList.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.EmployeeId = Convert.ToInt32(dgvSalaryList.Rows[e.RowIndex].Cells[6].Value.ToString());
            detail.SalaryYear = Convert.ToInt32(dgvSalaryList.Rows[e.RowIndex].Cells[9].Value.ToString());
            detail.MonthId = Convert.ToInt32(dgvSalaryList.Rows[e.RowIndex].Cells[10].Value.ToString());
            detail.SalaryAmount = Convert.ToInt32(dgvSalaryList.Rows[e.RowIndex].Cells[11].Value.ToString());
            detail.SalaryId = Convert.ToInt32(dgvSalaryList.Rows[e.RowIndex].Cells[12].Value.ToString());
            detail.OldSalary = Convert.ToInt32(dgvSalaryList.Rows[e.RowIndex].Cells[13].Value.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.SalaryId == 0)
            {
                MessageBox.Show("Please Select A Salary From Table");
            }
            else 
            {
                FrmSalary frm = new FrmSalary();
                frm.IsUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
            }
        }
    }
}