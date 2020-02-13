using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Login_Application
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            frmEmployee objfrmEmployee = new frmEmployee();
            this.Hide();
            objfrmEmployee.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProducts objfrmProducts = new frmProducts();
            this.Hide();
            objfrmProducts.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmDataBases objfrmLogin = new frmDataBases();
            this.Hide();
            objfrmLogin.Show();
        }

        private void btnIngredients_Click(object sender, EventArgs e)
        {
            frmIngredients objfrmIngredients = new frmIngredients();
            this.Hide();
            objfrmIngredients.Show();
        }
    }
}
