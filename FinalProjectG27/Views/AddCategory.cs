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
    public partial class AddCategory : Form
    {
        private bool isAdd;

        public AddCategory(bool isAdd=false)
        {
            InitializeComponent();
            this.isAdd = isAdd;
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            if (isAdd) 
            {
                Category.Text = "Add Category";
                addbtn.Visible = true;
                editbtn.Visible = false;

            }
            else
            {
                Category.Text = "Edit Category";
                addbtn.Visible = false;
                editbtn.Visible = true;
            }

        }
    }
}
