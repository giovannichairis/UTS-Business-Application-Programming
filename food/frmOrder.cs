using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace food
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        private void tabMenu_Click(object sender, EventArgs e)
        {

        }
        private void ShowAllMenu()
        {
            string query = "SELECT menu_id,name,price FROM tbl_menu";
            SqlConn.OpenCon();
            SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
            SqlConn.cmd.CommandText = query;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.ds = new DataSet();
            SqlConn.bs = new BindingSource();
            SqlConn.da.Fill(SqlConn.ds, "allMenu");

            var link = new DataGridViewLinkColumn();
            link.DisplayIndex = 0;
            link.DefaultCellStyle.NullValue = "Buy";
            link.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            link.Width = 60;
            link.ActiveLinkColor = Color.White;
            link.LinkBehavior = LinkBehavior.HoverUnderline;
            link.LinkColor = Color.Blue;
            link.VisitedLinkColor = Color.YellowGreen;

            dgvMenu.Columns.Clear();
            dgvMenu.Columns.Add(link);
            dgvMenu.DataSource = SqlConn.ds.Tables["allMenu"];
            dgvMenu.Columns["menu_id"].Visible = false;
            dgvMenu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMenu.AllowUserToAddRows = false;
        }

        private void ShowBestSeller()
        {
            string query = "SELECT menu_id,name,price FROM tbl_menu ORDER BY qty_jual DESC";
            SqlConn.OpenCon();
            SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
            SqlConn.cmd.CommandText = query;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.ds = new DataSet();
            SqlConn.bs = new BindingSource();
            SqlConn.da.Fill(SqlConn.ds, "bestSeller");

            var link = new DataGridViewLinkColumn();
            link.DisplayIndex = 0;
            link.DefaultCellStyle.NullValue = "Buy";
            link.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            link.Width = 60;
            link.ActiveLinkColor = Color.White;
            link.LinkBehavior = LinkBehavior.HoverUnderline;
            link.LinkColor = Color.Blue;
            link.VisitedLinkColor = Color.YellowGreen;

            dgvBest.Columns.Clear();
            dgvBest.Columns.Add(link);
            dgvBest.DataSource = SqlConn.ds.Tables["bestSeller"];
            dgvBest.Columns["menu_id"].Visible = false;
            dgvBest.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBest.AllowUserToAddRows = false;
        }

        private void ShowOrdered()
        {
            string query = "SELECT m.menu_id,m.name,o.qty from tbl_order o join tbl_menu m on m.menu_id = o.menu_id where table_id = @table_id AND status='O'";
            SqlConn.OpenCon();
            SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
            SqlConn.cmd.Parameters.Clear();
            SqlConn.cmd.CommandText = query;
            SqlConn.cmd.Parameters.Add(new SqlParameter("@table_id", SqlConn.username));
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.ds = new DataSet();
            SqlConn.da.Fill(SqlConn.ds, "ordered");

            var link_edit = new DataGridViewLinkColumn();
            link_edit.DisplayIndex = 0;
            link_edit.DefaultCellStyle.NullValue = "Edit";
            link_edit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            link_edit.Width = 60;
            link_edit.ActiveLinkColor = Color.White;
            link_edit.LinkBehavior = LinkBehavior.HoverUnderline;
            link_edit.LinkColor = Color.Blue;
            link_edit.VisitedLinkColor = Color.YellowGreen;

            var link_cancel = new DataGridViewLinkColumn();
            link_cancel.DisplayIndex = 1;
            link_cancel.DefaultCellStyle.NullValue = "Batal";
            link_cancel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            link_cancel.Width = 60;
            link_cancel.ActiveLinkColor = Color.White;
            link_cancel.LinkBehavior = LinkBehavior.HoverUnderline;
            link_cancel.LinkColor = Color.Blue;
            link_cancel.VisitedLinkColor = Color.YellowGreen;

            dgvOrdered.Columns.Clear();
            dgvOrdered.Columns.Add(link_edit);
            dgvOrdered.Columns.Add(link_cancel);
            dgvOrdered.DataSource = SqlConn.ds.Tables["ordered"];
            dgvOrdered.Columns["menu_id"].Visible = false;
            dgvOrdered.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdered.AllowUserToAddRows = false;

            showTotal();
        }

        public void showTotal()
        {
            SqlConn.OpenCon();
            string query_cek = "SELECT coalesce(sum(o.qty*m.price),0) as total FROM tbl_menu m JOIN tbl_order o ON m.menu_id = o.menu_id WHERE o.table_id = '" + SqlConn.username + "' AND status ='O'";
            SqlConn.cmd.Parameters.Clear();
            SqlConn.cmd.CommandText = query_cek;

            SqlDataReader DataRead = SqlConn.cmd.ExecuteReader();
            DataRead.Read();

            if (DataRead.HasRows)
            {
                decimal total = Convert.ToDecimal(decimal.Parse(DataRead["total"].ToString()).ToString("#,##0.00"));

                DataRead.Close();
                lblTotal.Text = Convert.ToDecimal(total).ToString("#,##0.00");
            }
        }
        public void showImage(string menu_id)
        {
            String query = "SELECT image FROM tbl_menu where menu_id=@menu_id";
            SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
            SqlConn.cmd.CommandText = query;
            SqlConn.cmd.Parameters.Add(new SqlParameter("@menu_id", menu_id));
            SqlConn.OpenCon();

            SqlDataReader DataRead = SqlConn.cmd.ExecuteReader();
            DataRead.Read();

            if (DataRead.HasRows)
            {
                if (!Convert.IsDBNull(DataRead["image"]))
                {
                    byte[] images = ((byte[])DataRead["Image"]);
                    MemoryStream mstreem = new MemoryStream(images);
                    pictureBox1.Image = Image.FromStream(mstreem);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                MessageBox.Show("This Image not Available..!");
            }
            SqlConn.CloseCon();
        }
        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menu_id = dgvMenu.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            if (e.ColumnIndex == 0)
            {
                using (var form = new frmOrder_Buy())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        int qty = form.qty;
                        string dateString = form.date_ordered;
                        if (qty > 0)
                        {
                            SqlConn.OpenCon();
                            string query_cek = "SELECT qty FROM tbl_order WHERE menu_id=@menu_id AND table_id=@table_id AND status='O'";
                            SqlConn.cmd.Parameters.Clear();
                            SqlConn.cmd.CommandText = query_cek;
                            SqlConn.cmd.Parameters.Add(new SqlParameter("@menu_id", menu_id));
                            SqlConn.cmd.Parameters.Add(new SqlParameter("@table_id", SqlConn.username));

                            SqlDataReader DataRead = SqlConn.cmd.ExecuteReader();
                            DataRead.Read();

                            if (DataRead.HasRows)
                            {
                                int qty_lama = Int32.Parse(DataRead["qty"].ToString());
                                DataRead.Close();
                                string query = "UPDATE tbl_order SET qty=@qty,date_ordered=@dateString WHERE menu_id=@menu_id AND table_id=@table_id AND status='O'";
                                SqlConn.cmd.Parameters.Clear();
                                SqlConn.cmd.CommandText = query;
                                SqlConn.cmd.Parameters.Add(new SqlParameter("@menu_id", menu_id));
                                SqlConn.cmd.Parameters.Add(new SqlParameter("@table_id", SqlConn.username));
                                SqlConn.cmd.Parameters.Add(new SqlParameter("@qty", qty + qty_lama));
                                SqlConn.cmd.Parameters.Add(new SqlParameter("@dateString", dateString));
                                int N = SqlConn.cmd.ExecuteNonQuery();
                                //MessageBox.Show(N.ToString() + "Data saved successfull");
                            }
                            else
                            {
                                DataRead.Close();
                                string query = "INSERT INTO tbl_order(table_id,menu_id,qty,status,date_ordered) VALUES (@table_id,@menu_id,'" + qty + "','O',@dateString)";
                                SqlConn.cmd.Parameters.Clear();
                                SqlConn.cmd.CommandText = query;
                                SqlConn.cmd.Parameters.Add(new SqlParameter("@table_id", SqlConn.username));
                                SqlConn.cmd.Parameters.Add(new SqlParameter("@menu_id", menu_id));
                                SqlConn.cmd.Parameters.Add(new SqlParameter("@dateString", dateString));
                                int N = SqlConn.cmd.ExecuteNonQuery();
                                //MessageBox.Show(N.ToString() + "Data saved successfull");
                            }
                            SqlConn.CloseCon();
                            ShowOrdered();
                        }
                    }
                }
            }
            showImage(menu_id);
        }

        private void Order_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            lblTotal.Text = "0";
            ShowAllMenu();
            ShowBestSeller();
            ShowOrdered();
        }

        private void dgvBest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menu_id = dgvMenu.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            if (e.ColumnIndex == 0)
            {

                using (var form = new frmOrder_Buy())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        int qty = form.qty;
                        string dateString = form.date_ordered;
                        if (qty > 0)
                        {
                            SqlConn.OpenCon();
                            string query = "INSERT INTO tbl_order (table_id,menu_id,qty,status,date_ordered) VALUES (@table_id,@menu_id,'" + qty + "','O',@dateString)";
                            SqlConn.cmd.CommandText = query;
                            SqlConn.cmd.Parameters.Add(new SqlParameter("@table_id", SqlConn.username));
                            SqlConn.cmd.Parameters.Add(new SqlParameter("@menu_id", menu_id));
                            SqlConn.cmd.Parameters.Add(new SqlParameter("@dateString", dateString));
                            int N = SqlConn.cmd.ExecuteNonQuery();
                            SqlConn.CloseCon();
                            //MessageBox.Show(N.ToString() + "Data saved successfull");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("cancel");
                    }
                }
            }
            showImage(menu_id);
        }

        private void dgvOrdered_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string menu_id = dgvOrdered.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            //MessageBox.Show(menu_id);
            if (e.ColumnIndex == 1)
            {
                SqlConn.OpenCon();
                using (SqlCommand command = new SqlCommand("DELETE FROM tbl_order WHERE menu_id = '" + menu_id + "' AND table_id=" + SqlConn.username, SqlConn.con))
                {
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("selesai");
                SqlConn.CloseCon();
                ShowOrdered();
            }
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            SqlConn.OpenCon();

            // Migrate Order to Bill
            string query_cek = "SELECT o.menu_id,o.qty,m.price FROM tbl_order o JOIN tbl_menu m ON o.menu_id = m.menu_id WHERE o.table_id=@table_id AND status='O'";
            SqlConn.cmd.Parameters.Clear();
            SqlConn.cmd.CommandText = query_cek;
            SqlConn.cmd.Parameters.Add(new SqlParameter("@table_id", SqlConn.username));
            SqlDataReader DataRead = SqlConn.cmd.ExecuteReader();
            //DataRead.Read();
            int i = 0;
            int id_hbill;
            decimal total = 0, tax = 0, grandtotal = 0;
            List<int> d_menu_id = new List<int>();
            List<int> d_qty = new List<int>();
            List<decimal> d_subtotal = new List<decimal>();
            if (DataRead.HasRows)
            {
                while (DataRead.Read())
                {
                    d_menu_id.Add(Convert.ToInt32(DataRead["menu_id"].ToString()));
                    d_qty.Add(Convert.ToInt32(DataRead["qty"].ToString()));
                    d_subtotal.Add(Convert.ToDecimal(DataRead["price"].ToString()));
                }

                DataRead.Close();
                total = decimal.Parse(lblTotal.Text);
                tax = Decimal.Multiply(total, decimal.Parse("0,1"));
                grandtotal = total + tax;

                string query_hbill = "INSERT INTO tbl_hbill(table_id,date_add,total,tax,grand_total) VALUES (@table_id,@dateString,@total,@tax,@grandtotal); SELECT SCOPE_IDENTITY()";
                SqlCommand cmd_hbill = new SqlCommand(query_hbill, SqlConn.con);
                cmd_hbill.Parameters.Clear();
                cmd_hbill.CommandText = query_hbill;
                cmd_hbill.Parameters.Add(new SqlParameter("@table_id", SqlConn.username));
                cmd_hbill.Parameters.Add(new SqlParameter("@total", total));
                cmd_hbill.Parameters.Add(new SqlParameter("@tax", tax));
                cmd_hbill.Parameters.Add(new SqlParameter("@grandtotal", grandtotal));
                cmd_hbill.Parameters.Add(new SqlParameter("@dateString", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")));
                id_hbill = Convert.ToInt32(cmd_hbill.ExecuteScalar());
                //MessageBox.Show(id_hbill.ToString());

                for (int j = 0; j < d_qty.Count; j++)
                {
                    string query_dbill = "INSERT INTO tbl_dbill(bill_id,menu_id,qty,subtotal,total) VALUES (@bill_id,@menu_id,@qty,@subtotal,@total)";
                    SqlCommand cmd_dbill = new SqlCommand(query_dbill, SqlConn.con);
                    cmd_dbill.Parameters.Clear();
                    cmd_dbill.CommandText = query_dbill;
                    cmd_dbill.Parameters.Add(new SqlParameter("@bill_id", id_hbill));
                    cmd_dbill.Parameters.Add(new SqlParameter("@menu_id", d_menu_id[j]));
                    cmd_dbill.Parameters.Add(new SqlParameter("@qty", d_qty[j]));
                    cmd_dbill.Parameters.Add(new SqlParameter("@subtotal", d_subtotal[j]));
                    cmd_dbill.Parameters.Add(new SqlParameter("@total", d_qty[j] * d_subtotal[j]));
                    cmd_dbill.ExecuteNonQuery();

                    // Update qty jual di tabel menu
                    string query_updateqty = "UPDATE tbl_menu SET qty_jual=qty_jual+@qty_jual WHERE menu_id=@menu_id";
                    SqlCommand cmd_updateqty = new SqlCommand(query_updateqty, SqlConn.con);
                    cmd_updateqty.Parameters.Clear();
                    cmd_updateqty.CommandText = query_updateqty;
                    cmd_updateqty.Parameters.Add(new SqlParameter("@menu_id", d_menu_id[j]));
                    cmd_updateqty.Parameters.Add(new SqlParameter("@qty_jual", d_qty[j]));
                    cmd_updateqty.ExecuteNonQuery();
                }
            }

            // Close Order
            string query = "UPDATE tbl_order SET date_closed=@dateString,status='C' WHERE table_id=@table_id";
            SqlConn.cmd.Parameters.Clear();
            SqlConn.cmd.CommandText = query;
            SqlConn.cmd.Parameters.Add(new SqlParameter("@dateString", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")));
            SqlConn.cmd.Parameters.Add(new SqlParameter("@table_id", SqlConn.username));
            int N = SqlConn.cmd.ExecuteNonQuery();

            SqlConn.CloseCon();
            ShowOrdered();
            DialogResult dresult = MessageBox.Show("Bill requested. Silahkan membayar di kasir.", "Terima kasih atas kunjungan Anda", MessageBoxButtons.OK);
            if (dresult == DialogResult.OK)
            {
                SqlConn.username = "";
                Form Form1 = new Form1();
                Form1.Show();
                this.Close();
            }
        }
    }
}
