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
    public partial class WarehousesMain : Form
    {
        public WarehousesMain()
        {
            InitializeComponent();
        }

        private void addpic_Click(object sender, EventArgs e)
        {
            //dimForm dimForm = new dimForm();
            //dimForm.Show();
            //AddWarehouse a = new AddWarehouse(true);
            //a.TopMost = true;
            //a.ShowDialog();
            //dimForm.Close();

        }

        private void editpic_Click(object sender, EventArgs e)
        {

            //dimForm dimForm = new dimForm();
            //dimForm.Show();
            AddWarehouse a = new AddWarehouse(false);
            a.TopMost = true;
            a.ShowDialog();
            //dimForm.Close();
        }
    }
}
