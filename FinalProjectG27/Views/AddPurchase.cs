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
    public partial class AddPurchase : Form
    {
        private bool isAdd;
        private int purchaseId;
        private int purchaseOrderId;
        private PurchaseOrderMain purchase;

        public AddPurchase(PurchaseOrderMain parentform ,int id , int supplierid , int warehouseid , int paymentid , string status , DateTime date ,bool isAdd = false)
        {
            InitializeComponent();
            this.isAdd = isAdd;
            LoadsupplierData();
            LoadwarehouseData();
            LoadpaymentData();
            this.purchaseId = id;
            comboBox1.SelectedValue = supplierid.ToString();
            comboBox2.SelectedValue = warehouseid.ToString();
            comboBox3.SelectedValue = paymentid.ToString();
            dateTimePicker1.Value = date.Date;
            Status.SelectedValue = status.ToString();
            this.purchase = parentform;
        }
        public AddPurchase(PurchaseOrderMain parentform,bool isAdd = false)
        {
            InitializeComponent();
            this.isAdd = isAdd;
            LoadsupplierData();
            LoadwarehouseData();
            LoadpaymentData();
            this.purchase = parentform;
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
                Status.Visible = false;
                statuslabel.Visible = false;

            }
            else
            {
                Category.Text = "Edit Purchase Order";
                Addbtn.Visible = false;
                updatebtn.Visible = true;
                addproductbtn.Visible = false;
                pictureBox1.Visible = false;
                Status.Visible = true;
                statuslabel.Visible = true;
            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            int supplierId = int.Parse(comboBox1.SelectedValue.ToString());
            int warehouseId = int.Parse(comboBox2.SelectedValue.ToString());
            int paymentId = int.Parse(comboBox3.SelectedValue.ToString());
            DateTime date = dateTimePicker1.Value.Date;
            string status = Status.SelectedItem.ToString();

            PurchaseOrderBL purchase = new PurchaseOrderBL(supplierId, warehouseId, paymentId, date,status);
            PurchaseOrderDL.UpdatePurchaseOrder(purchase , purchaseId);
            MessageBox.Show("Order Updated successfully");
            this.purchase.loaddata();
            

        }

        private void addproductbtn_Click(object sender, EventArgs e)
        {

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            int supplierId = int.Parse(comboBox1.SelectedValue.ToString());
            int warehouseId = int.Parse(comboBox2.SelectedValue.ToString());
            int paymentId = int.Parse(comboBox3.SelectedValue.ToString());
            DateTime date = dateTimePicker1.Value.Date;

            PurchaseOrderBL purchase = new PurchaseOrderBL(supplierId , warehouseId , paymentId , date);
            purchaseOrderId = PurchaseOrderDL.AddPurchaseOrder(purchase);
            if (purchaseOrderId > 0)
            {
                MessageBox.Show("Order added successfully");
                this.purchase.loaddata();

                AddOrderProducts addorder = new AddOrderProducts(purchaseOrderId);
                addorder.TopMost = true;
                addorder.ShowDialog();

              
            }
            else
            {
                MessageBox.Show("Failed to create Purchase Order.");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

            AddOrderProducts addorder = new AddOrderProducts(purchaseOrderId);
            addorder.TopMost = true;
            addorder.ShowDialog();

        }
        private void LoadsupplierData()
        {
            DataTable dt = PurchaseOrderDL.GetSupplier();

            dt.Columns.Add("Display", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["Display"] = row["full_name"].ToString() + " (" + row["contact"].ToString() + ")";
            }
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Display";
            comboBox1.ValueMember = "supplier_id";
            comboBox1.SelectedIndex = -1;

        }
        private void LoadwarehouseData()
        {
            DataTable dt = PurchaseOrderDL.GetWarehouse();

            dt.Columns.Add("Display", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["Display"] = row["warehouse_name"].ToString() + " (" + row["location"].ToString() + ")";
            }
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Display";
            comboBox2.ValueMember = "warehouse_id";
            comboBox2.SelectedIndex = -1;

        }
        private void LoadpaymentData()
        {
            DataTable dt = PurchaseOrderDL.GetPaymentmethod();
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "value";
            comboBox3.ValueMember = "lookup_id";
            comboBox3.SelectedIndex = -1;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
