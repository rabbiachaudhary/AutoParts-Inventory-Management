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
    public partial class SuppliersMain : Form
    {
        public SuppliersMain()
        {
            InitializeComponent();
            dataGridView1.Columns["id"].Visible = false;
            loaddata();
           
        }

        private void addsupplier_Click(object sender, EventArgs e)
        {
            
            AddSupplier supplier = new AddSupplier(this,true);
            supplier.TopMost = true;
            supplier.ShowDialog();
            
        }

        private void editsupplier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                string fname = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
                string lname = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
                string contact = dataGridView1.CurrentRow.Cells["Contact"].Value.ToString();
                string email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                string address = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
               

                
                AddSupplier supplier = new AddSupplier(this,id ,fname , lname , contact , email , address);
                supplier.TopMost = true;
                supplier.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Please Select on Row ");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            DataTable searchData = SupplierDL.GetSearchData(search);
            if (searchData != null)
            {
                dataGridView1.DataSource = searchData;
            }
        }
        public void loaddata()
        {
            DataTable dt = new DataTable();
            dt = SupplierDL.GetSupplier();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void deletesupplier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                SupplierDL.DeleteSupplier(id);
                MessageBox.Show("Supplier deleted successfully");
                loaddata();
            }
            else
            {
                MessageBox.Show("Please select one row ");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            MainDashBoard a = new MainDashBoard();
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

        private void label6_Click(object sender, EventArgs e)
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

        private void label8_Click(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
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

        private void label11_Click(object sender, EventArgs e)
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

        private void label12_Click(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {
            CustomersMain c = new CustomersMain();
            c.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                c.Size = this.Size;
                c.Location = this.Location;
            }
            c.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login l     = new Login();
            l.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                l.Size = this.Size;
                l.Location = this.Location;
            }
            l.Show();
            this.Hide();

        }
    }
}
