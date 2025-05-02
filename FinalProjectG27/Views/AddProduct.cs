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
    public partial class AddProduct : Form
    {
        private bool iaAddMode;
        public AddProduct(bool iaAddMode=false)
        {
            InitializeComponent();
            this.iaAddMode = iaAddMode;
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
    }
}
