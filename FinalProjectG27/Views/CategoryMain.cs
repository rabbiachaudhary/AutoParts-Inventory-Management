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
            dgvCategory.Columns["category_id"].Visible = false;
        }

        private void addpic_Click(object sender, EventArgs e)
        {
            dimForm dimForm = new dimForm();
            dimForm.Show();
            AddCategory addCategory = new AddCategory(this,true);
            addCategory.TopMost = true; 
            addCategory.ShowDialog();
            dimForm.Close();
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            //dimForm dimForm = new dimForm();
            //dimForm.Show();


            if (dgvCategory.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["category_id"].Value);

                string name = dgvCategory.CurrentRow.Cells["CategoryName"].Value.ToString();
                string d = dgvCategory.CurrentRow.Cells["Description"].Value.ToString();
                string t = dgvCategory.CurrentRow.Cells["tax_Percent"].Value.ToString();
                string p = dgvCategory.CurrentRow.Cells["markup_percent"].Value.ToString();
           
                AddCategory addC = new AddCategory(this,id, name, d, t, p,false);
                addC.TopMost = true;
                addC.ShowDialog();
            }

            else
            {
                MessageBox.Show("Please Select a row first");
            }
            //dimForm.Close();
        }

        private void CategoryMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public DataTable LoadData()
        {
            DataTable dt = CategoryDL.GetCategories();
            dgvCategory.DataSource = dt;
            return dt;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategory.CurrentRow != null)
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?",
                                                           "Confirm Deletion",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["category_id"].Value);
                        ProductsDL.DeleteProduct(id);
                        dgvCategory.Rows.Remove(dgvCategory.CurrentRow);
                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (IndexOutOfRangeException ie)
            {
                MessageBox.Show("No row selected properly: " + ie.Message, "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoryMain_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MainDashBoard mainDashBoard = new MainDashBoard();
            mainDashBoard.StartPosition = FormStartPosition.Manual;
            if (this.WindowState == FormWindowState.Maximized)
            {

                mainDashBoard.WindowState = FormWindowState.Maximized;
            }
            else
            {

                mainDashBoard.Location = this.Location;
            }
            this.Hide();
            mainDashBoard.Show();
        }
    }
}
