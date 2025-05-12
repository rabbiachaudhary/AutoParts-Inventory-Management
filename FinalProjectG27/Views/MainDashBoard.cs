using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Views;

namespace FinalProjectG27
{
    public partial class MainDashBoard : Form
    {
        public MainDashBoard()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void MainDashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void product_MouseEnter(object sender, EventArgs e)
        {
            
            product.Font = new Font(product.Font.FontFamily, product.Font.Size + 1, FontStyle.Bold);
            product.ForeColor = Color.Red; 
        }

        private void product_MouseLeave(object sender, EventArgs e)
        {
            
            product.Font = new Font(product.Font.FontFamily, product.Font.Size - 1, FontStyle.Regular);
            product.ForeColor = Color.White; 
        }

        private void employee_MouseEnter(object sender, EventArgs e)
        {

            employee.Font = new Font(employee.Font.FontFamily, employee.Font.Size + 1, FontStyle.Bold);
            employee.ForeColor = Color.Red;
        }

        private void employee_MouseLeave(object sender, EventArgs e)
        {

            employee.Font = new Font(employee.Font.FontFamily, employee.Font.Size - 1, FontStyle.Regular);
            employee.ForeColor = Color.White;
        }

        private void orders_MouseEnter(object sender, EventArgs e)
        {

            orders.Font = new Font(orders.Font.FontFamily, orders.Font.Size + 1, FontStyle.Bold);
            orders.ForeColor = Color.Red;
        }

        private void orders_MouseLeave(object sender, EventArgs e)
        {

            orders.Font = new Font(orders.Font.FontFamily, orders.Font.Size - 1, FontStyle.Regular);
            orders.ForeColor = Color.White;
        }
        private void suppliers_MouseEnter(object sender, EventArgs e)
        {

            suppliers.Font = new Font(suppliers.Font.FontFamily, suppliers.Font.Size + 1, FontStyle.Bold);
            suppliers.ForeColor = Color.Red;
        }

        private void suppliers_MouseLeave(object sender, EventArgs e)
        {

            suppliers.Font = new Font(suppliers.Font.FontFamily, suppliers.Font.Size - 1, FontStyle.Regular);
            suppliers.ForeColor = Color.White;
        }
        private void stock_MouseEnter(object sender, EventArgs e)
        {

            stock.Font = new Font(stock.Font.FontFamily, stock.Font.Size + 1, FontStyle.Bold);
            stock.ForeColor = Color.Red;
        }

        private void stock_MouseLeave(object sender, EventArgs e)
        {

            stock.Font = new Font(stock.Font.FontFamily, stock.Font.Size - 1, FontStyle.Regular);
            stock.ForeColor = Color.White;
        }
        private void sales_MouseEnter(object sender, EventArgs e)
        {

            sales.Font = new Font(sales.Font.FontFamily, sales.Font.Size + 1, FontStyle.Bold);
            sales.ForeColor = Color.Red;
        }

        private void sales_MouseLeave(object sender, EventArgs e)
        {

            sales.Font = new Font(sales.Font.FontFamily, sales.Font.Size - 1, FontStyle.Regular);
            sales.ForeColor = Color.White;
        }
        private void purchase_MouseEnter(object sender, EventArgs e)
        {

            purchase.Font = new Font(purchase.Font.FontFamily, purchase.Font.Size + 1, FontStyle.Bold);
            purchase.ForeColor = Color.Red;
        }

        private void purchase_MouseLeave(object sender, EventArgs e)
        {

            purchase.Font = new Font(purchase.Font.FontFamily, purchase.Font.Size - 1, FontStyle.Regular);
            purchase.ForeColor = Color.White;
        }
        private void payment_MouseEnter(object sender, EventArgs e)
        {

            customers.Font = new Font(customers.Font.FontFamily, customers.Font.Size + 1, FontStyle.Bold);
            customers.ForeColor = Color.Red;
        }

        private void payment_MouseLeave(object sender, EventArgs e)
        {

            customers.Font = new Font(customers.Font.FontFamily, customers.Font.Size - 1, FontStyle.Regular);
            customers.ForeColor = Color.White;
        }

        private void reports_MouseEnter(object sender, EventArgs e)
        {

            reports.Font = new Font(reports.Font.FontFamily, reports.Font.Size + 1, FontStyle.Bold);
            reports.ForeColor = Color.Red;
        }

        private void reports_MouseLeave(object sender, EventArgs e)
        {

            reports.Font = new Font(reports.Font.FontFamily, reports.Font.Size - 1, FontStyle.Regular);
            reports.ForeColor = Color.White;
        }
        private void employee_Click(object sender, EventArgs e)
        {
            EmployeesMain employee = new EmployeesMain();
            employee.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                employee.Size = this.Size;
                employee.Location = this.Location;
            }
            employee.Show();
            this.Hide();
        }

        private void employee_MouseEnter_1(object sender, EventArgs e)
        {

        }

