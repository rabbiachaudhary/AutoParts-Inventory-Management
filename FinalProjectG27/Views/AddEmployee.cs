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
    public partial class AddEmployee : Form
    {
        private bool IsAdd;

        public AddEmployee(bool isAdd = false)
        {
            InitializeComponent();
            IsAdd = isAdd;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

            if (IsAdd)
            {
                add.Text = "Add Employee";
                addbtn.Visible = true;
                editbtn.Visible = false;

            }
            else
            {
                add.Text = "Edit Employee";
                addbtn.Visible = false;
                editbtn.Visible = true;
            }
        }
    }
}
