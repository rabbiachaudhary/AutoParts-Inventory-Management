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
    public partial class EmployeeDashboard : Form
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void product_Click(object sender, EventArgs e)
        {
            ProductMain productMain = new ProductMain();
            productMain.WindowState = this.WindowState;
            if (this.WindowState != FormWindowState.Maximized)
            {
                productMain.Size = this.Size;
                productMain.Location = this.Location;
            }
            productMain.Show();
            this.Hide();
        }

        private void orders_Click(object sender, EventArgs e)
        {
            SuppliersMain suppliersMain = new SuppliersMain();
            suppliersMain.WindowState = this.WindowState;
            if (this.WindowState != FormWindowState.Maximized)
            {
                suppliersMain.Size = this.Size;
                suppliersMain.Location = this.Location;
            }
            suppliersMain.Show();
            this.Hide();
        }

        private void suppliers_Click(object sender, EventArgs e)
        {
            WarehousesMain warehousesMain = new WarehousesMain();
            warehousesMain.WindowState = this.WindowState;
            if (this.WindowState != FormWindowState.Maximized)
            {
                warehousesMain.Size = this.Size;
                warehousesMain.Location = this.Location;
            }
            warehousesMain.Show();
            this.Hide();
        }

        private void stock_Click(object sender, EventArgs e)
        {
            StocksMain Main = new StocksMain();
            Main.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                Main.Size = this.Size;
                Main.Location = this.Location;
            }
            Main.Show();
            this.Hide();
        }

        private void sales_Click(object sender, EventArgs e)
        {

            SaleOrdersMain saleorder = new SaleOrdersMain();
            saleorder.WindowState = this.WindowState;
            if (this.WindowState != FormWindowState.Maximized)
            {
                saleorder.Size = this.Size;
                saleorder.Location = this.Location;
            }
            saleorder.Show();
            this.Hide();
        }

        private void purchase_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain purchase = new PurchaseOrderMain();
            purchase.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                purchase.Size = this.Size;
                purchase.Location = this.Location;
            }
            purchase.Show();
            this.Hide();
        }

        private void customers_Click(object sender, EventArgs e)
        {
            CustomersMain customersMain = new CustomersMain();
            customersMain.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                customersMain.Size = this.Size;
                customersMain.Location = this.Location;
            }
            customersMain.Show();
            this.Hide();
        }

        private void reports_Click(object sender, EventArgs e)
        {

            Reports Main = new Reports();
            Main.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                Main.Size = this.Size;
                Main.Location = this.Location;
            }
            Main.Show();
            this.Hide();
        }

        private void empbtn_Click(object sender, EventArgs e)
        {
            ProductMain productMain = new ProductMain();
            productMain.WindowState = this.WindowState;
            if (this.WindowState != FormWindowState.Maximized)
            {
                productMain.Size = this.Size;
                productMain.Location = this.Location;
            }
            productMain.Show();
            this.Hide();
        }

        private void probtn_Click(object sender, EventArgs e)
        {

            WarehousesMain warehousesMain = new WarehousesMain();
            warehousesMain.WindowState = this.WindowState;
            if (this.WindowState != FormWindowState.Maximized)
            {
                warehousesMain.Size = this.Size;
                warehousesMain.Location = this.Location;
            }
            warehousesMain.Show();
            this.Hide();
        }

        private void suppbtn_Click(object sender, EventArgs e)
        {
            SuppliersMain suppliersMain = new SuppliersMain();
            suppliersMain.WindowState = this.WindowState;
            if (this.WindowState != FormWindowState.Maximized)
            {
                suppliersMain.Size = this.Size;
                suppliersMain.Location = this.Location;
            }
            suppliersMain.Show();
            this.Hide();
        }

        private void purbtn_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain purchase = new PurchaseOrderMain();
            purchase.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                purchase.Size = this.Size;
                purchase.Location = this.Location;
            }
            purchase.Show();
            this.Hide();
        }

        private void salebtn_Click(object sender, EventArgs e)
        {
            SaleOrdersMain saleorder = new SaleOrdersMain();
            saleorder.WindowState = this.WindowState;
            if (this.WindowState != FormWindowState.Maximized)
            {
                saleorder.Size = this.Size;
                saleorder.Location = this.Location;
            }
            saleorder.Show();
            this.Hide();
        }

        private void stockbtn_Click(object sender, EventArgs e)
        {
            StocksMain Main = new StocksMain();
            Main.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                Main.Size = this.Size;
                Main.Location = this.Location;
            }
            Main.Show();
            this.Hide();
        }

        private void paybtn_Click(object sender, EventArgs e)
        {

        }

        private void cusbtn_Click(object sender, EventArgs e)
        {
            CustomersMain customersMain = new CustomersMain();
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
