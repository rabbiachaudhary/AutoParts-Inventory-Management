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

        public AddEmployeee(EmployeesMain main, int id, string LastName,string FirstName,string Contact,string Email,String Address, string Status,string username,string pass,string role, bool isAdd = false)
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
            Usernamelbl.Text=username;
            status.SelectedItem = role;
            passlbl.Text = pass;
        }
        private void AddEmploe_Load(object sender, EventArgs e)
        {

        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            string lastn = lname.Text.Trim();
            string firstn = fname.Text.Trim();
            string Email = email.Text.Trim();
            string Contact = contact.Text.Trim();
            string Address = address.Text.Trim();
            string Status = status.SelectedItem?.ToString(); 

            string username = Usernamelbl.Text.Trim();
            string pass = passlbl.Text.Trim();
            string role = rolecmb.SelectedItem?.ToString();

            // Validation check
            if (string.IsNullOrEmpty(lastn) || string.IsNullOrEmpty(firstn) ||
                string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contact) ||
                string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Status) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass) ||
                string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            staffBL Staff = new staffBL(lastn, firstn, Contact, Email, Address, Status);
            credentialsBL c = new credentialsBL(username, pass, role);

            staffDL.UpdateStaff(Staff, Id, c);
            main.LoadData();
            MessageBox.Show("Updated Successfully");
            this.Close();

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string lastn = lname.Text.Trim();
            string firstn = fname.Text.Trim();
            string Email = email.Text.Trim();
            string Contact = contact.Text.Trim();
            string Address = address.Text.Trim();
            string Status = status.SelectedItem?.ToString();

            string username = Usernamelbl.Text.Trim();
            string pass = passlbl.Text.Trim();
            string role = rolecmb.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(lastn) || string.IsNullOrEmpty(firstn) ||
                string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contact) ||
                string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Status) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass) ||
                string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            staffBL Staff = new staffBL(lastn, firstn, Contact, Email, Address, Status);
            credentialsBL c = new credentialsBL(username, pass, role);

            bool isAdd = staffDL.AddStaff(Staff, c);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
