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
using System.IO;
namespace App_Tracking
{
    public partial class FrmEmployee : Form
    {
        EmployeeDTO employeeDTO = new EmployeeDTO();
        bool ComboFull = false;
        string filename;
        bool IsUnique = false;

        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            employeeDTO = EmployeeBLL.GetAll();
            cboDepartament.DataSource = employeeDTO.Departaments;
            cboDepartament.DisplayMember = "DEPARTAMENT_NAME";
            cboDepartament.ValueMember = "ID";
            cboPosition.DataSource = employeeDTO.positions;
            cboPosition.DisplayMember = "POSITION_NAME";
            cboPosition.ValueMember = "ID";
            cboDepartament.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            ComboFull = true;
        }

        private void cboDepartament_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboFull)
            {
                int DepartmentID = Convert.ToInt32(cboDepartament.SelectedValue);
                cboPosition.DataSource = employeeDTO.positions.Where(x => x.DEPARTAMENT_ID == DepartmentID).ToList();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                pbEmployee.Load(openFileDialog1.FileName);
                txtImagePath.Text = openFileDialog1.FileName;
                string Unique = Guid.NewGuid().ToString();
                filename += Unique + openFileDialog1.SafeFileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("User Is Empty");
            }
            else if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Password Is Empty");
            }
            else if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Name Is Empty");
            }
            else if (txtSurname.Text.Trim() == "")
            {
                MessageBox.Show("Surname Is Empty");
            }
            else if (txtSalary.Text.Trim() == "")
            {
                MessageBox.Show("Salary Is Empty");
            }
            else if (cboDepartament.SelectedIndex == -1)
            {
                MessageBox.Show("Select A Department");
            }
            else if (cboPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Select A Position");
            }
            else if (EmployeeBLL.IsUnique(Convert.ToInt32(txtUserNo.Text))) 
            {
                MessageBox.Show("This User No Is Used By Another Employee Please Change ");
            }
            else
            {
                USERS emp = new USERS();

                emp.USER_NO = Convert.ToInt32(txtUserNo.Text);
                emp.PASSWORD = txtPassword.Text;
                emp.IS_ADMIN = cbxAdmin.Checked;
                emp.NAME = txtName.Text;
                emp.SURNAME = txtSurname.Text;
                emp.SALARY = Convert.ToInt32(txtSalary.Text);
                emp.DEPARTAMENT_ID = Convert.ToInt32(cboDepartament.SelectedValue);
                emp.POSITION_ID = Convert.ToInt32(cboPosition.SelectedValue);
                emp.ADRESS = txtInformation.Text;
                emp.BIRTH_DAY = dtpBhirtday.Value;
                emp.IMAGE_PATH = filename;
                EmployeeBLL.AddEmployee(emp);
                File.Copy(txtImagePath.Text, @"images\\" + filename);
                MessageBox.Show("Employee Was Added");
                txtUserNo.Clear();
                txtPassword.Clear();
                cbxAdmin.Checked = false;
                txtName.Clear();
                txtSurname.Clear();
                txtSalary.Clear();
                txtInformation.Clear();
                txtImagePath.Clear();
                pbEmployee.Image = null;
                ComboFull = false;
                cboDepartament.SelectedIndex = -1;
                cboPosition.SelectedIndex = -1;
                dtpBhirtday.Value = DateTime.Today;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("User Is Empty");
            }
            else 
            {
                IsUnique = EmployeeBLL.IsUnique(Convert.ToInt32(txtUserNo.Text));
                if (!IsUnique)
                {
                    MessageBox.Show("This User No Is Used By Another Employee Please Change ");
                }
                else 
                {
                    MessageBox.Show("This User No Is Usable");
                }
            }
        }
    }
}
