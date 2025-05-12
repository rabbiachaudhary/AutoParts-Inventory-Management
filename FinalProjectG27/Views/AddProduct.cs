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
using FinalProjectG27.Models;


namespace FinalProjectG27.Views
{
    public partial class AddProduct : Form
    {
        private bool iaAddMode;
        private int productId;
        private ProductMain productMain;
        //update constructor
        public AddProduct(int id, ProductMain productMain ,string name, string Des, string Category, string Weight, string Size, string Warranty, string purp, string salep, bool iaAddMode = false)
        {
            InitializeComponent();
            FillComboBoxWithCategories();
            this.iaAddMode = iaAddMode;
            this.productMain = productMain;
            productId = id;
            product.Text = name;
            des.Text = Des;
            comboBox1.Text = Category;
            weight.Text = Weight;
            warranty.Text = Warranty;
            size.Text = Size;
            pp.Text = purp;
            sp.Text = salep;
        }
        public AddProduct(ProductMain productMain,bool iaAddMode = false)
        {
            InitializeComponent();
            FillComboBoxWithCategories();
            this.iaAddMode = iaAddMode;
            this.productMain= productMain;
        }

        private void FillComboBoxWithCategories()
        {
            try
            {
                DataTable dt = CategoryDL.GetAllCategories();

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "name";                    // What user sees
                comboBox1.ValueMember = "category_id";              // ID behind the scenes

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load categories: " + ex.Message);
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            if (iaAddMode)
            {
                dynamic.Text = "Add Product";
                Addbtn.Visible = true;
                updatebtn.Visible = false;
            }
            else
            {
                dynamic.Text = "Edit Product";
                Addbtn.Visible = false;
                updatebtn.Visible = true;
            }




        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

            string productName = product.Text;
            string description = des.Text;
            decimal purP, saleP, Weight;

            // First validate Purchase Price
            if (!decimal.TryParse(pp.Text, out purP))
            {
                MessageBox.Show("Please enter a valid Purchase Price (decimal number only).");
                return;
            }

            // Then validate Sale Price
            if (!decimal.TryParse(sp.Text, out saleP))
            {
                MessageBox.Show("Please enter a valid Sale Price (decimal number only).");
                return;
            }

            // Now validate Weight
            if (!decimal.TryParse(weight.Text, out Weight))
            {
                MessageBox.Show("Please enter a valid Weight (decimal number only).");
                return;
            }

             Weight = decimal.Parse(weight.Text);
            string Size = size.Text;
            string Warranty = warranty.Text;

             purP = decimal.Parse(pp.Text);
             saleP = decimal.Parse(sp.Text);

            string Category = comboBox1.Text;

            // Validation Checks
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Product name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Description is required.");
                return;
            }

            if (!decimal.TryParse(weight.Text, out decimal weightValue) || weightValue <= 0)
            {
                MessageBox.Show("Please enter a valid weight.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Size))
            {
                MessageBox.Show("Size is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Warranty))
            {
                MessageBox.Show("Warranty is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(pp.Text))
            {
                MessageBox.Show("Please enter a valid purchase price.");
                return;
            }

            if (string.IsNullOrWhiteSpace(sp.Text))
            {
                MessageBox.Show("Please enter a valid sale price.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Category))
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            int categoryId = ProductsDL.GetCategoryIdByName(Category);

            ProductsBL Product = new ProductsBL(productName, description, Weight, Size, Warranty, purP, saleP, categoryId);
            ProductsDL.UpdateProduct(Product, productId);
            productMain.LoadData();
            MessageBox.Show("Updated Successfully");
            this.Close();
        }


    

        private void Addbtn_Click(object sender, EventArgs e)
        {


            string productName = product.Text;
            string description = des.Text;
            decimal purP, saleP, Weight;

            // First validate Purchase Price
            if (!decimal.TryParse(pp.Text, out purP))
            {
                MessageBox.Show("Please enter a valid Purchase Price (decimal number only).");
                return;
            }

            // Then validate Sale Price
            if (!decimal.TryParse(sp.Text, out saleP))
            {
                MessageBox.Show("Please enter a valid Sale Price (decimal number only).");
                return;
            }

            // Now validate Weight
            if (!decimal.TryParse(weight.Text, out Weight))
            {
                MessageBox.Show("Please enter a valid Weight (decimal number only).");
                return;
            }
            Weight = decimal.Parse(weight.Text);
            string Size = size.Text;
            string Warranty = warranty.Text;

             purP = decimal.Parse(pp.Text);
             saleP = decimal.Parse(sp.Text);

            string Category = comboBox1.Text;

            if (!decimal.TryParse(pp.Text, out purP))
            {
                MessageBox.Show("Please enter a valid Purchase Price (decimal number only).");
                return;
            }

            if (!decimal.TryParse(sp.Text, out saleP))
            {
                MessageBox.Show("Please enter a valid Sale Price (decimal number only).");
                return;
            }

            // Validation Checks
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Product name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Description is required.");
                return;
            }

            if (!decimal.TryParse(weight.Text, out decimal weightValue) || weightValue <= 0)
            {
                MessageBox.Show("Please enter a valid weight.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Size))
            {
                MessageBox.Show("Size is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Warranty))
            {
                MessageBox.Show("Warranty is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(pp.Text))
            {
                MessageBox.Show("Please enter a valid purchase price.");
                return;
            }

            if (string.IsNullOrWhiteSpace(sp.Text))
            {
                MessageBox.Show("Please enter a valid sale price.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Category))
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            int categoryId = ProductsDL.GetCategoryIdByName(Category);

            ProductsBL Product =new ProductsBL(productName,description,Weight,Size,Warranty,purP,saleP,categoryId);
            bool isadded =ProductsDL.AddProduct(Product);
            if (isadded)
            {
                MessageBox.Show("Product Added Successfully");
                productMain.LoadData();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
