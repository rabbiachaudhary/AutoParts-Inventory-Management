using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectG27.Views
{
    public partial class EmployeesMain : Form
    {
        public EmployeesMain()
        {
            InitializeComponent();
            dataGridView1.Columns["id"].Visible = false;
            loaddata();
        }

        private void addpic_Click(object sender, EventArgs e)
        {

            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddEmployee a = new AddEmployee(true);
            a.TopMost = true;
            a.ShowDialog();
            dimForm.Close();
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                string fname = dataGridView1.CurrentRow.Cells["First Name"].Value.ToString();
                string lname = dataGridView1.CurrentRow.Cells["Last Name"].Value.ToString();
                string contact = dataGridView1.CurrentRow.Cells["Contact"].Value.ToString();
                string email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                string address = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
                string status = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();


                dimForm dimForm = new dimForm();
                dimForm.Show();
                AddEmployee a = new AddEmployee(id,fname,lname,contact,email,address,status,false);
                a.TopMost = true;
                a.ShowDialog();
                dimForm.Close();
            }
            else
            {
                MessageBox.Show("Please select a row first");
            }
        }

        private void EmployeesMain_Load(object sender, EventArgs e)
        {

        }
        private void loaddata()
        {
            DataTable dt = new DataTable();
            dt = staffDL.GetStaff();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            ProductMain a = new ProductMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            EmployeesMain a = new EmployeesMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                staffDL.DeleteStaff(id);    
            }
            else
            {
                MessageBox.Show("Please select a row first");
            }
        }
    }
}
