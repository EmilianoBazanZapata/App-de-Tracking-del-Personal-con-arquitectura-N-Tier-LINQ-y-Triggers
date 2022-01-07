namespace App_Tracking
{
    partial class FrmTaskList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl = new System.Windows.Forms.Panel();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtDeliveryDate = new System.Windows.Forms.RadioButton();
            this.rbtStartDate = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboTaskState = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFinish = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDepartament = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvTaskList = new System.Windows.Forms.DataGridView();
            this.pnl.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlAdmin.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.pnlUser);
            this.pnl.Controls.Add(this.pnlAdmin);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(691, 187);
            this.pnl.TabIndex = 0;
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.groupBox1);
            this.pnlUser.Controls.Add(this.btnSearch);
            this.pnlUser.Controls.Add(this.cboTaskState);
            this.pnlUser.Controls.Add(this.btnClear);
            this.pnlUser.Controls.Add(this.label6);
            this.pnlUser.Controls.Add(this.dtpFinish);
            this.pnlUser.Controls.Add(this.label3);
            this.pnlUser.Controls.Add(this.dtpStart);
            this.pnlUser.Controls.Add(this.label9);
            this.pnlUser.Controls.Add(this.label2);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUser.Location = new System.Drawing.Point(310, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(381, 187);
            this.pnlUser.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtDeliveryDate);
            this.groupBox1.Controls.Add(this.rbtStartDate);
            this.groupBox1.Location = new System.Drawing.Point(255, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rbtDeliveryDate
            // 
            this.rbtDeliveryDate.AutoSize = true;
            this.rbtDeliveryDate.Location = new System.Drawing.Point(6, 42);
            this.rbtDeliveryDate.Name = "rbtDeliveryDate";
            this.rbtDeliveryDate.Size = new System.Drawing.Size(89, 17);
            this.rbtDeliveryDate.TabIndex = 1;
            this.rbtDeliveryDate.TabStop = true;
            this.rbtDeliveryDate.Text = "Delivery Date";
            this.rbtDeliveryDate.UseVisualStyleBackColor = true;
            // 
            // rbtStartDate
            // 
            this.rbtStartDate.AutoSize = true;
            this.rbtStartDate.Location = new System.Drawing.Point(6, 19);
            this.rbtStartDate.Name = "rbtStartDate";
            this.rbtStartDate.Size = new System.Drawing.Size(73, 17);
            this.rbtStartDate.TabIndex = 0;
            this.rbtStartDate.TabStop = true;
            this.rbtStartDate.Text = "Start Date";
            this.rbtStartDate.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(111, 145);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 30);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // cboTaskState
            // 
            this.cboTaskState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTaskState.FormattingEnabled = true;
            this.cboTaskState.Location = new System.Drawing.Point(99, 106);
            this.cboTaskState.Name = "cboTaskState";
            this.cboTaskState.Size = new System.Drawing.Size(143, 28);
            this.cboTaskState.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(254, 145);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(118, 30);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Task State";
            // 
            // dtpFinish
            // 
            this.dtpFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinish.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinish.Location = new System.Drawing.Point(99, 74);
            this.dtpFinish.Name = "dtpFinish";
            this.dtpFinish.Size = new System.Drawing.Size(143, 26);
            this.dtpFinish.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Finish";
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(99, 42);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(143, 26);
            this.dtpStart.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Task Date";
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.Controls.Add(this.cboPosition);
            this.pnlAdmin.Controls.Add(this.label7);
            this.pnlAdmin.Controls.Add(this.cboDepartament);
            this.pnlAdmin.Controls.Add(this.label8);
            this.pnlAdmin.Controls.Add(this.txtSurname);
            this.pnlAdmin.Controls.Add(this.label5);
            this.pnlAdmin.Controls.Add(this.txtName);
            this.pnlAdmin.Controls.Add(this.label4);
            this.pnlAdmin.Controls.Add(this.txtUserNo);
            this.pnlAdmin.Controls.Add(this.label1);
            this.pnlAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAdmin.Location = new System.Drawing.Point(0, 0);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(310, 187);
            this.pnlAdmin.TabIndex = 0;
            // 
            // cboPosition
            // 
            this.cboPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Location = new System.Drawing.Point(136, 145);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(143, 28);
            this.cboPosition.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Position";
            // 
            // cboDepartament
            // 
            this.cboDepartament.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartament.FormattingEnabled = true;
            this.cboDepartament.Location = new System.Drawing.Point(136, 111);
            this.cboDepartament.Name = "cboDepartament";
            this.cboDepartament.Size = new System.Drawing.Size(143, 28);
            this.cboDepartament.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Departament";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurname.Location = new System.Drawing.Point(136, 79);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(143, 26);
            this.txtSurname.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Surname";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(136, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 26);
            this.txtName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Name";
            // 
            // txtUserNo
            // 
            this.txtUserNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNo.Location = new System.Drawing.Point(136, 15);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(143, 26);
            this.txtUserNo.TabIndex = 1;
            this.txtUserNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserNO";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnApprove);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 373);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 76);
            this.panel2.TabIndex = 2;
            // 
            // btnApprove
            // 
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Location = new System.Drawing.Point(12, 15);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(118, 49);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(562, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 49);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(384, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(118, 49);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(260, 15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 49);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(136, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(118, 49);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvTaskList
            // 
            this.dgvTaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaskList.Location = new System.Drawing.Point(0, 187);
            this.dgvTaskList.Name = "dgvTaskList";
            this.dgvTaskList.Size = new System.Drawing.Size(691, 186);
            this.dgvTaskList.TabIndex = 1;
            // 
            // FrmTaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 449);
            this.Controls.Add(this.dgvTaskList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl);
            this.Name = "FrmTaskList";
            this.Text = "Task List";
            this.Load += new System.EventHandler(this.FrmTaskList_Load);
            this.pnl.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlAdmin.ResumeLayout(false);
            this.pnlAdmin.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvTaskList;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPosition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDepartament;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtDeliveryDate;
        private System.Windows.Forms.RadioButton rbtStartDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboTaskState;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFinish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
    }
}