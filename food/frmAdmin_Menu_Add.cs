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
    public partial class frmAdmin_Menu_Add : Form
    {
        string imgLocation;
        public frmAdmin_Menu_Add()
        {
            InitializeComponent();
        }

        private void btnChpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog imgOpen = new OpenFileDialog();
            imgOpen.Filter = "Image Files (*.jpg;*.jpeg;*.webp)|*.jpg | All Files (*.*)|*.*";


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
                string query = "INSERT INTO tbl_menu (name,cat_id,price,qty_jual) VALUES ('" + txtNama.Text + "','" + cat_id + "','" + txtPrice.Text + "',0)";
                SqlConn.cmd.CommandText = query;
            }
            else
            {
                byte[] images = null;
                FileStream Streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Streem);
                images = brs.ReadBytes((int)Streem.Length);
                SqlConn.OpenCon();
                string query = "INSERT INTO tbl_menu (name,cat_id,price,image,qty_jual) VALUES ('" + txtNama.Text + "','" + cat_id + "','" + txtPrice.Text + "',@image,0)";
                SqlConn.cmd.CommandText = query;
                SqlConn.cmd.Parameters.Add(new SqlParameter("@image", images));
            }
            int N = SqlConn.cmd.ExecuteNonQuery();
            SqlConn.CloseCon();
            MessageBox.Show("Data saved successfull");
            this.Close();
        }

        private void frmAdmin_Menu_Add_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            fillCat();
        }

        private void frmAdmin_Menu_Add_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frmAdminMenu = new frmAdmin_Menu();
            frmAdminMenu.Show();
            this.Hide();
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

        
    }
}
