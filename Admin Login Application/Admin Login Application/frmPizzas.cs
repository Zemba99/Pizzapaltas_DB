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
    public partial class frmPizzas : Form
    {
        public frmPizzas()
        {
            InitializeComponent();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {

            using (IRepository repo = RepositoryFactory.Create())
            {
                try
                {
                    var pizzaSave = await repo.AddPizza(new PizzaRecipe { Name = txtName.Text.Trim(), Price = float.Parse(txtPrice.Text) });
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("You Need To Fill The Boxes To Save");
                }

                ClearPizza();
                FillLstPizzas();
            }



        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
           


            if (MessageBox.Show("Are You Sure To Delete This Record?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (IRepository repo = RepositoryFactory.Create())
                    {
                        var pizzaDeleteByID = await repo.DeletePizza(new PizzaRecipe { Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                    }
                    FillLstPizzas();
                    ClearPizza();
                    CancelPizza();
                    MessageBox.Show("Deleted Successfully");

                }
                catch (Exception ex)
                {
                    FillLstPizzas();
                    ClearPizza();
                    CancelPizza();
                    MessageBox.Show("Deleted Successfully");
                }
            }
            

        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (IRepository repo = RepositoryFactory.Create())
            {
                PizzaRecipe p = new PizzaRecipe();
                int id = (int)lstPizzas.SelectedItems[0].Tag;

                try
                {
                    var pizzaUpdate = await repo.EditPizza(new PizzaRecipe { ID = id, Name = txtName.Text, Price = float.Parse(txtPrice.Text) });
                    MessageBox.Show("Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need To Fill The Boxes To Update");

                }
                FillLstPizzas();
                CancelPizza();
                ClearPizza();
            }
        }

        private void frmPizzas_Load(object sender, EventArgs e)
        {
            ClearPizza();
            FillLstPizzas();
        }
        private void lstPizzas_Click(object sender, EventArgs e)
        {
            SelectPizza();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelPizza();
            ClearPizza();
        }
        void ClearPizza()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            
        }
        void CancelPizza()
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        void SelectPizza()
        {
            ListViewItem row = lstPizzas.SelectedItems[0];
            txtName.Text = row.Text;
            txtPrice.Text = row.SubItems[1].Text;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }
        private async void FillLstPizzas()
        {
            lstPizzas.Items.Clear();
            IEnumerable<PizzaRecipe> pizzas;
            using (IRepository repo = RepositoryFactory.Create())
            {
                pizzas=await repo.GetPizzas();
            }
            foreach(PizzaRecipe pizza in pizzas)
            {
                ListViewItem newPizza = new ListViewItem();
                newPizza.Tag = pizza.ID;
                newPizza.Text = pizza.Name;
                newPizza.SubItems.Add(pizza.Price.ToString());
                lstPizzas.Items.Add(newPizza);
            }
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            frmProducts objfrmPizzas = new frmProducts();
            this.Hide();
            objfrmPizzas.Show();
        }


        // Not being used
        private void dgvPizza_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmPizzas_Shown(object sender, EventArgs e)
        {

        }


    }
}
