namespace App_Tracking
{
    partial class FrmMain
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
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnPosition = new System.Windows.Forms.Button();
            this.btnDepartament = new System.Windows.Forms.Button();
            this.btnPermission = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmployee
            // 
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Location = new System.Drawing.Point(12, 12);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(218, 132);
            this.btnEmployee.TabIndex = 0;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmployee.UseVisualStyleBackColor = true;
            // 
            // btnTasks
            // 
            this.btnTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTasks.Location = new System.Drawing.Point(236, 12);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(218, 132);
            this.btnTasks.TabIndex = 1;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTasks.UseVisualStyleBackColor = true;
            // 
            // btnSalary
            // 
            this.btnSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalary.Location = new System.Drawing.Point(460, 12);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Size = new System.Drawing.Size(218, 132);
            this.btnSalary.TabIndex = 2;
            this.btnSalary.Text = "Salary";
            this.btnSalary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalary.UseVisualStyleBackColor = true;
            // 
            // btnPosition
            // 
            this.btnPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosition.Location = new System.Drawing.Point(460, 150);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(218, 132);
            this.btnPosition.TabIndex = 5;
            this.btnPosition.Text = "Position";
            this.btnPosition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPosition.UseVisualStyleBackColor = true;
            // 
            // btnDepartament
            // 
            this.btnDepartament.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepartament.Location = new System.Drawing.Point(236, 150);
            this.btnDepartament.Name = "btnDepartament";
            this.btnDepartament.Size = new System.Drawing.Size(218, 132);
            this.btnDepartament.TabIndex = 4;
            this.btnDepartament.Text = "Departament";
            this.btnDepartament.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepartament.UseVisualStyleBackColor = true;
            // 
            // btnPermission
            // 
            this.btnPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermission.Location = new System.Drawing.Point(12, 150);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(218, 132);
            this.btnPermission.TabIndex = 3;
            this.btnPermission.Text = "Permission";
            this.btnPermission.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPermission.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(347, 288);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(218, 132);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(123, 288);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(218, 132);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnPosition);
            this.Controls.Add(this.btnDepartament);
            this.Controls.Add(this.btnPermission);
            this.Controls.Add(this.btnSalary);
            this.Controls.Add(this.btnTasks);
            this.Controls.Add(this.btnEmployee);
            this.Name = "FrmMain";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.Button btnSalary;
        private System.Windows.Forms.Button btnPosition;
        private System.Windows.Forms.Button btnDepartament;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogOut;
    }
}