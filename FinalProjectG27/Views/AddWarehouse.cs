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
    public partial class AddWarehouse : Form
    {
        private bool IsAdd;

        public AddWarehouse(bool isAdd = false)
        {
            InitializeComponent();
            IsAdd = isAdd;
        }


        private void AddWarehouse_Load(object sender, EventArgs e)
        {


            if (IsAdd)
            {
                add.Text = "Add Warehouse";
                addbtn.Visible = true;
                editbtn.Visible = false;

            }
            else
            {
                add.Text = "Edit WWarehouse";
                addbtn.Visible = false;
                editbtn.Visible = true;
            }
        }
    }
}
