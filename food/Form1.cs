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

namespace food
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, password;
            username = txtUsername.Text;
            password = txtPassword.Text;
            try
            {
                String str = "Data Source=DESKTOP-QVEIBK6\\SQLEXPRESS; Database=DB_DATA; Trusted_connection=true;";
                string query = "SELECT username from tbl_user WHERE username = @username and password=@password";
                //MessageBox.Show(txtUsername.Text + " " + txtPassword.Text);
                string returnValue = "";
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand sqlcmd = new SqlCommand(query, con))
                    {
                        sqlcmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUsername.Text;
                        sqlcmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Text;
                        con.Open();
                        returnValue = (string)sqlcmd.ExecuteScalar();
                    }
                    con.Close();
                }
                //EDIT to avoid NRE 
                if (String.IsNullOrEmpty(returnValue))
                {
                    MessageBox.Show("Incorrect username or password");
                    return;
                }
                returnValue = returnValue.Trim();
                if (returnValue == "admin")
                {
                    SqlConn.username = username;
                    Form frmAdmin = new frmAdmin();
                    frmAdmin.Show();
                    this.Hide();
                }
                else
                {
                    // Cek apakah ada bill gantung
                    SqlConn.OpenCon();
                    string query_cek = "SELECT table_id FROM tbl_order WHERE status='C' AND table_id=@table_id GROUP BY table_id";
                    SqlConn.cmd = new SqlCommand(SqlConn.sql, SqlConn.con);
                    SqlConn.cmd.Parameters.Clear();
                    SqlConn.cmd.CommandText = query_cek;
                    SqlConn.cmd.Parameters.Add(new SqlParameter("@table_id", username));
                    SqlDataReader DataRead = SqlConn.cmd.ExecuteReader();

                    if (DataRead.HasRows)
                    {
                        MessageBox.Show("Masih ada bill yang gantung di meja ini. Cetak dulu.");
                    }
                    else
                    {
                        SqlConn.username = username;
                        Form frmOrder = new frmOrder();
                        frmOrder.Show();
                        this.Hide();
                    }
                    SqlConn.CloseCon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
