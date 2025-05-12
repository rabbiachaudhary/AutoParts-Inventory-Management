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
    public partial class AddOrderProducts : Form
    {
        private int PurchaseOrderId = 0;
        private int PodetailID = 0;
        public AddOrderProducts(int purchaseid)
        {
            
            InitializeComponent();
            loaddata();
            LoadproductData();
            dataGridView1.Columns["podetail_id"].Visible = false;
            dataGridView1.Columns["product_id"].Visible = false;
            PurchaseOrderId = purchaseid;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                int podetailid = Convert.ToInt32(selectedRow.Cells["podetail_id"].Value);
                int productId = Convert.ToInt32(selectedRow.Cells["product_id"].Value);
                int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                FillDetails(podetailid, productId, quantity);
                
            }
            else
            {
                MessageBox.Show("Please Select one Row");
            }

        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null || textBox1.Text == null)
            {
                MessageBox.Show("Please Fill All Details");
            }
            int productId = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            int quantity = Convert.ToInt32(textBox1.Text);
            if (!int.TryParse(textBox1.Text, out quantity))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
            if (PodetailID > 0)
            {
               
                PurchaseOrderProductsBL order = new PurchaseOrderProductsBL(productId, quantity);
                PurchaseOrderProductsDL.UpdateOrderProducts(order, PodetailID);
                MessageBox.Show("Product Updated Successfully");
                loaddata();
            }
            else
            {

                PurchaseOrderProductsBL order = new PurchaseOrderProductsBL(PurchaseOrderId, productId, quantity);
                bool flag = PurchaseOrderProductsDL.AddOrderProducts(order);
                if (flag)
                {
                    MessageBox.Show("Product Added Successfully");
                    loaddata();
                }
                else
                {
                    return;
                }

            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["podetail_id"].Value);

                PurchaseOrderProductsDL.DeleteOrder(id);
                MessageBox.Show("Product deleted successfully");
                loaddata();
            }
            else
            {
                MessageBox.Show("Please Select one Row");
            }
        }

        private void loaddata()
        {
            DataTable dt = new DataTable();
            dt = PurchaseOrderProductsDL.Getorder();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void LoadproductData()
        {
            DataTable dt = PurchaseOrderProductsDL.GetProductData();

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
        private void FillDetails(int podetailid, int productId, int quantity)
        {
            this.PodetailID = podetailid;
            textBox1.Text = quantity.ToString();
            comboBox2.SelectedValue = productId;

        }

    }
}
