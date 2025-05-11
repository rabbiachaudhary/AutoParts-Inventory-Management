using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using FinalProjectG27.Controllers;
using FinalProjectG27.Models;
using System.Net;

namespace FinalProjectG27.Views
{
    public partial class AddEmployeee : Form
    {
        private bool isAdd;
        private int Id;
        private EmployeesMain main;

        public AddEmployeee(EmployeesMain main, bool isAdd = true)
        {
            InitializeComponent();
            this.main = main;
            this.isAdd = isAdd;
            add.Text = "Add Employee";
            addbtn.Visible = true;
            editbtn.Visible = false;
        }

        public AddEmployeee(EmployeesMain main, int id, string LastName,string FirstName,string Contact,string Email,String Address, string Status, bool isAdd = false)
        {
            InitializeComponent();
            this.main = main;
            add.Text = "Edit Employee";
            addbtn.Visible = false;
            editbtn.Visible = true;
            Id = id;
            this.isAdd = isAdd;
            lname.Text = LastName;
            fname.Text = FirstName;
            email.Text = Email;
            contact.Text = Contact;
            address.Text = Address;
            status.SelectedItem = Status;
        }
        private void AddEmploe_Load(object sender, EventArgs e)
        {

        }

        private void editbtn_Click(object sender, EventArgs e)
        {

            string lastn = lname.Text;
            string firstn = fname.Text;
            string Email = email.Text;
            string Contact = contact.Text;
            string Address= address.Text;
            string Status= status.SelectedIndex.ToString();

            staffBL Staff=new staffBL(lastn,firstn,Contact,Email,Address,Status);
            staffDL.UpdateStaff(Staff,Id);
            main.LoadData();
            MessageBox.Show("Updated Successfully");
            this.Close();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {

            string lastn = lname.Text;
            string firstn = fname.Text;
            string Email = email.Text;
            string Contact = contact.Text;
            string Address = address.Text;
            string Status = status.SelectedIndex.ToString();

            staffBL Staff = new staffBL(lastn, firstn, Contact, Email, Address, Status);
            bool isAdd = staffDL.AddStaff(Staff);
            if (isAdd)
            {
                MessageBox.Show("Added Successfully");
                main.LoadData();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
