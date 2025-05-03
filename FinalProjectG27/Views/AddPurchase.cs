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
    public partial class AddPurchase : Form
    {
        private bool isAdd;
        public AddPurchase(bool isAdd = false)
        {
            InitializeComponent();
            this.isAdd = isAdd;
        }

        private void AddPurchase_Load(object sender, EventArgs e)
        {
            if (isAdd)
            {
                Category.Text = "Add Purchase Order";
                Addbtn.Visible = true;
                updatebtn.Visible = false;
                addproductbtn.Visible = true;
                pictureBox1.Visible = true;
                status.Visible = false;
                statuslabel.Visible = false;

            }
            else
            {
                Category.Text = "Edit Purchase Order";
                Addbtn.Visible = false;
                updatebtn.Visible = true;
                addproductbtn.Visible = false;
                pictureBox1.Visible = false;
                status.Visible = true;
                statuslabel.Visible = true;
            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

        }

        private void addproductbtn_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddOrderProducts addorder = new AddOrderProducts();
            addorder.TopMost = true;
            addorder.ShowDialog();
            dimForm.Close();

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddOrderProducts addorder = new AddOrderProducts();
            addorder.TopMost = true;
            addorder.ShowDialog();
            dimForm.Close();
        }
    }
}
