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
    public partial class AddSupplier : Form
    {
        private bool isAddMode;
        private int supplierId;
        private SuppliersMain supplier;
        public AddSupplier(SuppliersMain parentform ,int id , string fname , string lname , string contact , string email , string address ,bool isAddMode = false)
        {
            InitializeComponent();
            this.isAddMode = isAddMode;
            this.supplierId = id;
            textBox1.Text = fname;
            textBox2.Text = lname;
            textBox3.Text = contact;
            textBox4.Text = email;
            textBox5.Text = address;
            this.supplier = parentform;
        }
        public AddSupplier(SuppliersMain parentform, bool isAddMode = false)
        {
            InitializeComponent();
            this.isAddMode = isAddMode;
            this.supplier = parentform;
            
        }
        private void AddSupplier_Load(object sender, EventArgs e)
        {
            if (isAddMode)
            {
                dynamic.Text = "Add Supplier";
                Addbtn.Visible = true;
                updatebtn.Visible = false;
            }
            else
            {
                dynamic.Text = "Edit Supplier";
                Addbtn.Visible = false;
                updatebtn.Visible = true;
            }

        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            string firstname = textBox1.Text;
            string lname = textBox2.Text;
            string contact = textBox3.Text;
            string email = textBox4.Text;
            string address = textBox5.Text;

            SupplierBL supplier = new SupplierBL(firstname, lname, contact, email, address);
            SupplierDL.AddSupplier(supplier);
            MessageBox.Show("Supplier added successfully");
            this.supplier.loaddata();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string firstname = textBox1.Text;
            string lname = textBox2.Text;
            string contact = textBox3.Text;
            string email = textBox4.Text;
            string address = textBox5.Text;

            SupplierBL supplier = new SupplierBL(firstname , lname, contact,email ,address);
            SupplierDL.UpdateSupplier(supplier , supplierId);
            MessageBox.Show("Supplier Updated successfully");
            this.supplier.loaddata();
        }
    }
}
