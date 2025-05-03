using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProjectG27.Views
{
    public partial class AddSale : Form
    {
        private bool isAdd;
        public AddSale(bool isAdd = false)
        {
            InitializeComponent();
            this.isAdd = isAdd;
        }

        private void AddSale_Load(object sender, EventArgs e)
        {
            if (isAdd)
            {
                Category.Text = "Add Sale Order";
                Addbtn.Visible = true;
                updatebtn.Visible = false;
                addproductbtn.Visible = true;
                pictureBox1.Visible = true;
                status.Visible = false;
                statuslabel.Visible = false;

            }
            else
            {
                Category.Text = "Edit Sale Order";
                Addbtn.Visible = false;
                updatebtn.Visible = true;
                addproductbtn.Visible = false;
                pictureBox1.Visible = false;
                status.Visible = true;
                statuslabel.Visible = true;
            }

        }


        private void Addbtn_Click(object sender, EventArgs e)
        {

        }

        private void addproductbtn_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddSaleProducts saleproduct = new AddSaleProducts();
            saleproduct.TopMost = true;
            saleproduct.ShowDialog();
            dimForm.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddSaleProducts saleproduct = new AddSaleProducts();
            saleproduct.TopMost = true;
            saleproduct.ShowDialog();
            dimForm.Close();
        }
    }
}
