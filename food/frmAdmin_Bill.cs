using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
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
    public partial class frmAdmin_Bill : Form
    {
        public int go = 0;
        public string table_id, name;
        public decimal dtotal, price, total, tax, grand_total;
        public int qty;

        private void frmAdmin_Bill_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frmAdmin = new frmAdmin();
            frmAdmin.Show();
            this.Hide();
        }

        public DateTime date_add;

        public frmAdmin_Bill()
        {
            InitializeComponent();
        }
        private void ShowOrder()
        {
            string query = "SELECT b.bill_id,b.table_id,b.date_add,b.grand_total FROM tbl_hbill b JOIN(select table_id from tbl_order where status = 'C' group by table_id) o ON b.table_id = o.table_id";
            SqlConn.OpenCon();
            SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
            SqlConn.cmd.Parameters.Clear();
            SqlConn.cmd.CommandText = query;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.ds = new DataSet();
            SqlConn.da.Fill(SqlConn.ds, "order");

            var link_print = new DataGridViewLinkColumn();
            link_print.DisplayIndex = 1;
            link_print.DefaultCellStyle.NullValue = "Cetak";
            link_print.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            link_print.Width = 60;
            link_print.ActiveLinkColor = Color.White;
            link_print.LinkBehavior = LinkBehavior.HoverUnderline;
            link_print.LinkColor = Color.Blue;
            link_print.VisitedLinkColor = Color.YellowGreen;

            dgvOrder.Columns.Clear();
            dgvOrder.Columns.Add(link_print);
            dgvOrder.DataSource = SqlConn.ds.Tables["order"];
            dgvOrder.Columns["bill_id"].Visible = false;
            dgvOrder.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrder.AllowUserToAddRows = false;

        }
        private void frmAdmin_Bill_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            ShowOrder();
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string bill_id = dgvOrder.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            if (e.ColumnIndex == 0)
            {
                SqlConn.OpenCon();
                try
                {
                    SqlConn.OpenCon();
                    string query = "SELECT h.bill_id,d.bill_id,h.table_id,h.date_add,m.menu_id,m.name,m.price,d.menu_id,d.qty,h.total,h.tax,h.grand_total FROM tbl_hbill h JOIN tbl_dbill d ON h.bill_id=d.bill_id JOIN tbl_menu m ON d.menu_id=m.menu_id WHERE h.bill_id=@bill_id";
                    SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
                    SqlConn.cmd.CommandText = query;
                    SqlConn.cmd.Parameters.Add(new SqlParameter("@bill_id", bill_id));
                    SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
                    SqlConn.ds = new DataSet();
                    SqlConn.da.Fill(SqlConn.ds, "bill");
                    SqlConn.CloseCon();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }

                Form3 b = new Form3();
                CrystalReport1 cr = new CrystalReport1();
                int a = System.Convert.ToInt32(bill_id);
                cr.SetParameterValue("bill_id", a);
                cr.SetDataSource(SqlConn.ds.Tables["bill"]);

                b.crystalReportViewer1.ReportSource = cr;
                b.crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
                b.Show();

                //// Close Order
                SqlConn.OpenCon();
                string query1 = "UPDATE tbl_order SET status='B' WHERE table_id IN (SELECT table_id FROM tbl_hbill WHERE bill_id=@bill_id) AND status='C'";
                SqlConn.cmd.Parameters.Clear();
                SqlConn.cmd.CommandText = query1;
                SqlConn.cmd.Parameters.Add(new SqlParameter("@dateString", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")));
                SqlConn.cmd.Parameters.Add(new SqlParameter("@bill_id", bill_id));
                int N = SqlConn.cmd.ExecuteNonQuery();
                SqlConn.CloseCon();
                ShowOrder();
            }
        }
    }
}
