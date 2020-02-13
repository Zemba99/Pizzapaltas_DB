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
    public partial class frmSallads : Form
    {
        public frmSallads()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            using (IRepository repo = RepositoryFactory.Create())
            {
                try
                {
                    var save = await repo.AddSallad(new Sallad { Name = txtName.Text.Trim(), Price = float.Parse(txtPrice.Text) });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need To Fill The Boxes To Save");
                }

                ClearSallad();
                FillLstSallads();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (IRepository repo = RepositoryFactory.Create())
            {

                int id = (int)lstSallad.SelectedItems[0].Tag;
                try
                {
                    var update = await repo.EditSallad(new Sallad { ID = id, Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                    MessageBox.Show("Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need To Fill The Boxes To Update");
                }
                
                FillLstSallads();
                CancelSallad();
                ClearSallad();
                

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
                        var delete = await repo.DeleteSallad(new Sallad { Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                        FillLstSallads();
                        ClearSallad();
                        CancelSallad();
                        MessageBox.Show("Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        FillLstSallads();
                        ClearSallad();
                        CancelSallad();
                        MessageBox.Show("Deleted Successfully");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearSallad();
            CancelSallad();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmProducts frmProducts = new frmProducts();
            this.Hide();
            frmProducts.Show();
        }

        private void frmSallads_Load(object sender, EventArgs e)
        {
            FillLstSallads();
            ClearSallad();
        }

        private void lstSallad_Click(object sender, EventArgs e)
        {
            SelectSallad();
        }
        void ClearSallad()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }
        void CancelSallad()
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        void SelectSallad()
        {
            ListViewItem row = lstSallad.SelectedItems[0];
            txtName.Text = row.Text;
            txtPrice.Text = row.SubItems[1].Text;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }
        private async void FillLstSallads()
        {
            lstSallad.Items.Clear();
            IEnumerable<Sallad> sallads;
            using (IRepository repo = RepositoryFactory.Create())
            {
                sallads = await repo.GetSallads();
            }
            foreach (Sallad sallad in sallads)
            {
                ListViewItem newPizza = new ListViewItem();
                newPizza.Tag = sallad.ID;
                newPizza.Text = sallad.Name;
                newPizza.SubItems.Add(sallad.Price.ToString());
                lstSallad.Items.Add(newPizza);
            }
        }
    }
}
