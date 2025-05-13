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
            string Size = size.Text;
            string Warranty = warranty.Text;
            string category = comboBox1.Text;

            // === Validation ===
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
                MessageBox.Show("Please enter a valid numeric weight.");
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

            if (!decimal.TryParse(pp.Text, out decimal purP) || purP < 0)
            {
                MessageBox.Show("Please enter a valid numeric purchase price.");
                return;
            }

            if (!decimal.TryParse(sp.Text, out decimal saleP) || saleP < 0)
            {
                MessageBox.Show("Please enter a valid numeric sale price.");
                return;
            }

            // Ensure sale price is greater than purchase price
            if (saleP <= purP)
            {
                MessageBox.Show("Sale price must be greater than purchase price.");
                return;
            }

            //// Ensure category is selected from comboBox items
            //bool categoryExists = comboBox1.Items.Cast<string>().Any(item => item.Equals(category, StringComparison.OrdinalIgnoreCase));
            //if (!categoryExists)
            //{
            //    MessageBox.Show("Please select a valid category from the list.");
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            // Get category ID from name
            int categoryId = ProductsDL.GetCategoryIdByName(category);

            // Create product object
            ProductsBL productObj = new ProductsBL(productName, description, weightValue, Size, Warranty, purP, saleP, categoryId);

            // Update product in DB
            ProductsDL.UpdateProduct(productObj, productId);
            productMain.LoadData();
            MessageBox.Show("Updated Successfully");
            this.Close();

        }




        private void Addbtn_Click(object sender, EventArgs e)
        {


            string productName = product.Text;
            string description = des.Text;
            string Size = size.Text;
            string Warranty = warranty.Text;
            string Category = comboBox1.Text;
            //decimal purP, saleP;

            //if (!decimal.TryParse(pp.Text, out purP))
            //{
            //    MessageBox.Show("Please enter a valid Purchase Price (decimal number only).");
            //    return;
            //}

            //if (!decimal.TryParse(sp.Text, out saleP))
            //{
            //    MessageBox.Show("Please enter a valid Sale Price (decimal number only).");
            //    return;
            //}

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

            if (!decimal.TryParse(weight.Text, out decimal Weight) || Weight <= 0)
            {
                MessageBox.Show("Please enter a valid numeric weight.");
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

            if (!decimal.TryParse(pp.Text, out decimal purP) || purP < 0)
            {
                MessageBox.Show("Please enter a valid numeric purchase price.");
                return;
            }

            if (!decimal.TryParse(sp.Text, out decimal saleP) || saleP < 0)
            {
                MessageBox.Show("Please enter a valid numeric sale price.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Category))
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            // Get category ID
            int categoryId = ProductsDL.GetCategoryIdByName(Category);

            // Create product object and add to DB
            ProductsBL Product = new ProductsBL(productName, description, Weight, Size, Warranty, purP, saleP, categoryId);
            bool isadded = ProductsDL.AddProduct(Product);

            if (isadded)
            {
                MessageBox.Show("Product Added Successfully");
                productMain.LoadData();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Product could not be added.");
            }

        }
    }
}
