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
    public partial class AddProduct : Form
    {
        private bool iaAddMode;
        private int productId;
        private ProductMain productMain;
        //update constructor
        public AddProduct(int id, ProductMain productMain ,string name, string Des, string Category, string Weight, string Size, string Warranty, string purp, string salep, bool iaAddMode = false)
        {
            InitializeComponent();
            this.iaAddMode = iaAddMode;
            this.productMain = productMain;
            productId = id;
            product.Text = name;
            des.Text = Des;
            category.Text = Category;
            weight.Text = Weight;
            warranty.Text = Warranty;
            size.Text = Size;
            pp.Text = purp;
            sp.Text = salep;
        }
        public AddProduct(ProductMain productMain,bool iaAddMode = false)
        {
            InitializeComponent();
            this.iaAddMode = iaAddMode;
            this.productMain= productMain;
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

            decimal Weight = decimal.Parse(weight.Text);
            string Size = size.Text;
            string Warranty = warranty.Text;

            decimal purP = decimal.Parse(pp.Text);
            decimal saleP = decimal.Parse(sp.Text);

            string Category = category.Text;

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

            decimal Weight = decimal.Parse(weight.Text);
            string Size = size.Text;
            string Warranty = warranty.Text;

            decimal purP = decimal.Parse(pp.Text);
            decimal saleP = decimal.Parse(sp.Text);

            string Category = category.Text;

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
