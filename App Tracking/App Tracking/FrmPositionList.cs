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
    }
}