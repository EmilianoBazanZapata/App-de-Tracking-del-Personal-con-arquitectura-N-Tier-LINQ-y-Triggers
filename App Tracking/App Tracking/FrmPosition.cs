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
    public partial class FrmPosition : Form
    {
        List<DEPARTAMENTS> DepartamentList = new List<DEPARTAMENTS>();
        private void FrmPosition_Load(object sender, EventArgs e)
        {
            //cargamdo el combo box
            DepartamentList = DepartamentBLL.GetDepartamentList();
            cboDepartament.DataSource = DepartamentList;
            cboDepartament.DisplayMember = "DEPARTAMENT_NAME";
            cboDepartament.ValueMember = "ID";
            cboDepartament.SelectedIndex = -1;
        }
        public FrmPosition()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPosition.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill The Position Name");
            }
            else if (cboDepartament.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Department");
            }
            else
            {
                POSITIONS position = new POSITIONS();
                position.POSITION_NAME = txtPosition.Text;
                position.DEPARTAMENT_ID = Convert.ToInt32(cboDepartament.SelectedValue);
                PositionBLL.AddPosition(position);
                MessageBox.Show("Position Was Added");
                txtPosition.Clear();
                cboDepartament.SelectedIndex = -1;
            }
        }
    }
}
