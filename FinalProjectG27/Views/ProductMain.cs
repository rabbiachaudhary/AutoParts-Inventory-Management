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
    public partial class ProductMain : Form
    {
        

     
        public ProductMain()
        {
            InitializeComponent();
            LoadData();
            dgvProducts.Columns["Product_ID"].Visible = false;
        }

        private void ProductMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            //dimForm dimForm = new dimForm();
            //dimForm.Show();
            AddProduct addProduct = new AddProduct(this,true);
            addProduct.TopMost = true;
            addProduct.ShowDialog();
            //dimForm.Close();

        }

        private void ProductMain_Load(object sender, EventArgs e)
        {
            
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            //dimForm dimForm = new dimForm();
            //dimForm.Show();

            if (dgvProducts.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Product_ID"].Value);

                string name = dgvProducts.CurrentRow.Cells["Product_Name"].Value.ToString();
                string d = dgvProducts.CurrentRow.Cells["Description"].Value.ToString();
                                                                                                                       //review this portion for category_id
                int categoryId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["Category"].Value);               
                string cn = ProductsDL.GetCategoryNameById(categoryId);
                string w = dgvProducts.CurrentRow.Cells["Weight"].Value.ToString();
                string s = dgvProducts.CurrentRow.Cells["Sizeof"].Value.ToString();
                string war = dgvProducts.CurrentRow.Cells["Warranty"].Value.ToString();
                string sp = dgvProducts.CurrentRow.Cells["Sale_Price"].Value.ToString();
                string pp = dgvProducts.CurrentRow.Cells["Purchase_price"].Value.ToString();

                AddProduct addProduct = new AddProduct(id,this,name,d,cn,w,s,war,pp,sp,false);
                addProduct.TopMost = true;
                addProduct.ShowDialog();
            }

            else
            {
                MessageBox.Show("Please select a row first");
            }

            //dimForm.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CategoryMain categoryMain = new CategoryMain();
            categoryMain.StartPosition = FormStartPosition.Manual;
            if (this.WindowState == FormWindowState.Maximized)
            {
                categoryMain.WindowState = FormWindowState.Maximized; 
            }
            else
            {
                        
                categoryMain.Location = this.Location;   
            }
            this.Hide();
            categoryMain.Show();
              
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public DataTable LoadData()
        {
            DataTable dt = ProductsDL.GetData();
            dgvProducts.DataSource = dt;
            return dt;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.CurrentRow != null)
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?",
                                                           "Confirm Deletion",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Product_ID"].Value);                                                                                                                         
                        ProductsDL.DeleteProduct(id);                                                                                                                
                        dgvProducts.Rows.Remove(dgvProducts.CurrentRow);
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
                //a.Size = this.Size;
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
                //a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void suppliers_Click(object sender, EventArgs e)
        {
            SuppliersMain a = new SuppliersMain();

            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                //a.Size = this.Size;
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
                //a.Size = this.Size;
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
                //a.Size = this.Size;
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
                //a.Size = this.Size;
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
                //a.Size = this.Size;
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
                //a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void product_Click(object sender, EventArgs e)
        {
            MainDashBoard a = new MainDashBoard();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                //a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void pro_TextChanged(object sender, EventArgs e)
        {
            string search = pro.Text.Trim();
            DataTable result = ProductsDL.SearchProductByName(search);
            dgvProducts.DataSource = result;
        }
    }
}
