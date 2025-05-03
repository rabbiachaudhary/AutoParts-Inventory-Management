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
    public partial class AddStockTransfer : Form
    {
        private bool IsAdd;

        public AddStockTransfer(bool isAdd = false)
        {
            InitializeComponent();
            IsAdd = isAdd;
        }
        private void AddStockTransfer_Load(object sender, EventArgs e)
        {

            if (IsAdd)
            {
                add.Text = "Add Stock Transfer";
                addbtn.Visible = true;
                editbtn.Visible = false;

            }
            else
            {
                add.Text = "Edit Stock Transfer";
                addbtn.Visible = false;
                editbtn.Visible = true;
            }
        }
    }
}
