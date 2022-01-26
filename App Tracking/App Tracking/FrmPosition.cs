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

namespace App_Tracking
{
    public partial class FrmPosition : Form
    {
        List<DEPARTAMENTS> DepartamentList = new List<DEPARTAMENTS>();
        public PositionDTO detail = new PositionDTO();
        public bool IsUpdate = false;
        int OldDepartmentId = 0;
        private void FrmPosition_Load(object sender, EventArgs e)
        {
            //cargando el combo box
            DepartamentList = DepartamentBLL.GetDepartamentList();
            cboDepartament.DataSource = DepartamentList;
            cboDepartament.DisplayMember = "DEPARTAMENT_NAME";
            cboDepartament.ValueMember = "ID";
            cboDepartament.SelectedIndex = -1;
            if (IsUpdate)
            {
                txtPosition.Text = detail.POSITION_NAME;
                cboDepartament.SelectedValue = detail.DEPARTAMENT_ID;
                OldDepartmentId = detail.ID;
            }
        }
        public FrmPosition()
        {
            InitializeComponent();
        }
        private void btnSave_Click_1(object sender, EventArgs e)
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
                if (!IsUpdate)
                {
                    POSITIONS position = new POSITIONS();
                    position.POSITION_NAME = txtPosition.Text;
                    position.DEPARTAMENT_ID = Convert.ToInt32(cboDepartament.SelectedValue);
                    PositionBLL.AddPosition(position);
                    MessageBox.Show("Position Was Added");
                    txtPosition.Text = "";
                    cboDepartament.SelectedIndex = -1;
                }
                else
                {
                    POSITIONS p = new POSITIONS();
                    p.ID = detail.ID;
                    p.POSITION_NAME = txtPosition.Text;
                    p.DEPARTAMENT_ID = Convert.ToInt32(cboDepartament.SelectedValue);
                    bool control = false;
                    if (Convert.ToInt32(cboDepartament.SelectedValue) != OldDepartmentId)
                    {
                        control = true;
                        PositionBLL.UpdatePosition(p, control);
                    }
                    else
                    {
                        PositionBLL.UpdatePosition(p, control);
                    }
                    MessageBox.Show("Position Was Updated");
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
