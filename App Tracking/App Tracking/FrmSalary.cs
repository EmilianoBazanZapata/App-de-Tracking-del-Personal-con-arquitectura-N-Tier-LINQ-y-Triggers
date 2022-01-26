using BLL;
using DAL;
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
    public partial class FrmSalary : Form
    {
        SalaryDTO dto = new SalaryDTO();
        bool ComboFull = false;
        SALARIES Salary = new SALARIES();
        public SalaryDetailDTO detail= new SalaryDetailDTO();
        public bool IsUpdate = false;
        bool Control = false;
        int OldSalary = 0;
        public FrmSalary()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }
        private void FrmSalary_Load(object sender, EventArgs e)
        {
            dto = SalaryBLL.GetAll();
            dgvSalaryList.DataSource = dto.Employees;
            ComboFull = false;
            cboMonth.DataSource = dto.Months;
            cboMonth.DisplayMember = "MONTH_NAME";
            cboMonth.ValueMember = "ID";
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            cboMonth.SelectedIndex = -1;
            cboDepartament.DataSource = dto.Departments;
            cboDepartament.DisplayMember = "DEPARTAMENT_NAME";
            cboDepartament.ValueMember = "ID";
            cboPosition.DataSource = dto.Positions;
            cboPosition.DisplayMember = "POSITION_NAME";
            cboPosition.ValueMember = "ID";
            if (dto.Departments.Count > 0)
            {
                ComboFull = true;
            }
            if (!IsUpdate)
            {
                dgvSalaryList.Columns[0].Visible = false;
                dgvSalaryList.Columns[1].HeaderText = "UserNo";
                dgvSalaryList.Columns[2].HeaderText = "Name";
                dgvSalaryList.Columns[3].HeaderText = "SurName";
                dgvSalaryList.Columns[4].HeaderText = "Department";
                dgvSalaryList.Columns[5].HeaderText = "Position";
                dgvSalaryList.Columns[6].Visible = false;
                dgvSalaryList.Columns[7].Visible = false;
                dgvSalaryList.Columns[8].Visible = false;
                dgvSalaryList.Columns[9].Visible = false;
                dgvSalaryList.Columns[10].Visible = false;
                dgvSalaryList.Columns[11].Visible = false;
                dgvSalaryList.Columns[12].Visible = false;
                dgvSalaryList.Columns[13].Visible = false;
            }
            else if (IsUpdate) 
            {
                dgvSalaryList.Visible = false;
                txtName.Text = detail.Name;
                txtSalary.Text = detail.SalaryAmount.ToString();
                txtLastname.Text = detail.SurName;
                txtYear.Text = detail.SalaryYear.ToString();
                cboMonth.SelectedValue = detail.MonthId;
            }

        }
        private void dgvSalaryList_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            txtUserNo.Text = dgvSalaryList.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dgvSalaryList.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtLastname.Text = dgvSalaryList.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtYear.Text = DateTime.Today.Year.ToString();
            Salary.EMPLOYEE_ID = Convert.ToInt32(dgvSalaryList.Rows[e.RowIndex].Cells[0].Value);
            OldSalary = Convert.ToInt32(dgvSalaryList.Rows[e.RowIndex].Cells[9].Value);
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtYear.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill The Year");
            }
            else if (txtSalary.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill The Salary");
            }
            else if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Select An Employee From Table");
            }
            else if (cboMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select A Month");
            }
            else
            {
                if (!IsUpdate)
                {
                    Salary.YEAR = Convert.ToInt32(txtYear.Text);
                    Salary.MONTH_ID = Convert.ToInt32(cboMonth.SelectedValue);
                    Salary.AMOUNT = Convert.ToInt32(txtSalary.Text);
                    if (Salary.AMOUNT > OldSalary)
                    {
                        Control = true;
                    }
                    SalaryBLL.AddSalary(Salary, Control);
                    MessageBox.Show("Salary Was Added");
                    txtSalary.Text = "";
                    txtYear.Text = DateTime.Today.Year.ToString();
                    cboMonth.SelectedIndex = -1;
                }
                else if (IsUpdate)
                {
                    DialogResult result = MessageBox.Show("Are You Sure?", "title", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == result)
                    {
                        SALARIES Salary = new SALARIES();
                        Salary.ID = detail.SalaryId;
                        Salary.EMPLOYEE_ID = detail.EmployeeId;
                        Salary.YEAR = Convert.ToInt32(txtYear.Text);
                        Salary.MONTH_ID = Convert.ToInt32(cboMonth.SelectedValue);
                        Salary.AMOUNT = Convert.ToInt32(txtSalary.Text);
                        if (Salary.AMOUNT > detail.OldSalary)
                        {
                            Control = true;
                        }
                        SalaryBLL.UpdateSalary(Salary, Control);
                        MessageBox.Show("Salary Was Updated");
                        this.Close();
                    }
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}