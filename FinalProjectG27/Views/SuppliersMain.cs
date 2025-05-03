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
    public partial class SuppliersMain : Form
    {
        public SuppliersMain()
        {
            InitializeComponent();
        }

        private void addsupplier_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddSupplier supplier = new AddSupplier(true);
            supplier.TopMost = true;
            supplier.ShowDialog();
            dimForm.Close();
        }

        private void editsupplier_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddSupplier supplier = new AddSupplier();
            supplier.TopMost = true;
            supplier.ShowDialog();
            dimForm.Close();
        }
    }
}
