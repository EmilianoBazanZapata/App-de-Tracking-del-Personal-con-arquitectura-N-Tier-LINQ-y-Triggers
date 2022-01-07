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
    public partial class FrmTaskList : Form
    {
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
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmTask frmTask = new FrmTask();
            this.Hide();
            frmTask.ShowDialog();
            this.Visible = true;
        }
    }
}
