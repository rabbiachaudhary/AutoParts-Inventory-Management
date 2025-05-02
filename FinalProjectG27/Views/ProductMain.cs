using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectG27.Views
{
    public partial class ProductMain : Form
    {
        private bool isAddMode;
        public ProductMain(bool isAddMode=true)
        {
            InitializeComponent();
            this.isAddMode = isAddMode;
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
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddProduct addProduct = new AddProduct();
            addProduct.TopMost = true;
            addProduct.ShowDialog();
            dimForm.Close();
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
    }
}
