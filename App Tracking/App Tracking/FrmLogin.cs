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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = General.IsNumber(e);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text.Trim() == "" || txtUserNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please Fill The User Dates");
                }
                else 
                {
                    List<USERS> EmployeeList = EmployeeBLL.getEmployees(Convert.ToInt32(txtUserNo.Text),txtPassword.Text);
                    if (EmployeeList.Count == 0)
                    {
                        MessageBox.Show("Please Control Your Information");
                    }
                    else 
                    {
                        USERS employee = new USERS();
                        employee = EmployeeList.First();
                        UserStatic.EmployeeId = employee.ID;
                        UserStatic.UserNo = employee.USER_NO;
                        UserStatic.IsAdmin = employee.IS_ADMIN;
                        FrmMain frm = new FrmMain();
                        this.Hide();
                        frm.ShowDialog();
                        this.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                Application.Exit();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
