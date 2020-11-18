namespace food
{
    partial class frmAdmin_Menu
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
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.txtAdd = new System.Windows.Forms.Button();
            this.txtUpdate = new System.Windows.Forms.Button();
            this.txtDelete = new System.Windows.Forms.Button();
            this.picMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMenu
            // 
            this.dgvMenu.AllowUserToAddRows = false;
            this.dgvMenu.AllowUserToDeleteRows = false;
            this.dgvMenu.AllowUserToOrderColumns = true;
            this.dgvMenu.AllowUserToResizeColumns = false;
            this.dgvMenu.AllowUserToResizeRows = false;
            this.dgvMenu.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Location = new System.Drawing.Point(12, 54);
            this.dgvMenu.MultiSelect = false;
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.ReadOnly = true;
            this.dgvMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenu.Size = new System.Drawing.Size(824, 434);
            this.dgvMenu.TabIndex = 8;
            this.dgvMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_CellClick);
            // 
            // txtAdd
            // 
            this.txtAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtAdd.ForeColor = System.Drawing.Color.Transparent;
            this.txtAdd.Location = new System.Drawing.Point(12, 25);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(75, 23);
            this.txtAdd.TabIndex = 9;
            this.txtAdd.Text = "Add";
            this.txtAdd.UseVisualStyleBackColor = false;
            this.txtAdd.Click += new System.EventHandler(this.txtAdd_Click);
            // 
            // txtUpdate
            // 
            this.txtUpdate.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtUpdate.ForeColor = System.Drawing.Color.Transparent;
            this.txtUpdate.Location = new System.Drawing.Point(93, 25);
            this.txtUpdate.Name = "txtUpdate";
            this.txtUpdate.Size = new System.Drawing.Size(75, 23);
            this.txtUpdate.TabIndex = 10;
            this.txtUpdate.Text = "Update";
            this.txtUpdate.UseVisualStyleBackColor = false;
            this.txtUpdate.Click += new System.EventHandler(this.txtUpdate_Click);
            // 
            // txtDelete
            // 
            this.txtDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtDelete.ForeColor = System.Drawing.Color.Transparent;
            this.txtDelete.Location = new System.Drawing.Point(174, 25);
            this.txtDelete.Name = "txtDelete";
            this.txtDelete.Size = new System.Drawing.Size(75, 23);
            this.txtDelete.TabIndex = 11;
            this.txtDelete.Text = "Delete";
            this.txtDelete.UseVisualStyleBackColor = false;
            this.txtDelete.Click += new System.EventHandler(this.txtDelete_Click);
            // 
            // picMenu
            // 
            this.picMenu.Location = new System.Drawing.Point(622, 54);
            this.picMenu.Name = "picMenu";
            this.picMenu.Size = new System.Drawing.Size(485, 434);
            this.picMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMenu.TabIndex = 7;
            this.picMenu.TabStop = false;
            // 
            // frmAdmin_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1228, 510);
            this.Controls.Add(this.txtDelete);
            this.Controls.Add(this.txtUpdate);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.dgvMenu);
            this.Controls.Add(this.picMenu);
            this.Name = "frmAdmin_Menu";
            this.Text = "Master Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdmin_Menu_FormClosed);
            this.Load += new System.EventHandler(this.frmAdmin_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picMenu;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.Button txtAdd;
        private System.Windows.Forms.Button txtUpdate;
        private System.Windows.Forms.Button txtDelete;
    }
}