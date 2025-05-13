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

        private void product_Click(object sender, EventArgs e)
        {
            ProductMain a = new ProductMain(); a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void employee_Click(object sender, EventArgs e)
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

        private void orders_Click(object sender, EventArgs e)
        {
            SuppliersMain a = new SuppliersMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void suppliers_Click(object sender, EventArgs e)
        {
            WarehousesMain a = new WarehousesMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void stock_Click(object sender, EventArgs e)
        {
            StocksMain a = new StocksMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void sales_Click(object sender, EventArgs e)
        {
            SaleOrdersMain a = new SaleOrdersMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void purchase_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain a = new PurchaseOrderMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void payments_Click(object sender, EventArgs e)
        {
            CustomersMain a = new CustomersMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void reports_Click(object sender, EventArgs e)
        {
            Reports a=new Reports();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }
    }
}
