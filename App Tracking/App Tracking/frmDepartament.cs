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

namespace App_Tracking
{
    public partial class frmDepartament : Form
    {
        public bool IsUpdate = false;
        public DEPARTAMENTS detail = new DEPARTAMENTS();
        public int Id = 0;
        public frmDepartament()
        {
            InitializeComponent();
        }
        private void frmDepartament_Load(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                txtDepartament.Text = detail.DEPARTAMENT_NAME;
                Id = detail.ID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartament.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill Name Field");
            }
            else
            {
                if (!IsUpdate)
                {
                    DEPARTAMENTS departament = new DEPARTAMENTS();
                    departament.DEPARTAMENT_NAME = txtDepartament.Text;
                    BLL.DepartamentBLL.AddDepartament(departament);
                    MessageBox.Show("Departament Was Added");
                    txtDepartament.Text = "";
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are You Sure ?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        detail.ID = Id;
                        detail.DEPARTAMENT_NAME = txtDepartament.Text;
                        DepartamentBLL.UpdateDepartment(detail);
                        MessageBox.Show("Department Was Updated");
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