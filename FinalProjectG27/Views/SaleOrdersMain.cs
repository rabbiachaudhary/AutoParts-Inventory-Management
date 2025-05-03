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
    public partial class SaleOrdersMain : Form
    {
        public SaleOrdersMain()
        {
            InitializeComponent();
        }

        private void addpic_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddSale sale = new AddSale(true);
            sale.TopMost = true;
            sale.ShowDialog();
            dimForm.Close();
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddSale sale = new AddSale();
            sale.TopMost = true;
            sale.ShowDialog();
            dimForm.Close();
        }
    }
}
