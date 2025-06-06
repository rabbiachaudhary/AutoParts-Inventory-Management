﻿using System;
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
    public partial class CustomersMain : Form
    {
        public CustomersMain()
        {
            InitializeComponent();
            LoadData();
            dgvcustomer.Columns["customer_id"].Visible = false;
        }
        private void addpic_Click(object sender, EventArgs e)
        {
            //dimForm dimForm = new dimForm();
            //dimForm.Show();
            AddCustomer addCustomer = new AddCustomer(this,true);
            addCustomer.TopMost = true;
            addCustomer.ShowDialog();
            //dimForm.Close();
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            //dimForm dimForm = new dimForm();
            //dimForm.Show();
            if (dgvcustomer.CurrentRow != null)
            {
                if (dgvcustomer.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt32(dgvcustomer.SelectedRows[0].Cells["customer_id"].Value);

                    string fn = dgvcustomer.CurrentRow.Cells["FN"].Value.ToString();
                    string ln = dgvcustomer.CurrentRow.Cells["LN"].Value.ToString();
                    string c = dgvcustomer.CurrentRow.Cells["C"].Value.ToString();
                    string em = dgvcustomer.CurrentRow.Cells["E"].Value.ToString();
                    string a = dgvcustomer.CurrentRow.Cells["A"].Value.ToString();


                    AddCustomer addcustomer = new AddCustomer(this, id, fn, ln, c,em, a,false);
                    addcustomer.TopMost = true;
                    addcustomer.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Please select a row first");
                }
            }
            else
            {
                MessageBox.Show("Please select a row first");
            }
            //dimForm.Close();
        }

        private void CustomersMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public DataTable LoadData()
        {
            DataTable dt = CustomerDL.GetData();
            dgvcustomer.DataSource = dt;
            return dt;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvcustomer.CurrentRow != null && (dgvcustomer.SelectedRows.Count == 1))
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?",
                                                           "Confirm Deletion",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvcustomer.SelectedRows[0].Cells["customer_id"].Value);
                        CustomerDL.DeleteCustomer(id);
                        dgvcustomer.Rows.Remove(dgvcustomer.CurrentRow);
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MainDashBoard mainDashBoard = new MainDashBoard();
            mainDashBoard.StartPosition = FormStartPosition.Manual;
            if (this.WindowState == FormWindowState.Maximized)
            {

                mainDashBoard.WindowState = FormWindowState.Maximized;
            }
            else
            {

                mainDashBoard.Location = this.Location;
            }
            this.Hide();
            mainDashBoard.Show();
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

        private void suppliers_Click(object sender, EventArgs e)
        {

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

        private void cus_TextChanged(object sender, EventArgs e)
        {
            string search = cus.Text.Trim();
            DataTable result = CustomerDL.SearchCustomerByName(search);
            dgvcustomer.DataSource = result;
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
    }
}
