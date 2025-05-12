using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Controllers;
using FinalProjectG27.Models;
namespace FinalProjectG27.Views
{
    public partial class WarehouseStockMain : Form
    {
        public WarehouseStockMain()
        {
            InitializeComponent();
            LoadData();
        }

        private void addpic_Click(object sender, EventArgs e)
        {

        }

        public DataTable LoadData()
        {
            DataTable dt = stocks.getWarehouseStock();
            dataGridView1.DataSource = dt;
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