        private void empbtn_MouseEnter(object sender, EventArgs e)
        {
            empbtn.BackColor = Color.Black;   
            empbtn.ForeColor = Color.White;       
        }

        private void empbtn_MouseLeave(object sender, EventArgs e)
        {
            empbtn.BackColor = SystemColors.Control;  
            empbtn.ForeColor = Color.Black;           
        }
        private void probtn_MouseEnter(object sender, EventArgs e)
        {
            probtn.BackColor = Color.Black;
            probtn.ForeColor = Color.White;
        }

        private void probtn_MouseLeave(object sender, EventArgs e)
        {
            probtn.BackColor = SystemColors.Control;
            probtn.ForeColor = Color.Black;
        }
        private void suppbtn_MouseEnter(object sender, EventArgs e)
        {
            suppbtn.BackColor = Color.Black;
            suppbtn.ForeColor = Color.White;
        }

        private void suppbtn_MouseLeave(object sender, EventArgs e)
        {
            suppbtn.BackColor = SystemColors.Control;
            suppbtn.ForeColor = Color.Black;
        }

        private void purbtn_MouseEnter(object sender, EventArgs e)
        {
            purbtn.BackColor = Color.Black;
            purbtn.ForeColor = Color.White;
        }

        private void purbtn_MouseLeave(object sender, EventArgs e)
        {
            purbtn.BackColor = SystemColors.Control;
            purbtn.ForeColor = Color.Black;
        }

        private void salebtn_MouseEnter(object sender, EventArgs e)
        {
            salebtn.BackColor = Color.Black;
            salebtn.ForeColor = Color.White;
        }

        private void salebtn_MouseLeave(object sender, EventArgs e)
        {
            salebtn.BackColor = SystemColors.Control;
            salebtn.ForeColor = Color.Black;
        }

        private void stockbtn_MouseEnter(object sender, EventArgs e)
        {
            stockbtn.BackColor = Color.Black;
            stockbtn.ForeColor = Color.White;
        }

        private void stockbtn_MouseLeave(object sender, EventArgs e)
        {
            stockbtn.BackColor = SystemColors.Control;
            stockbtn.ForeColor = Color.Black;
        }

        private void paybtn_MouseEnter(object sender, EventArgs e)
        {
            paybtn.BackColor = Color.Black;
            paybtn.ForeColor = Color.White;
        }

        private void paybtn_MouseLeave(object sender, EventArgs e)
        {
            paybtn.BackColor = SystemColors.Control;
            paybtn.ForeColor = Color.Black;
        }

        private void cusbtn_MouseEnter(object sender, EventArgs e)
        {
            cusbtn.BackColor = Color.Black;
            cusbtn.ForeColor = Color.White;
        }

        private void cusbtn_MouseLeave(object sender, EventArgs e)
        {
            cusbtn.BackColor = SystemColors.Control;
            cusbtn.ForeColor = Color.Black;
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
            PurchaseOrderMain purchaseOrder = new PurchaseOrderMain();
            purchaseOrder.WindowState = this.WindowState;
            if (this.WindowState != FormWindowState.Maximized)
            {
                purchaseOrder.Size = this.Size;
                purchaseOrder.Location = this.Location;
            }
            purchaseOrder.Show();
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

        private void empbtn_Click(object sender, EventArgs e)
        {

            EmployeesMain Main = new EmployeesMain();
            Main.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                Main.Size = this.Size;
                Main.Location = this.Location;
            }
            Main.Show();
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

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel13_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void paybtn_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void stockbtn_Click(object sender, EventArgs e)
        {
            StocksMain stocksMain = new StocksMain();
            stocksMain.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                stocksMain.Size = this.Size;
                stocksMain.Location = this.Location;
            }
            stocksMain.Show();
            this.Hide();
        }

        private void tableLayoutPanel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MainDashBoard mainDashBoard = new MainDashBoard();
            mainDashBoard.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                mainDashBoard.Size = this.Size;
                mainDashBoard.Location = this.Location;
            }
            mainDashBoard.Show();
            this.Hide();
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void payments_Click(object sender, EventArgs e)
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

        private void sales_Click(object sender, EventArgs e)
        {
            SaleOrdersMain sales = new SaleOrdersMain();
            sales.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                sales.Size = this.Size;
                sales.Location = this.Location;
            }
            sales.Show();
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

        private void reports_Click(object sender, EventArgs e)
        {

            Reports purchase = new Reports();
            purchase.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                purchase.Size = this.Size;
                purchase.Location = this.Location;
            }
            purchase.Show();
            this.Hide();
        }

        private void product_Click(object sender, EventArgs e)
        {
            ProductMain a= new ProductMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                purchase.Size = this.Size;
                purchase.Location = this.Location;
            }
            purchase.Show();
            this.Hide();
        }

        private void tableLayoutPanel3_Paint_1(object sender, PaintEventArgs e)
        {

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
    }
}
