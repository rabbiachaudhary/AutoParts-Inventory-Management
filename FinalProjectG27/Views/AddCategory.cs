﻿using System;
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
        private int categoryId;
        private CategoryMain main;

        public AddCategory(CategoryMain main,bool isAdd=true)
        {
            InitializeComponent();
            this.main = main;
            this.isAdd = isAdd;
            Category.Text = "Add Category";
            addbtn.Visible = true;
            editbtn.Visible = false;
        }

        public AddCategory(CategoryMain main,int id,string Name,string Des,string Tax,string Markup,bool isAdd=false)
        {
            InitializeComponent();
            this.main = main;
            Category.Text = "Edit Category";
            addbtn.Visible = false;
            editbtn.Visible = true;
            categoryId = id;
            this.isAdd = isAdd;
            name.Text = Name;         
            tax.Text = Tax;           
            markup.Text = Markup;
            des.Text = Des;          
           
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {

        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Tax, Markup;

                // First validate Purchase Price
                if (!decimal.TryParse(tax.Text, out Tax))
                {
                    MessageBox.Show("Please enter a valid Tax Price (decimal number only).");
                    return;
                }

                // Then validate Sale Price
                if (!decimal.TryParse(markup.Text, out Markup))
                {
                    MessageBox.Show("Please enter a valid Markup Price (decimal number only).");
                    return;
                }

                string Name = name.Text;
                string Des = des.Text;
                Tax = decimal.Parse(tax.Text);
                Markup = decimal.Parse(markup.Text);

                // Validate Name
                if (string.IsNullOrWhiteSpace(Name))
                {
                    MessageBox.Show("Name is required.");
                    return;
                }

                // Validate Description
                if (string.IsNullOrWhiteSpace(Des))
                {
                    MessageBox.Show("Description is required.");
                    return;
                }

                // Validate Tax
                if (string.IsNullOrWhiteSpace(tax.Text))
                {
                    MessageBox.Show("Please enter a valid, non-negative tax value.");
                    return;
                }

                // Validate Markup
                if (string.IsNullOrWhiteSpace(markup.Text))
                {
                    MessageBox.Show("Please enter a valid, non-negative markup value.");
                    return;
                }

                CategoryBL c = new CategoryBL(Name, Des, Tax, Markup);
                CategoryDL.updateCategory(c, categoryId);
                main.LoadData();
                MessageBox.Show("Updated Successfully");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {

                decimal Tax, Markup;

                // First validate Purchase Price
                if (!decimal.TryParse(tax.Text, out Tax))
                {
                    MessageBox.Show("Please enter a valid Tax Price (decimal number only).");
                    return;
                }

                // Then validate Sale Price
                if (!decimal.TryParse(markup.Text, out Markup))
                {
                    MessageBox.Show("Please enter a valid Markup Price (decimal number only).");
                    return;
                }
                string Name = name.Text;
                string Des = des.Text;
                Tax = decimal.Parse(tax.Text);
                Markup = decimal.Parse(markup.Text);

                // Validate Name
                if (string.IsNullOrWhiteSpace(Name))
                {
                    MessageBox.Show("Name is required.");
                    return;
                }

                // Validate Description
                if (string.IsNullOrWhiteSpace(Des))
                {
                    MessageBox.Show("Description is required.");
                    return;
                }

                // Validate Tax
                if (string.IsNullOrWhiteSpace(tax.Text))
                {
                    MessageBox.Show("Please enter a valid, non-negative tax value.");
                    return;
                }

                // Validate Markup
                if (string.IsNullOrWhiteSpace(markup.Text))
                {
                    MessageBox.Show("Please enter a valid, non-negative markup value.");
                    return;
                }

                CategoryBL c = new CategoryBL(Name, Des, Tax, Markup);
                bool isAdd = CategoryDL.AddCategory(c);
                if (isAdd)
                {
                    MessageBox.Show("Added Successfully");
                    main.LoadData();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }
    }
}
