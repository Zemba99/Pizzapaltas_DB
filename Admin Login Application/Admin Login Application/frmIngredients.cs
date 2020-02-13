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
    public partial class frmIngredients : Form
    {
        public frmIngredients()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            using (IRepository repo = RepositoryFactory.Create())
            {
                try
                {
                    var ingredientSave = await repo.AddIngredient(new Ingredient { Name = txtName.Text.Trim(), Price = float.Parse(txtPrice.Text) });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need To Fill The Boxes To Save");
                }

                ClearIngredient();
                FillLstIngredients();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (IRepository repo = RepositoryFactory.Create())
            {

                int id = (int)lstIngredient.SelectedItems[0].Tag;
                try
                {
                    var ingredientUpdate = await repo.EditIngredient(new Ingredient { ID = id, Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                    MessageBox.Show("Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need To Fill The Boxes To Update");
                }

                FillLstIngredients();
                CancelIngredient();
                ClearIngredient();


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
                        var ingredientDelete = await repo.DeleteIngredient(new Ingredient { Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                        FillLstIngredients();
                        ClearIngredient();
                        CancelIngredient();
                        MessageBox.Show("Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        FillLstIngredients();
                        ClearIngredient();
                        CancelIngredient();
                        MessageBox.Show("Deleted Successfully");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelIngredient();
            ClearIngredient();
        }

        private void lstIngredient_Click(object sender, EventArgs e)
        {
            SelectIngredient();
        }

        private void frmIngredients_Load(object sender, EventArgs e)
        {
            FillLstIngredients();
            ClearIngredient();
        }

        void ClearIngredient()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }
        void CancelIngredient()
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        void SelectIngredient()
        {
            ListViewItem row = lstIngredient.SelectedItems[0];
            txtName.Text = row.Text;
            txtPrice.Text = row.SubItems[1].Text;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }
        private async void FillLstIngredients()
        {
            lstIngredient.Items.Clear();
            IEnumerable<Ingredient> ingredients;
            using (IRepository repo = RepositoryFactory.Create())
            {
                ingredients = await repo.GetIngredients();
            }
            foreach (Ingredient ingredient in ingredients)
            {
                ListViewItem newPizza = new ListViewItem();
                newPizza.Tag = ingredient.ID;
                newPizza.Text = ingredient.Name;
                newPizza.SubItems.Add(ingredient.Price.ToString());
                lstIngredient.Items.Add(newPizza);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainMenu frmMainMenu = new frmMainMenu();
            this.Hide();
            frmMainMenu.Show();
        }
    }
}
