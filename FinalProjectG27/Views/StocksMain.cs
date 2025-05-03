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
    public partial class StocksMain : Form
    {
        public StocksMain()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void empbtn_Click(object sender, EventArgs e)
        {

            WarehouseStockMain customersMain = new WarehouseStockMain();
            customersMain.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                customersMain.Size = this.Size;
                customersMain.Location = this.Location;
            }
            customersMain.Show();
            this.Hide();
        }

        private void probtn_Click(object sender, EventArgs e)
        {

            ShopStockMain customersMain = new ShopStockMain();
            customersMain.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                customersMain.Size = this.Size;
                customersMain.Location = this.Location;
            }
            customersMain.Show();
            this.Hide();
        }

        private void suppbtn_Click(object sender, EventArgs e)
        {

            StockTransferMain customersMain = new StockTransferMain();
            customersMain.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                customersMain.Size = this.Size;
                customersMain.Location = this.Location;
            }
            customersMain.Show();
            this.Hide();
        }
    }
}
