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

            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddEmployee a = new AddEmployee(false);
            a.TopMost = true;
            a.ShowDialog();
            dimForm.Close();
        }

        private void EmployeesMain_Load(object sender, EventArgs e)
        {

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
    }
}
