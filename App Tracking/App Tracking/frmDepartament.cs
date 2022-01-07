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
        public frmDepartament()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartament.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill Name Field");
            }
            else 
            {
                DEPARTAMENTS departament = new DEPARTAMENTS();
                departament.DEPARTAMENT_NAME = txtDepartament.Text;
                BLL.DepartamentBLL.AddDepartament(departament);
                MessageBox.Show("Departament Was Added");
                txtDepartament.Clear();
            }
        }
    }
}