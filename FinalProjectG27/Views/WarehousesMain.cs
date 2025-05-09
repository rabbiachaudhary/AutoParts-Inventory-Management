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
    public partial class WarehousesMain : Form
    {
        public WarehousesMain()
        {
            InitializeComponent();
            LoadData();
            dgvWarehouse.Columns["warehouse_id"].Visible = true;

        }

        private void addpic_Click(object sender, EventArgs e)
        {
            //dimForm dimForm = new dimForm();
            //dimForm.Show();
            AddWarehouse a = new AddWarehouse(this,true);
            a.TopMost = true;
            a.ShowDialog();
            //dimForm.Close();

        }
        private void editpic_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvWarehouse.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row first.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dgvWarehouse.SelectedRows[0];

                // Check if required cells have values
                if (selectedRow.Cells["warehouse_id"].Value == null ||
                    selectedRow.Cells[0].Value == null ||
                    selectedRow.Cells["Address"].Value == null ||
                    selectedRow.Cells["City"].Value == null ||
                    selectedRow.Cells["postal_code"].Value == null)
                {
                    MessageBox.Show("Selected row has missing data.", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Safely parse and assign values
                int id = Convert.ToInt32(selectedRow.Cells["warehouse_id"].Value);
                string name = selectedRow.Cells[0].Value.ToString();
                string Address = selectedRow.Cells["Address"].Value.ToString();
                string City = selectedRow.Cells["City"].Value.ToString();
                string Code = selectedRow.Cells["postal_code"].Value.ToString();

                // Open the edit form
                using (AddWarehouse addC = new AddWarehouse(this, id, name, City, Address, Code, false))
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
        public DataTable LoadData()
        {
            DataTable dt = warehousesDL.GetWarehouses();
            dgvWarehouse.DataSource = dt;
            return dt;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvWarehouse.CurrentRow != null)
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?",
                                                           "Confirm Deletion",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvWarehouse.SelectedRows[0].Cells["warehouse_id"].Value);
                        warehousesDL.DeleteWarehouse(id);
                        dgvWarehouse.Rows.Remove(dgvWarehouse.CurrentRow);
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


    }
}
