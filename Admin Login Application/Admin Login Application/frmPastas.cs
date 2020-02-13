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

namespace Admin_Login_Application
{
    public partial class frmPastas : Form
    {
        public frmPastas()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            using (IRepository rep = RepositoryFactory.Create())
            {
                try
                {
                    var savePasta = await rep.AddPasta(new Pasta { Name = txtName.Text.Trim(), Price = float.Parse(txtPrice.Text) });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need To Fill The Boxes To Save");
                }
                ClearPasta();
                FillLstPastas();
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
                        var pastaDelete = await repo.DeletePasta(new Pasta { Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                        FillLstPastas();
                        ClearPasta();
                        CancelPasta();
                        MessageBox.Show("Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        FillLstPastas();
                        ClearPasta();
                        CancelPasta();
                        MessageBox.Show("Deleted Successfully");
                    }
                }
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (IRepository repo = RepositoryFactory.Create())
            {
                PizzaRecipe p = new PizzaRecipe();
                int id = (int)lstPastas.SelectedItems[0].Tag;

                try
                {
                    var pizzaUpdate = await repo.EditPasta(new Pasta { ID = id, Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                    MessageBox.Show("Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need To Fill The Boxes To Update");
                }
                FillLstPastas();
                CancelPasta();
                ClearPasta();

            }
        }


        private void frmPastas_Load(object sender, EventArgs e)
        {
            ClearPasta();
            FillLstPastas();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearPasta();
            CancelPasta();
        }

        private void lstPastas_Click(object sender, EventArgs e)
        {
            SelectPasta();
        }

        void ClearPasta()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }
        void CancelPasta()
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        void SelectPasta()
        {
            ListViewItem row = lstPastas.SelectedItems[0];
            txtName.Text = row.Text;
            txtPrice.Text = row.SubItems[1].Text;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }
        private async void FillLstPastas()
        {
            lstPastas.Items.Clear();
            IEnumerable<Pasta> pastas;
            using (IRepository repo = RepositoryFactory.Create())
            {
                pastas = await repo.GetPastas();
            }
            foreach (Pasta pasta in pastas)
            {
                ListViewItem newPizza = new ListViewItem();
                newPizza.Tag = pasta.ID;
                newPizza.Text = pasta.Name;
                newPizza.SubItems.Add(pasta.Price.ToString());
                lstPastas.Items.Add(newPizza);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmProducts objfrmPastas = new frmProducts();
            this.Hide();
            objfrmPastas.Show();
        }


    }
}
