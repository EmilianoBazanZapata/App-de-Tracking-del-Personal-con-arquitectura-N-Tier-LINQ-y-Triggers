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
    public partial class FrmPositionList : Form
    {
        public FrmPositionList()
        {
            InitializeComponent();
        }
        List<PositionDTO> PositionList = new List<PositionDTO>();
        PositionDTO detail = new PositionDTO();
        private void FrmPositionList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dgvPositionList.Columns[0].HeaderText = "Departament Name";
            dgvPositionList.Columns[1].Visible = false;
            dgvPositionList.Columns[2].HeaderText = "Position Name";
            dgvPositionList.Columns[3].Visible = false;
            dgvPositionList.Columns[4].Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmPosition frmPosition = new FrmPosition();
            this.Hide();
            frmPosition.ShowDialog();
            this.Visible = true;
            FillGrid();
        }
        private void FillGrid() 
        {
            PositionList = PositionBLL.GetPositions();
            dgvPositionList.DataSource = PositionList;
        }

        private void dgvPositionList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dgvPositionList.Rows[e.RowIndex].Cells[1].Value.ToString());
            detail.POSITION_NAME = dgvPositionList.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.DEPARTAMENT_ID = Convert.ToInt32(dgvPositionList.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
            {
                MessageBox.Show("Please Select A Position From Table");
            }
            else 
            {
                FrmPosition frm = new FrmPosition();
                frm.IsUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                FillGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure To Delete This Position","Warning",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                PositionBLL.DeletePosition(detail.ID);
                MessageBox.Show("Position Was Deleted");
            }
        }
    }
}