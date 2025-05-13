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
    public partial class StockTransferMain : Form
    {
        public StockTransferMain()
        {
            InitializeComponent();
            LoadData();
        }

        private void addpic_Click(object sender, EventArgs e)
        {

            AddStockTransfer a = new AddStockTransfer(this,true);
            a.TopMost = true;
            a.ShowDialog();
            LoadData();
        }

        public DataTable LoadData()
        {
            DataTable dt = StockTransferDL.GetTransfer();
            dataGridView1.DataSource = dt;
            return dt;
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Please select a row first.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Check if required cells have values
                if (selectedRow.Cells["warehouse_name"].Value == null ||
                    selectedRow.Cells[0].Value == null ||
                    selectedRow.Cells["product_name"].Value == null ||
                    selectedRow.Cells["quantity"].Value == null ||
                    selectedRow.Cells["note"].Value == null)
                {
                    MessageBox.Show("Selected row has missing data.", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Safely parse and assign values
                int id = Convert.ToInt32(selectedRow.Cells["transfer_id"].Value);
                string w = selectedRow.Cells["warehouse_name"].Value.ToString();
                string p = selectedRow.Cells["product_name"].Value.ToString();
                int q = int.Parse(selectedRow.Cells["quantity"].Value.ToString());
                string n = selectedRow.Cells["note"].Value.ToString();

                // Open the edit form
                using (AddStockTransfer addC = new AddStockTransfer(this, id, w, p,q, n, false))
                {
                    addC.TopMost = true;
                    addC.ShowDialog();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid data format (e.g., ID must be a number).", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null && (dataGridView1.SelectedRows.Count == 1))
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?",
                                                           "Confirm Deletion",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["warehouse_id"].Value);
                        StockTransferDL.DeleteTransfer(id);
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void product_Click(object sender, EventArgs e)
        {
            ProductMain a=new ProductMain();

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
            EmployeesMain a=new EmployeesMain();

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
            SuppliersMain a=new SuppliersMain();

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
            WarehousesMain a=new WarehousesMain();

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
            StocksMain a=new StocksMain();
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
            SaleOrdersMain a=new SaleOrdersMain();

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
            PurchaseOrderMain a=new PurchaseOrderMain();
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
            CustomersMain a=new CustomersMain();

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
            Reports a=new Reports();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void tableLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string search = textBox1.Text;
            DataTable searchData = StockTransferDL.GetSearchData(search);
            if (searchData != null)
            {
                dataGridView1.DataSource = searchData;
            }
        }
    }
}
