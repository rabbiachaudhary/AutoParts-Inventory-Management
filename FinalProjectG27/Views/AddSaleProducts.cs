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
    public partial class AddSaleProducts : Form
    {
        private int SaleOrderId = 0;
        private int SodetailID = 0;
        public AddSaleProducts(int saleid)
        {
            InitializeComponent();
            loaddata();
            LoadproductData();
            dataGridView1.Columns["sodetail_id"].Visible = false;
            dataGridView1.Columns["product_id"].Visible = false;
            SaleOrderId = saleid;
        }


        private void editbtn_Click(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            int quantity = Convert.ToInt32(textBox1.Text);
            if (SodetailID > 0)
            {

                SaleOrderProductsBL order = new SaleOrderProductsBL(productId, quantity);
                SaleOrderProductsDL.UpdateOrderProducts(order, SodetailID);
                MessageBox.Show("Product Updated Successfully");
                loaddata();
            }
            else
            {

                SaleOrderProductsBL order = new SaleOrderProductsBL(SaleOrderId, productId, quantity);
                SaleOrderProductsDL.AddOrderProducts(order);
                MessageBox.Show("Product Added Successfully");
                loaddata();

            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                int sodetailid = Convert.ToInt32(selectedRow.Cells["sodetail_id"].Value);
                int productId = Convert.ToInt32(selectedRow.Cells["product_id"].Value);
                int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                FillDetails(sodetailid, productId, quantity);

            }
        }

        private void loaddata()
        {
            DataTable dt = new DataTable();
            dt = SaleOrderProductsDL.Getorder();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void LoadproductData()
        {
            DataTable dt = SaleOrderProductsDL.GetProductData();

            dt.Columns.Add("Display", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["Display"] = row["product_name"].ToString() + " (" + row["category"].ToString() + ")";
            }
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Display";
            comboBox2.ValueMember = "product_id";
            comboBox2.SelectedIndex = -1;

        }
        private void FillDetails(int sodetailid, int productId, int quantity)
        {
            this.SodetailID = sodetailid;
            textBox1.Text = quantity.ToString();
            comboBox2.SelectedValue = productId;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["sodetail_id"].Value);

                SaleOrderProductsDL.DeleteOrder(id);
                MessageBox.Show("Product deleted successfully");
                loaddata();
            }
        }
    }
}
