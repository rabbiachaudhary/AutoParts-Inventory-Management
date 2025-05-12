using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace FinalProjectG27.Views
{
    public partial class AddEmployee : Form
    {
        private bool IsAdd;
        private int staffId;

        public AddEmployee(int id,string fname , string lname,string contact,string email, string address,string status, bool isAdd = false)
        {
            InitializeComponent();
            IsAdd = isAdd;
            staffId = id;
            textBox4.Text = fname;
            textBox3.Text = lname;
            textBox2.Text = email;
            textBox1.Text = contact;
            textBox5.Text = address;
            comboBox1.SelectedItem = status;
        }
        public AddEmployee(bool isAdd = true)
        {
            IsAdd= isAdd;
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

        private void editbtn_Click(object sender, EventArgs e)
        {
            string fname=textBox4.Text;
            string lname=textBox3.Text;
            string contact=textBox1.Text;
            string address=textBox5.Text;
            string email = textBox2.Text;
            string status = comboBox1.SelectedItem.ToString();
            staffBL s=new staffBL(fname,lname,contact,email,address,status);
            staffDL.UpdateStaff(s, staffId);

            MessageBox.Show("Staff updated successfully");
            this.Close();

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            string fname = textBox4.Text;
            string lname = textBox3.Text;
            string contact = textBox1.Text;
            string address = textBox5.Text;
            string email = textBox2.Text;
            string status = comboBox1.SelectedItem.ToString();
            staffBL s = new staffBL(fname, lname, contact, email, address, status);
            staffDL.AddStaff(s);

            MessageBox.Show("Staff added successfully");
            this.Close();
=======

>>>>>>> Stashed changes
        }
    }
}
