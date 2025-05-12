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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProjectG27.Views
{
    public partial class AddSale : Form
    {
        private bool isAdd;
        private int saleid;
        private int saleOrderId;
        private SaleOrdersMain sale ;
        public AddSale(SaleOrdersMain parentform ,int id, int customerid,int paymentid, string status, DateTime date ,bool isAdd = false)
        {
            InitializeComponent();
            this.isAdd = isAdd;
            LoadpaymentData();
            LoadCustomerData();
            this.saleid = id;
            comboBox1.SelectedValue = customerid.ToString();
            comboBox2.SelectedValue = paymentid.ToString();
            dateTimePicker1.Value = date.Date;
            this.sale = parentform;
        }
        public AddSale(SaleOrdersMain parentform, bool isAdd = false)
        {
            InitializeComponent();
            this.isAdd = isAdd;
            LoadpaymentData();
            LoadCustomerData();
            this.sale = parentform;           

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
                combo.Visible = false;
                statuslabel.Visible = false;

            }
            else
            {
                Category.Text = "Edit Sale Order";
                Addbtn.Visible = false;
                updatebtn.Visible = true;
                addproductbtn.Visible = false;
                pictureBox1.Visible = false;
                combo.Visible = true;
                statuslabel.Visible = true;
            }

        }


        private void Addbtn_Click(object sender, EventArgs e)
        {
            int customerId = int.Parse(comboBox1.SelectedValue.ToString());
            int paymentId = int.Parse(comboBox2.SelectedValue.ToString());
            DateTime date = dateTimePicker1.Value.Date;

            SaleOrderBL sale = new SaleOrderBL(customerId, paymentId, date);
            saleOrderId = SaleOrderDL.AddSaleOrder(sale);
            if (saleOrderId > 0)
            {
                MessageBox.Show("Order added successfully");
                this.sale.loaddata();

                AddSaleProducts addorder = new AddSaleProducts(saleOrderId);
                addorder.TopMost = true;
                addorder.ShowDialog();


            }
            else
            {
                MessageBox.Show("Failed to create Purchase Order.");
            }

        }

        private void addproductbtn_Click(object sender, EventArgs e)
        {
          
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
            AddSaleProducts saleproduct = new AddSaleProducts(saleOrderId);
            saleproduct.TopMost = true;
            saleproduct.ShowDialog();
           
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            int CustomerId = int.Parse(comboBox1.SelectedValue.ToString());
            int paymentId = int.Parse(comboBox2.SelectedValue.ToString()); 
            DateTime date = dateTimePicker1.Value.Date;
            string status = combo.SelectedItem.ToString();
            SaleOrderBL sale = new SaleOrderBL(CustomerId ,paymentId, date, status);
            SaleOrderDL.UpdateSaleOrder(sale, saleid);
            MessageBox.Show("Order Updated successfully");
            this.sale.loaddata();
            
        }
        private void LoadpaymentData()
        {
            DataTable dt = SaleOrderDL.GetPaymentmethod();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "value";
            comboBox2.ValueMember = "lookup_id";
            comboBox2.SelectedIndex = -1;

        }
        private void LoadCustomerData()
        {
            DataTable dt = SaleOrderDL.GetCustomer();
            dt.Columns.Add("Display", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["Display"] = row["fullname"].ToString() + " (" + row["contact"].ToString() + ")";
            }
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Display";
            comboBox1.ValueMember = "customer_id";
            comboBox1.SelectedIndex = -1;

        }
    }
}
