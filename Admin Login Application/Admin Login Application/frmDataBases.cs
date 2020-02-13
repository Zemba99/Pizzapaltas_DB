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
    public partial class frmDataBases : Form
    {
        public frmDataBases()
        {
            InitializeComponent();
        }
        private void btnMsSql_Click(object sender, EventArgs e)
        {
            RepositoryFactory.SelectBackend(eBackend.MsSQL);
            frmMainMenu frm = new frmMainMenu();
            this.Hide();
            frm.Show();
        }

        private void btnPostgres_Click(object sender, EventArgs e)
        {

            RepositoryFactory.SelectBackend(eBackend.Postgre);
            frmMainMenu frm = new frmMainMenu();
            this.Hide();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
