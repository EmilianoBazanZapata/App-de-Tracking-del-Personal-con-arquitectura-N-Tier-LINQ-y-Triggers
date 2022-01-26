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
        public EmployeeDetailDTO detail = new EmployeeDetailDTO();
        public bool IsUpdate = false;
        string ImagePath = "";
        public FrmEmployee()
        {
            InitializeComponent();
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
            if (IsUpdate)
            {
                txtName.Text = detail.Name;
                txtSurname.Text = detail.SurName;
                txtUserNo.Text = Convert.ToString(detail.UserNo);
                txtPassword.Text = detail.Password;
                cbxAdmin.Checked = Convert.ToBoolean(detail.IsAdmin);
                txtInformation.Text = detail.Adress;
                dtpBhirtday.Value = Convert.ToDateTime(detail.BhirtDay);
                cboDepartament.SelectedValue = detail.DepartmentID;
                cboPosition.SelectedValue = detail.PositionID;
                txtSalary.Text = Convert.ToString(detail.Salary);
                ImagePath = Application.StartupPath + "\\images\\" + detail.ImagePath;
                txtImagePath.Text = ImagePath;
                pbEmployee.ImageLocation = ImagePath;
                if (!UserStatic.IsAdmin) 
                {
                    cbxAdmin.Enabled = false;
                    txtUserNo.Enabled = false;
                    txtSalary.Enabled = false;
                    cboDepartament.Enabled = false;
                    cboPosition.Enabled = false;
                }
            }
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

        private void btnSave_Click_1(object sender, EventArgs e)
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
            else
            {
                USERS emp = new USERS();
                if (!IsUpdate)
                {
                    if (!EmployeeBLL.IsUnique(Convert.ToInt32(txtUserNo.Text)))
                    {
                        MessageBox.Show("This User No Is Used By Another Employee Please Change ");
                    }
                    else
                    {
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
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are You Sure?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (txtImagePath.Text != ImagePath)
                        {
                            if (File.Exists(@"images\\" + detail.ImagePath))
                            {
                                File.Delete(@"images\\" + detail.ImagePath);
                            }
                            File.Copy(txtImagePath.Text, @"images\\" + filename);
                            emp.IMAGE_PATH = filename;
                            emp.ID = detail.Id;
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
                            EmployeeBLL.UpdateEmployee(emp);
                            MessageBox.Show("Employee Was Updated");
                        }
                        else
                        {
                            emp.ID = detail.Id;
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
                            emp.IMAGE_PATH = detail.ImagePath;
                            EmployeeBLL.UpdateEmployee(emp);
                            MessageBox.Show("Employee Was Updated");
                        }
                    }
                }
                txtUserNo.Text = "";
                txtPassword.Text = "";
                cbxAdmin.Checked = false;
                txtName.Text = "";
                txtSurname.Text = "";
                txtSalary.Text = "";
                txtInformation.Clear();
                txtImagePath.Text = "";
                pbEmployee.Image = null;
                ComboFull = false;
                cboDepartament.SelectedIndex = -1;
                cboPosition.SelectedIndex = -1;
                dtpBhirtday.Value = DateTime.Today;
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }
    }
}
