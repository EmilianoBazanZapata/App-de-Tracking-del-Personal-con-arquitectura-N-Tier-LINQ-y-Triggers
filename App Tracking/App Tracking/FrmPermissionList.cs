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
    public partial class FrmPermissionList : Form
    {
        public FrmPermissionList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmPermission frmPermission = new FrmPermission();
            this.Hide();
            frmPermission.ShowDialog();
            this.Visible = true;
        }
    }
}
