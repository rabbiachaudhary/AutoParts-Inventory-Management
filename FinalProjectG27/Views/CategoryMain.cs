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

namespace FinalProjectG27.Views
{
    public partial class CategoryMain : Form
    {
        public CategoryMain()
        {
            InitializeComponent();
            LoadData();
        }

        private void addpic_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddCategory addCategory = new AddCategory(true);
            addCategory.TopMost = true; 
            addCategory.ShowDialog();
            dimForm.Close();
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddCategory addCategory = new AddCategory();
            addCategory.TopMost = true;
            addCategory.ShowDialog();
            dimForm.Close();
        }

        private void CategoryMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable LoadData()
        {
            DataTable dt = CategoryDL.GetCategories();
            dgvCategory.DataSource = dt;
            return dt;
        }
    }
}
