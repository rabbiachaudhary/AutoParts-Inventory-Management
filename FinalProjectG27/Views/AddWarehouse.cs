using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using FinalProjectG27.Controllers;
using FinalProjectG27.Models;
using System.Net;

namespace FinalProjectG27.Views
{
    public partial class AddWarehouse : Form
    {
        private bool isAdd;
        private int Id;
        private WarehousesMain main;

        public AddWarehouse(WarehousesMain main, bool isAdd = true)
        {
            InitializeComponent();
            this.main = main;
            this.isAdd = isAdd;
            add.Text = "Add warehouse";
            addbtn.Visible = true;
            editbtn.Visible = false;
        }

        public AddWarehouse(WarehousesMain main, int id, string name, string city,string address, string code, bool isAdd = false)
        {
            InitializeComponent();
            this.main = main;
            add.Text = "Edit Warehouse";
            addbtn.Visible = false;
            editbtn.Visible = true;
            Id = id;
            this.isAdd = isAdd;
            citytxt.Text=city;
            nametxt.Text=name;
            addresstxt.Text=address;
            codetxt.Text=code;

        }

        private void AddWarehouse_Load(object sender, EventArgs e)
        {

        }

        private void editbtn_Click(object sender, EventArgs e)
        {

            string Name = nametxt.Text;
            string City = citytxt.Text;
            string Address = addresstxt.Text;
            string Code = codetxt.Text;


            warehousesBL w=new warehousesBL(Name, Address,City,Code);
            warehousesDL.UpdateWarehouses(w, Id);
            main.LoadData();
            MessageBox.Show("Updated Successfully");
            this.Close();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {

            string Name = nametxt.Text;
            string City = citytxt.Text;
            string Address = addresstxt.Text;
            string Code = codetxt.Text;


            warehousesBL w = new warehousesBL(Name, Address, City, Code);
            bool isAdd = warehousesDL.AddWarehouse(w);
            if (isAdd)
            {
                MessageBox.Show("Added Successfully");
                main.LoadData();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error. Warehouse wasnt added.");
            }

        }
    }
}
