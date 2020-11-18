using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace food
{
    public partial class frmAdmin_Menu : Form
    {
        public frmAdmin_Menu()
        {
            InitializeComponent();
            this.Text = SqlConn.MyApp();
        }
        private void frmAdmin_Menu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;


            ShowProducts();
        }

        private void ShowProducts()
        {
            string query = "SELECT * FROM tbl_menu";
            SqlConn.OpenCon();
            SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
            SqlConn.cmd.CommandText = query;

            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.ds = new DataSet();
            SqlConn.bs = new BindingSource();

            SqlConn.da.Fill(SqlConn.ds, "myProducts");

            dgvMenu.DataSource = SqlConn.ds.Tables["myProducts"];

            dgvMenu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMenu.AllowUserToAddRows = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SqlConn.con.State != ConnectionState.Closed)
            {
                SqlConn.CloseCon();
            }

        }

        //private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string value = dgvMenu.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
        //    MessageBox.Show(value);
        //}

        private void txtUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count > 0)
            {
                Form frmAdminMenuEdit = new frmAdmin_Menu_Edit(dgvMenu.CurrentRow.Cells[0].Value.ToString());
                //MessageBox.Show(dgvMenu.SelectedCells[0].Value.ToString());
                frmAdminMenuEdit.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nothing selected");
            }
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            Form frmAdminMenuAdd = new frmAdmin_Menu_Add();
            frmAdminMenuAdd.Show();
            this.Hide();
        }

        private void frmAdmin_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frmAdmin = new frmAdmin();
            frmAdmin.Show();
            this.Hide();
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count > 0)
            {
                string menu_id = dgvMenu.SelectedCells[0].Value.ToString();
                try
                {
                    SqlConn.OpenCon();
                    using (SqlCommand command = new SqlCommand("DELETE FROM tbl_menu WHERE menu_id = '" + menu_id + "' AND menu_id NOT IN (SELECT TOP(1) menu_id FROM tbl_order WHERE menu_id = '" + menu_id + "')", SqlConn.con))
                    {
                        int deleted = command.ExecuteNonQuery();
                        if (deleted == 0)
                        {
                            MessageBox.Show("Menu yang sudah pernah dipesan tidak bisa dihapus.");
                        }
                    }
                    SqlConn.CloseCon();
                    ShowProducts();

                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
                }
            }
            else
            {
                MessageBox.Show("Nothing selected");
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
                    picMenu.Image = Image.FromStream(mstreem);
                }
                else
                {
                    picMenu.Image = null;
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
            string menu_id = dgvMenu.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            showImage(menu_id);
        }
    }
}