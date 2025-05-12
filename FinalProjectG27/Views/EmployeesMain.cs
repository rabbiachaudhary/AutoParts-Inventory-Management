using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Controllers;

namespace FinalProjectG27.Views
{
    public partial class EmployeesMain : Form
    {
        public EmployeesMain()
        {
            InitializeComponent();

            loaddata();
        }

        private void addpic_Click(object sender, EventArgs e)
        {

            //dimForm dimForm = new dimForm();
            //dimForm.Show();
            AddEmployeee a = new AddEmployeee(this,true);
            a.TopMost = true;
            a.ShowDialog();
            //dimForm.Close();
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count ==1)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["staff_id"].Value);

                string fname = dataGridView1.CurrentRow.Cells["first_name"].Value.ToString();
                string lname = dataGridView1.CurrentRow.Cells["last_name"].Value.ToString();
                string contact = dataGridView1.CurrentRow.Cells["Contact"].Value.ToString();
                string email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                string address = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
                string status = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();

                string username = dataGridView1.CurrentRow.Cells["username"].Value.ToString();
                string password_hash = dataGridView1.CurrentRow.Cells["password_hash"].Value.ToString();
                string role = dataGridView1.CurrentRow.Cells["value"].Value.ToString();

                //dimForm dimForm = new dimForm();
                //dimForm.Show();
                AddEmployeee a = new AddEmployeee(this, id, fname, lname, contact, email, address, status,username,password_hash,role, false);
                a.TopMost = true;
                a.ShowDialog();
                //dimForm.Close();
            }

            else
            {
                MessageBox.Show("Please Select a row first");
            }
        }

        private void EmployeesMain_Load(object sender, EventArgs e)
        {

        }
        private void loaddata()
        {
            DataTable dt = new DataTable();
            dt = staffDL.GetStaff();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            ProductMain a = new ProductMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            EmployeesMain a = new EmployeesMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void tableLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {

        }
        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count == 1)
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?",
                                                           "Confirm Deletion",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["staff_id"].Value);
                        staffDL.DeleteStaff(id);
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddata();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (IndexOutOfRangeException ie)
            {
                MessageBox.Show("No row selected properly: " + ie.Message, "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public DataTable LoadData()
        {
            DataTable dt = staffDL.GetStaff();
            dataGridView1.DataSource = dt;
            return dt;
        }

        private void product_Click(object sender, EventArgs e)
        {
            ProductMain a = new ProductMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void employee_Click(object sender, EventArgs e)
        {
            EmployeesMain a = new EmployeesMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void orders_Click(object sender, EventArgs e)
        {
            SuppliersMain a = new SuppliersMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void suppliers_Click(object sender, EventArgs e)
        {
            WarehousesMain a = new WarehousesMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void stock_Click(object sender, EventArgs e)
        {
            StocksMain a = new StocksMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void sales_Click(object sender, EventArgs e)
        {
            SaleOrdersMain a = new SaleOrdersMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void purchase_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain a = new PurchaseOrderMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void customers_Click(object sender, EventArgs e)
        {
            CustomersMain a = new CustomersMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void reports_Click(object sender, EventArgs e)
        {
            Reports a = new Reports();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            DataTable searchData = staffDL.GetSearchData(search);
            if (searchData != null)
            {
                dataGridView1.DataSource = searchData;
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text;
        }
    }
}
