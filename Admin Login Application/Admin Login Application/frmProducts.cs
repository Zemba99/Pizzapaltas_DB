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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            frmPizzas objfrmPizzas = new frmPizzas();
            this.Hide();
            objfrmPizzas.Show();
        }

        private void btnPastas_Click(object sender, EventArgs e)
        {
            frmPastas objfrmPastas = new frmPastas();
            this.Hide();
            objfrmPastas.Show();
        }

        private void btnSallads_Click(object sender, EventArgs e)
        {
            frmSallads objfrmSallads = new frmSallads();
            this.Hide();
            objfrmSallads.Show();
        }

        private void btnBeverages_Click(object sender, EventArgs e)
        {
            frmBeverages objfrmBeverages = new frmBeverages();
            this.Hide();
            objfrmBeverages.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainMenu objfrmMainMenu = new frmMainMenu();
            this.Hide();
            objfrmMainMenu.Show();
        }
    }
}
