namespace food
{
    partial class frmOrder
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMenu = new System.Windows.Forms.TabPage();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.tabBestSeller = new System.Windows.Forms.TabPage();
            this.dgvBest = new System.Windows.Forms.DataGridView();
            this.btnBill = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvOrdered = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.tabBestSeller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMenu);
            this.tabControl1.Controls.Add(this.tabBestSeller);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 264);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.dgvMenu);
            this.tabMenu.Location = new System.Drawing.Point(4, 22);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabMenu.Size = new System.Drawing.Size(457, 238);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.Text = "All Menu";
            this.tabMenu.UseVisualStyleBackColor = true;
            this.tabMenu.Click += new System.EventHandler(this.tabMenu_Click);
            // 
            // dgvMenu
            // 
            this.dgvMenu.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Location = new System.Drawing.Point(0, 0);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.ReadOnly = true;
            this.dgvMenu.Size = new System.Drawing.Size(457, 238);
            this.dgvMenu.TabIndex = 0;
            this.dgvMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_CellClick);
            // 
            // tabBestSeller
            // 
            this.tabBestSeller.Controls.Add(this.dgvBest);
            this.tabBestSeller.Location = new System.Drawing.Point(4, 22);
            this.tabBestSeller.Name = "tabBestSeller";
            this.tabBestSeller.Padding = new System.Windows.Forms.Padding(3);
            this.tabBestSeller.Size = new System.Drawing.Size(457, 238);
            this.tabBestSeller.TabIndex = 1;
            this.tabBestSeller.Text = "Best Seller";
            this.tabBestSeller.UseVisualStyleBackColor = true;
            // 
            // dgvBest
            // 
            this.dgvBest.BackgroundColor = System.Drawing.Color.White;
            this.dgvBest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBest.Location = new System.Drawing.Point(0, 0);
            this.dgvBest.Name = "dgvBest";
            this.dgvBest.ReadOnly = true;
            this.dgvBest.Size = new System.Drawing.Size(457, 238);
            this.dgvBest.TabIndex = 0;
            this.dgvBest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBest_CellClick);
            // 
            // btnBill
            // 
            this.btnBill.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBill.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBill.ForeColor = System.Drawing.Color.Transparent;
            this.btnBill.Location = new System.Drawing.Point(501, 534);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(177, 50);
            this.btnBill.TabIndex = 2;
            this.btnBill.Text = "Call Bill";
            this.btnBill.UseVisualStyleBackColor = false;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(498, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(496, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rp.";
            // 
            // dgvOrdered
            // 
            this.dgvOrdered.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdered.Location = new System.Drawing.Point(16, 353);
            this.dgvOrdered.Name = "dgvOrdered";
            this.dgvOrdered.ReadOnly = true;
            this.dgvOrdered.Size = new System.Drawing.Size(457, 231);
            this.dgvOrdered.TabIndex = 0;
            this.dgvOrdered.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdered_CellClick);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTotal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotal.Location = new System.Drawing.Point(554, 378);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(27, 29);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(12, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rincian Pesanan:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Menu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(501, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 238);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1123, 667);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvOrdered);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBill);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmOrder";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.tabBestSeller.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMenu;
        private System.Windows.Forms.TabPage tabBestSeller;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.DataGridView dgvBest;
        private System.Windows.Forms.DataGridView dgvOrdered;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}