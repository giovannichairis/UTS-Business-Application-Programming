using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace food
{
    public partial class frmOrder_Buy : Form
    {
        public string date_ordered;
        public int qty;

        public frmOrder_Buy()
        {
            InitializeComponent();
        }

        private void frmOrder_Buy_Load(object sender, EventArgs e)
        {

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtQty.Text != "")
            {
                this.qty = Int32.Parse(txtQty.Text);
            }
            this.date_ordered = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            this.DialogResult = DialogResult.OK;
        }
    }
}
