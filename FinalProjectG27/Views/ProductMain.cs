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
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddProduct addProduct = new AddProduct(true);
            addProduct.TopMost = true;
            addProduct.ShowDialog();
            dimForm.Close();

        }

        private void ProductMain_Load(object sender, EventArgs e)
        {
            
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            //dimForm dimForm = new dimForm();
            //dimForm.Show();

            if (dgvProducts.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Product_ID"].Value);

                string name = dgvProducts.CurrentRow.Cells["ProductName"].Value.ToString();
                string d = dgvProducts.CurrentRow.Cells["Description"].Value.ToString();
                // Get category ID from DataGridView
                int categoryId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["Category"].Value);

                // Convert category ID to category name
                string cn = ProductsDL.GetCategoryNameById(categoryId);
                string w = dgvProducts.CurrentRow.Cells["Weight"].Value.ToString();
                string s = dgvProducts.CurrentRow.Cells["Size"].Value.ToString();
                string war = dgvProducts.CurrentRow.Cells["Warranty"].Value.ToString();
                string sp = dgvProducts.CurrentRow.Cells["Sale_Price"].Value.ToString();
                string pp = dgvProducts.CurrentRow.Cells["Purchase_price"].Value.ToString();

                AddProduct addProduct = new AddProduct(id,name,d,cn,w,s,war,pp,sp,false);
                addProduct.TopMost = true;
                addProduct.ShowDialog();
            }

            else
            {
                MessageBox.Show("Error");
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
        private DataTable LoadData()
        {
            DataTable dt = ProductsDL.GetData();
            dgvProducts.DataSource = dt;
            return dt;
        }
    }
}
