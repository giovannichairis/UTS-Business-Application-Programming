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
    public partial class frmAdmin_Menu_Edit : Form
    {
        string imgLocation;
        string _menu_id;
        public frmAdmin_Menu_Edit(string menu_id)
        {
            _menu_id = menu_id;
            InitializeComponent();
        }

        private void fillCat()
        {
            string query = "SELECT * FROM tbl_category";
            SqlConn.OpenCon();
            SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
            SqlConn.cmd.CommandText = query;

            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.ds = new DataSet();
            SqlConn.bs = new BindingSource();

            SqlConn.da.Fill(SqlConn.ds, "myCats");

            cbCat.DataSource = SqlConn.ds.Tables["myCats"];
            cbCat.DisplayMember = "cat_name";
            cbCat.ValueMember = "cat_id";
            cbCat.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmAdmin_Menu_Edit_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            fillCat();
            String query = "SELECT * FROM tbl_menu where menu_id=@menu_id";
            SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
            SqlConn.cmd.CommandText = query;
            SqlConn.cmd.Parameters.Add(new SqlParameter("@menu_id", this._menu_id));
            SqlConn.OpenCon();

            SqlDataReader DataRead = SqlConn.cmd.ExecuteReader();
            DataRead.Read();

            if (DataRead.HasRows)
            {
                txtId.Text = DataRead["menu_id"].ToString();
                cbCat.SelectedIndex = Convert.ToInt32(DataRead["cat_id"]) - 1;
                txtNama.Text = DataRead["name"].ToString();
                txtPrice.Text = DataRead["price"].ToString();
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

        private void btnChpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog imgOpen = new OpenFileDialog();
            imgOpen.Filter = "Image Files (*.jpg)|*.jpg | All Files (*.*)|*.*";


            if (imgOpen.ShowDialog() == DialogResult.OK)
            {
                imgLocation = imgOpen.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int cat_id;
            bool result = int.TryParse(cbCat.SelectedValue.ToString(), out cat_id);
            if (imgLocation == null)
            {
                SqlConn.OpenCon();
                string query = "UPDATE tbl_menu set name='" + txtNama.Text + "',cat_id=@cat_id,price=@price where menu_id=@id";
                SqlConn.cmd.CommandText = query;
                SqlConn.cmd.Parameters.Add(new SqlParameter("@id", this._menu_id));
                SqlConn.cmd.Parameters.Add(new SqlParameter("@cat_id", cat_id));
                SqlConn.cmd.Parameters.Add(new SqlParameter("@price", txtPrice.Text.Replace(",", ".")));
            }
            else
            {
                byte[] images = null;
                FileStream Streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Streem);
                images = brs.ReadBytes((int)Streem.Length);
                SqlConn.OpenCon();
                string query = "UPDATE tbl_menu set image=@images where menu_id=@id";
                //string query = "UPDATE tbl_menu set name='" + txtNama.Text + "',cat_id=@cat_id,price=@price, image=@images where menu_id=@id";
                SqlConn.cmd.CommandText = query;
                SqlConn.cmd.Parameters.Add(new SqlParameter("@id", this._menu_id));
                SqlConn.cmd.Parameters.Add(new SqlParameter("@images", images));
                SqlConn.cmd.Parameters.Add(new SqlParameter("@cat_id", cat_id));
                SqlConn.cmd.Parameters.Add(new SqlParameter("@price", txtPrice.Text.Replace(",", ".")));
                
            }
            int N = SqlConn.cmd.ExecuteNonQuery();
            SqlConn.CloseCon();
            MessageBox.Show("Data saved successfull");
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmAdmin_Menu_Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frmAdminMenu = new frmAdmin_Menu();
            frmAdminMenu.Show();
            this.Hide();
        }
    }
}
