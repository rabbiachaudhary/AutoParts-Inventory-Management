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
    public partial class PurchaseOrderMain : Form
    {
        public PurchaseOrderMain()
        {
            InitializeComponent();
            loaddata();
            dataGridView1.Columns["payment_id"].Visible = false;
            dataGridView1.Columns["supplier_id"].Visible = false;
            dataGridView1.Columns["warehouse_id"].Visible = false;
            
        }

        private void addpic_Click(object sender, EventArgs e)
        {

            
            AddPurchase purchase = new AddPurchase(this,true);
            purchase.TopMost = true;
            purchase.ShowDialog();
            
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["orderid"].Value);
                int supplierid = Convert.ToInt32(row.Cells["supplier_id"].Value);
                int warehouseid = Convert.ToInt32(row.Cells["warehouse_id"].Value);
                int paymentid = Convert.ToInt32(row.Cells["payment_id"].Value);
                string status = row.Cells["Status"].Value?.ToString();
                DateTime date = Convert.ToDateTime(row.Cells["Date"].Value);

                AddPurchase purchase = new AddPurchase(this ,id, supplierid, warehouseid, paymentid, status, date);
                purchase.TopMost = true;
                purchase.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select one row ");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            DataTable searchData = PurchaseOrderDL.GetSearchData(search);
            if (searchData != null)
            {
                dataGridView1.DataSource = searchData;
            }
        }
        public void loaddata()
        {
            DataTable dt = new DataTable();
            dt = PurchaseOrderDL.Getorder();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["orderid"].Value);

                PurchaseOrderDL.DeleteOrder(id);
                MessageBox.Show("Order deleted successfully");
                loaddata(); 
            }
            else
            {
                MessageBox.Show("Please select one row ");
            }
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

        private void label11_Click(object sender, EventArgs e)
        {
            SuppliersMain s = new SuppliersMain();
            s.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                s.Size = this.Size;
                s.Location = this.Location;
            }
            s.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Login l = new Login();
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
