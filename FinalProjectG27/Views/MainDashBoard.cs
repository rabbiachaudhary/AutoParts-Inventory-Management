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

            payments.Font = new Font(payments.Font.FontFamily, payments.Font.Size + 1, FontStyle.Bold);
            payments.ForeColor = Color.Red;
        }

        private void payment_MouseLeave(object sender, EventArgs e)
        {

            payments.Font = new Font(payments.Font.FontFamily, payments.Font.Size - 1, FontStyle.Regular);
            payments.ForeColor = Color.White;
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

    }
}
