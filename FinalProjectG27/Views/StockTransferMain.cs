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
    public partial class StockTransferMain : Form
    {
        public StockTransferMain()
        {
            InitializeComponent();
        }

        private void addpic_Click(object sender, EventArgs e)
        {

            AddStockTransfer a = new AddStockTransfer(true);
            a.TopMost = true;
            a.ShowDialog();
        }

        private void editpic_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Please select a row first.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Check if required cells have values
                if (selectedRow.Cells["warehouse_name"].Value == null ||
                    selectedRow.Cells[0].Value == null ||
                    selectedRow.Cells["product_name"].Value == null ||
                    selectedRow.Cells["quantity"].Value == null ||
                    selectedRow.Cells["note"].Value == null)
                {
                    MessageBox.Show("Selected row has missing data.", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Safely parse and assign values
                int id = Convert.ToInt32(selectedRow.Cells["transfer_id"].Value);
                string w = selectedRow.Cells["warehouse_name"].Value.ToString();
                string p = selectedRow.Cells["product_name"].Value.ToString();
                int q = int.Parse(selectedRow.Cells["quantity"].Value.ToString());
                string n = selectedRow.Cells["note"].Value.ToString();

                // Open the edit form
                using (AddStockTransfer addC = new AddStockTransfer(this, id, w, p,q, n, false))
                {
                    addC.TopMost = true;
                    addC.ShowDialog();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid data format (e.g., ID must be a number).", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null && (dataGridView1.SelectedRows.Count == 1))
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?",
                                                           "Confirm Deletion",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["warehouse_id"].Value);
                        StockTransferDL.DeleteTransfer(id);
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
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
    }
}
