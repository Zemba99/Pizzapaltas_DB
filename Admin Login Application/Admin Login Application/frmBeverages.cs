using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;
using MsRepository;
using TypeLib;

namespace Admin_Login_Application
{
    public partial class frmBeverages : Form
    {
        public frmBeverages()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            using (IRepository repo = RepositoryFactory.Create())
            {
                try
                {
                    var save = await repo.AddBeverage(new Beverage { Name = txtName.Text.Trim(), Price = float.Parse(txtPrice.Text) });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need To Fill The Boxes To Save");
                }

                ClearBeverage();
                FillLstBeverages();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (IRepository repo = RepositoryFactory.Create())
            {

                int id = (int)lstBeverage.SelectedItems[0].Tag;
                try
                {
                    var update = await repo.EditBeverage(new Beverage { ID = id, Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                    MessageBox.Show("Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need To Fill The Boxes To Update");
                }

                FillLstBeverages();
                CancelBeverage();
                ClearBeverage();


            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (IRepository repo = RepositoryFactory.Create())
            {

                if (MessageBox.Show("Are You Sure To Delete This Record?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        var delete = await repo.DeleteBeverage(new Beverage { Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                        FillLstBeverages();
                        ClearBeverage();
                        CancelBeverage();
                        MessageBox.Show("Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        FillLstBeverages();
                        ClearBeverage();
                        CancelBeverage();
                        MessageBox.Show("Deleted Successfully");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearBeverage();
            CancelBeverage();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmProducts frmProducts = new frmProducts();
            this.Hide();
            frmProducts.Show();
        }

        private void frmBeverages_Load(object sender, EventArgs e)
        {
            FillLstBeverages();
            ClearBeverage();
        }

        private void lstBeverage_Click(object sender, EventArgs e)
        {
            SelectBeverage();
        }

        void ClearBeverage()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }
        void CancelBeverage()
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        void SelectBeverage()
        {
            ListViewItem row = lstBeverage.SelectedItems[0];
            txtName.Text = row.Text;
            txtPrice.Text = row.SubItems[1].Text;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }
        private async void FillLstBeverages()
        {
            lstBeverage.Items.Clear();
            IEnumerable<Beverage> beverages;
            using (IRepository repo = RepositoryFactory.Create())
            {
                beverages = await repo.GetBeverages();
            }
            foreach (Beverage beverage in beverages)
            {
                ListViewItem newPizza = new ListViewItem();
                newPizza.Tag = beverage.ID;
                newPizza.Text = beverage.Name;
                newPizza.SubItems.Add(beverage.Price.ToString());
                lstBeverage.Items.Add(newPizza);
            }
        }
    }
}
