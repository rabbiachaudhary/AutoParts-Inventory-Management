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
    public partial class AddSupplier : Form
    {
        private bool isAddMode;
        public AddSupplier(bool isAddMode = false)
        {
            InitializeComponent();
            this.isAddMode = isAddMode;
        }
        private void AddSupplier_Load(object sender, EventArgs e)
        {
            if (isAddMode)
            {
                dynamic.Text = "Add Supplier";
                Addbtn.Visible = true;
                updatebtn.Visible = false;
            }
            else
            {
                dynamic.Text = "Edit Supplier";
                Addbtn.Visible = false;
                updatebtn.Visible = true;
            }




        }

        private void Addbtn_Click(object sender, EventArgs e)
        {

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
