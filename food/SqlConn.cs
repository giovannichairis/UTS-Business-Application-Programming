using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace food
{
    static class SqlConn
    {
        public static string username;
        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static DataSet ds;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        public static BindingSource bs;

        public static string GetConnectionString()
        {
            string ConnectionString = "Data Source=DESKTOP-QVEIBK6\\SQLEXPRESS; Database=DB_DATA; Trusted_connection=true;";
            return ConnectionString;
        }

        public static string MyApp()
        {
            string AppTitle = "Food Palace";
            return AppTitle;
        }

        public static void ConnectionState()
        {
            string msg = "Connection state: " + "The connection is ";
            string title = SqlConn.MyApp();
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;

            //MessageBox.Show(msg + con.State.ToString(), title, btn, ico);
        }

        public static void OpenCon()
        {
            con.Close();
            try
            {
                con.ConnectionString = SqlConn.GetConnectionString();
                con.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("The system failed to establish a connection." +
                    Environment.NewLine + e);
            }
            finally
            {
                ConnectionState();
            }
        }
        public static void CloseCon()
        {
            con.Close();
            con.Dispose();
            ConnectionState();
        }

    }
}
