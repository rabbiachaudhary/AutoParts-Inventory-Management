using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Controllers;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace FinalProjectG27.Views
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            // Panel1 (main container)
            // Main container
            panel1.Dock = DockStyle.Fill;

            // Header (navigation)
            panel2.Dock = DockStyle.Top;
            panel2.Height = 60; // Fixed height

            // Content area
            panel3.Dock = DockStyle.Fill;
            panel3.Padding = new Padding(20);

            // Report controls panel
            panel4.Dock = DockStyle.Fill;
            label4.Top = 20;
            label4.Left = (panel4.Width - label4.Width - comboBox1.Width - 10) / 2;

            comboBox1.Top = 20;
            comboBox1.Left = label4.Right + 10;
            dataGridView1.Top = 60; // Below combo box
            dataGridView1.Left = 20;
            dataGridView1.Width = panel4.Width - 40;
            dataGridView1.Height = panel4.Height - 150; // Space for buttons

            comboBox1.SelectedIndex = 0;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            this.Load += Repotsrt1_Load;
            this.Resize += Repotsrt1_Resize;
            this.MinimumSize = new Size(800, 600);
        }

        private void PositionButtons()
        {
            int buttonY = panel4.Height - 70;

            button1.Top = buttonY;
            button2.Top = buttonY;
            button3.Top = buttonY;

            // Space buttons evenly
            int totalWidth = button1.Width + button2.Width + button3.Width + 40;
            int startX = (panel4.Width - totalWidth) / 2;

            button1.Left = startX;
            button2.Left = button1.Right + 20;
            button3.Left = button2.Right + 20;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Repotsrt1_Load(object sender, EventArgs e) => PositionButtons();

        private void Repotsrt1_Resize(object sender, EventArgs e)
        {
            // Reposition combo box
            label4.Left = (panel4.Width - label4.Width - comboBox1.Width - 10) / 2;
            comboBox1.Left = label4.Right + 10;

            // Resize grid
            dataGridView1.Width = panel4.Width - 40;
            dataGridView1.Height = panel4.Height - 150;

            PositionButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.");
                return;
            }
            try
            {
                string selected = comboBox1.SelectedItem.ToString();
                DataTable d = ReportsDL.Getreport(selected);
                dataGridView1.DataSource = d;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                Bitmap bm = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                ev.Graphics.DrawImage(bm, 0, 0);
            };

            PrintDialog printDialog = new PrintDialog
            {
                Document = pd
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files|*.pdf";
            sfd.FileName = "Report.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToPDF(sfd.FileName);
            }

        }

        private void ExportToPDF(string filePath)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

            // Adding column headers
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                table.AddCell(new Phrase(column.HeaderText));
            }

            // Adding row data
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        table.AddCell(cell.Value?.ToString());
                    }
                }
            }

            doc.Add(table);
            doc.Close();
            MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void product_Click(object sender, EventArgs e)
        {
            ProductMain a= new ProductMain();
            a.WindowState = this.WindowState;
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
            EmployeesMain a= new EmployeesMain();

            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void orders_Click(object sender, EventArgs e)
        {
            SuppliersMain a= new SuppliersMain();
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
            WarehousesMain a= new WarehousesMain();
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
            StocksMain a= new StocksMain();
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
            SaleOrdersMain a= new SaleOrdersMain();
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
            PurchaseOrderMain a= new PurchaseOrderMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void customers_Click(object sender, EventArgs e)
        {
            CustomersMain a= new CustomersMain();
            a.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.Size = this.Size;
                a.Location = this.Location;
            }
            a.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login a=new Login();
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
