using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Controllers;
using FinalProjectG27.Database;
using FinalProjectG27.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProjectG27.Views
{
    public partial class AddStockTransfer : Form
    {
        private bool isAdd;
        private int Id;
        private StockTransferMain main;

        public AddStockTransfer(StockTransferMain main, bool isAdd = true)
        {
            InitializeComponent();
            loadinwarehouse();
            loadinproducts();
            this.main = main;
            this.isAdd = isAdd;
            add.Text = "Add Transfer";
            addbtn.Visible = true;
            editbtn.Visible = false;
        }

        public AddStockTransfer(StockTransferMain main, int id, string warehouse, string product, int qu, string note, bool isAdd = false)
        {
            InitializeComponent();
            loadinwarehouse();
            loadinproducts();
            this.main = main;
            add.Text = "Edit Transfer";
            addbtn.Visible = false;
            editbtn.Visible = true;
            Id = id;
            this.isAdd = isAdd;
            comboBox2.SelectedItem = warehouse;
            comboBox1.SelectedItem = product;
            textBox2.Text=qu.ToString();
            textBox5.Text=note;

        }

        public AddStockTransfer(bool isAdd = false)
        {
            InitializeComponent();
        }
        private void AddStockTransfer_Load(object sender, EventArgs e)
        {

        }
        
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string warehouse = comboBox2.SelectedItem.ToString();
                string product = comboBox1.SelectedItem.ToString();
                int quan = int.Parse(textBox2.Text);
                string note = textBox5.Text;

                if (string.IsNullOrEmpty(warehouse) || string.IsNullOrEmpty(product) ||
                    quan < 0 || string.IsNullOrEmpty(note))
                {
                    MessageBox.Show("Please fill out all fields before submitting.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StockTransferBL s = new StockTransferBL(warehouse, product, note, quan);
                bool isAdd = StockTransferDL.Addtransfer(s);

                if (isAdd)
                {
                    MessageBox.Show("Added Successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error. Transfer wasn't added.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string warehouse = comboBox2.SelectedItem.ToString();
                string product = comboBox1.SelectedItem.ToString();
                int quan = int.Parse(textBox2.Text);
                string note = textBox5.Text;

                if (string.IsNullOrEmpty(warehouse) || string.IsNullOrEmpty(product) ||
                    quan < 0 || string.IsNullOrEmpty(note))
                {
                    MessageBox.Show("Please fill out all fields before submitting.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StockTransferBL s = new StockTransferBL(warehouse, product, note, quan);
                StockTransferDL.UpdateTransfer(s, Id);

                MessageBox.Show("Updated Successfully");
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void addbtn_Click(object sender, EventArgs e)
        //{

        //}
    }
}
