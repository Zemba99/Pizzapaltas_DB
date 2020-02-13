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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        
        private async void btnSave_Click(object sender, EventArgs e)
        {

            using (IRepository rep = RepositoryFactory.Create())
            {
                try
                {
                    var addEmp = await rep.AddEmployee(new Employee { Username = txtUsername.Text.Trim(), Password = int.Parse(txtPassword.Text), Role = int.Parse(txtRole.Text) });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need to Fill the Boxes to Save");
                }
            }

            ClearEmployee();
            FillLstEmployee();

        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete This Record?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (IRepository rep = RepositoryFactory.Create())
                {
                    var deleteEmp = await rep.DeleteEmployee(new Employee { Username = txtUsername.Text, Password = int.Parse(txtPassword.Text), Role = int.Parse(txtRole.Text) });
                }
                ClearEmployee();
                FillLstEmployee();
                CancelEmployee();
                MessageBox.Show("Deleted Successfully");
            }

        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (IRepository rep = RepositoryFactory.Create())
            {
                int empId = (int)lstEmployee.SelectedItems[0].Tag;
                try
                {
                    var addEmp = await rep.EditEmployee(new Employee { ID = empId, Username = txtUsername.Text.Trim(), Password = int.Parse(txtPassword.Text), Role = int.Parse(txtRole.Text) });
                    MessageBox.Show("Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Need to Fill the Boxes to Update");
                }
            }

            ClearEmployee();
            CancelEmployee();
            FillLstEmployee();

        }
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            ClearEmployee();
            FillLstEmployee();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearEmployee();
            CancelEmployee();
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainMenu objfrmMainMenu = new frmMainMenu();
            this.Hide();
            objfrmMainMenu.Show();
        }

        void ClearEmployee()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtRole.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }
        void CancelEmployee()
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        void SelectEmployee()
        {
            ListViewItem row = lstEmployee.SelectedItems[0];
            txtUsername.Text = row.Text;
            txtPassword.Text = row.SubItems[1].Text;
            txtRole.Text = row.SubItems[2].Text;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
        }
        private async void FillLstEmployee()
        {
            lstEmployee.Items.Clear();
            IEnumerable<Employee> employees;
            using (IRepository repo = RepositoryFactory.Create())
            {
                employees = await repo.GetEmployees();
            }
            foreach (Employee employee in employees)
            {
                ListViewItem newPizza = new ListViewItem();
                newPizza.Tag = employee.ID;
                newPizza.Text = employee.Username;
                newPizza.SubItems.Add(employee.Password.ToString());
                newPizza.SubItems.Add(employee.Role.ToString());
                lstEmployee.Items.Add(newPizza);
            }
        }

        private void lstEmployee_Click(object sender, EventArgs e)
        {
            SelectEmployee();
        }


    }
}
