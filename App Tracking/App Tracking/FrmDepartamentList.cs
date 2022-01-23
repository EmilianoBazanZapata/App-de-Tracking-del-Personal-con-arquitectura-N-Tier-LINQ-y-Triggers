﻿using System;
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
    public partial class FrmDepartamentList : Form
    {
        public DEPARTAMENTS detail = new DEPARTAMENTS();    
        public FrmDepartamentList()
        {
            InitializeComponent();
        }
        List<DEPARTAMENTS> list = new List<DEPARTAMENTS>();
        private void FrmDepartamentList_Load(object sender, EventArgs e)
        {
            //leo los datos en la BD y los cargo en la grilla
            list = DepartamentBLL.GetDepartamentList();
            dgvDepartamentList.DataSource = list;
            dgvDepartamentList.Columns[0].Visible = false;
            dgvDepartamentList.Columns[1].HeaderText = "Departament Name";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmDepartament frmDepartament = new frmDepartament();
            this.Hide();
            frmDepartament.ShowDialog();
            this.Visible = true;
            //al momento de agregar un nuevo departamento actualizo la lista
            list = DepartamentBLL.GetDepartamentList();
            dgvDepartamentList.DataSource = list;
        }

        private void dgvDepartamentList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dgvDepartamentList.Rows[e.RowIndex].Cells[0].Value);
            detail.DEPARTAMENT_NAME = dgvDepartamentList.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
            {
                MessageBox.Show("Please Select An Department From Table");
            }
            else 
            {
                frmDepartament frm = new frmDepartament();
                frm.IsUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;    
            }
        }
    }
}
