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
    public partial class AddCustomer : Form
    {
        private bool IsAdd;
        public AddCustomer(bool isAdd=false)
        {
            InitializeComponent();
            IsAdd = isAdd;
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                CustomerText.Text = "Add Customer";
                addbtn.Visible = true; 
                editbtn.Visible = false;
            
            }
            else
            {
                CustomerText.Text = "Edit Customer";
                addbtn.Visible = false;
                editbtn.Visible = true;
            }


        }

        private void editbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
