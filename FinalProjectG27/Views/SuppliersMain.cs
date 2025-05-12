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
    public partial class SuppliersMain : Form
    {
        public SuppliersMain()
        {
            InitializeComponent();
            dataGridView1.Columns["id"].Visible = false;
            loaddata();
           
        }

        private void addsupplier_Click(object sender, EventArgs e)
        {
            
            AddSupplier supplier = new AddSupplier(this,true);
            supplier.TopMost = true;
            supplier.ShowDialog();
            
        }

        private void editsupplier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                string fname = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
                string lname = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
                string contact = dataGridView1.CurrentRow.Cells["Contact"].Value.ToString();
                string email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                string address = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
               

                
                AddSupplier supplier = new AddSupplier(this,id ,fname , lname , contact , email , address);
                supplier.TopMost = true;
                supplier.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Please Select a Row First");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            DataTable searchData = SupplierDL.GetSearchData(search);
            if (searchData != null)
            {
                dataGridView1.DataSource = searchData;
            }
        }
        public void loaddata()
        {
            DataTable dt = new DataTable();
            dt = SupplierDL.GetSupplier();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void deletesupplier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                SupplierDL.DeleteSupplier(id);
                MessageBox.Show("Supplier deleted successfully");
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

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    }
}
