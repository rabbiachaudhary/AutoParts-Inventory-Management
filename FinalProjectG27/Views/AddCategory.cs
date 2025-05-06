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

        private void editbtn_Click(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string Name = name.Text;
            string Des=des.Text;
            decimal Tax=decimal.Parse(tax.Text);
            decimal Markup = decimal.Parse(markup.Text);

            CategoryBL c =new CategoryBL(Name, Des, Tax, Markup);
           bool isAdd= CategoryDL.AddCategory(c);
            if (isAdd)
            {
                MessageBox.Show("Added Successfully");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
