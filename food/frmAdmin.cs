using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace food
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAdmin_Menu = new frmAdmin_Menu();
            frmAdmin_Menu.Show();
            this.Close();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAdmin_Bill_Menu = new frmAdmin_Bill();
            frmAdmin_Bill_Menu.Show();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConn.username = "";
            Form Form1 = new Form1();
            this.Close();
            Form1.Show();

        }
    }
}
