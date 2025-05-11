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

namespace FinalProjectG27.Views
{
    public partial class SaleOrdersMain : Form
    {
        public SaleOrdersMain()
        {
            InitializeComponent();
            loaddata();
            dataGridView1.Columns["payment_id"].Visible = false;
            dataGridView1.Columns["customer_id"].Visible = false;
           
        }

        private void addpic_Click(object sender, EventArgs e)
        {
           
            AddSale sale = new AddSale(this,true);
            sale.TopMost = true;
            sale.ShowDialog();
           
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["sale_order_id"].Value);
                int customerid = Convert.ToInt32(row.Cells["customer_id"].Value);
                int paymentid = Convert.ToInt32(row.Cells["payment_id"].Value);
                string status = row.Cells["Status"].Value.ToString();
                DateTime date = Convert.ToDateTime(row.Cells["Date"].Value);

                AddSale sale = new AddSale(this,id , customerid,paymentid , status,date);
                sale.TopMost = true;
                sale.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select a Row First");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            DataTable searchData = SaleOrderDL.GetSearchData(search);
            if (searchData != null)
            {
                dataGridView1.DataSource = searchData;
            }
        }
        public void loaddata()
        {
            DataTable dt = new DataTable();
            dt = SaleOrderDL.Getorder();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["sale_order_id"].Value);

                SaleOrderDL.DeleteOrder(id);
                MessageBox.Show("Order deleted successfully");
                loaddata();
            }
            else
            {
                MessageBox.Show("Please select a row first");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
