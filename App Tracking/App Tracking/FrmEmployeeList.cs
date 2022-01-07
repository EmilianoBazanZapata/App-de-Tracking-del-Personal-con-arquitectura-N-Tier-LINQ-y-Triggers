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
    public partial class FrmEmployeeList : Form
    {
        public FrmEmployeeList()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmEmployee frmEmployee = new FrmEmployee();
            this.Hide();    
            frmEmployee.ShowDialog();   
            this.Visible = true;    
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmEmployee frmEmployee = new FrmEmployee();
            this.Hide();
            frmEmployee.ShowDialog();
            this.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
