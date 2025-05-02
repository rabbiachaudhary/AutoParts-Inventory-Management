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
    public partial class CustomersMain : Form
    {
        public CustomersMain()
        {
            InitializeComponent();
        }

        private void addpic_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddCustomer addCustomer = new AddCustomer(true);
            addCustomer.TopMost = true;
            addCustomer.ShowDialog();
            dimForm.Close();
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.TopMost = true;
            addCustomer.ShowDialog();
            dimForm.Close();
        }

        private void CustomersMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
