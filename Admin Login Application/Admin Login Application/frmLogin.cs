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
using Dapper;
using MsRepository;
using TypeLib;
using Npgsql;

namespace Admin_Login_Application
{

    public partial class frmLogin : Form
    {
        string ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_topdog;User Id=DB_A53DDD_topdog_admin;Password=falling-2apple;";
        string ConnectionStringPst = "Server=weboholics-demo.dyndns-ip.com;Port=5433;Database=grupp2;User Id = grupp2; Password=grupp2";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            NpgsqlConnection npcon = new NpgsqlConnection(ConnectionStringPst);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter("select count(*) from employees where 'Username' = '" + txtUsername.Text.Trim() + "' and 'Password' = '" + txtPassword.Text.Trim() + "'", npcon);
            DataTable dt2 = new DataTable();

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from employees where Username = '" + txtUsername.Text.Trim() + "' and Password = '" + txtPassword.Text.Trim() + "'", con);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            nda.Fill(dt2);

            if (dt.Rows[0][0].ToString() == "1")
            {
                frmMainMenu objfrmMainMenu = new frmMainMenu();
                this.Hide();
                objfrmMainMenu.Show();
            }
            else
            {
                MessageBox.Show("Check Username or Password");
            }

            if (dt2.Rows[0][0].ToString() == "2")
            {
                frmMainMenu frm = new frmMainMenu();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Check Username or Password");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
