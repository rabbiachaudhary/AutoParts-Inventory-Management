using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Controllers;
namespace FinalProjectG27.Views
{
    public partial class AddCustomer : Form
    {
        private bool IsAdd;
        private int customerId;
        private CustomersMain main;
        public AddCustomer(CustomersMain main,bool isAdd=true)
        {
            InitializeComponent();
            IsAdd = isAdd;
            this.main = main;
            CustomerText.Text = "Add Customer";
            addbtn.Visible = true;
            editbtn.Visible = false;
        }
        public AddCustomer(CustomersMain main,int id,string Fname, string Lname, string Contact, string Email, string Address,bool IsAdd=false)
        {
            InitializeComponent();
            this.IsAdd = IsAdd;
            this.main = main;
            customerId = id;
            CustomerText.Text = "Edit Customer";
            addbtn.Visible = false;
            editbtn.Visible = true;
            fname.Text= Fname;
            lname.Text= Lname;
            contact.Text = Contact;
            email.Text= Email;
            address.Text= Address;
           

        }


        private void AddCustomer_Load(object sender, EventArgs e)
        {
           
        }

        private void editbtn_Click(object sender, EventArgs e)
        {

            string Fname = fname.Text;
            string Lname = lname.Text;
            string Email = email.Text;
            string Contact = contact.Text.Trim();
            string Address = address.Text;

            // First Name
            if (string.IsNullOrWhiteSpace(Fname))
            {
                MessageBox.Show("First name is required.");
                return;
            }

            // Last Name
            if (string.IsNullOrWhiteSpace(Lname))
            {
                MessageBox.Show("Last name is required.");
                return;
            }

            // Email
            if (string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Email is required.");
                return;
            }

            // Contact
            if (string.IsNullOrWhiteSpace(Contact))
            {
                MessageBox.Show("Contact number is required.");
                return;
            }

            // Address
            if (string.IsNullOrWhiteSpace(Address))
            {
                MessageBox.Show("Address is required.");
                return;
            }

            CustomerBL c = new CustomerBL(Fname, Lname, Contact, Address, Email);
            CustomerDL.UpdateCustomer(c,customerId);
            main.LoadData();
            MessageBox.Show("Updated successfully");
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string Fname = fname.Text;
            string Lname = lname.Text;
            string Email= email.Text;   
            string Contact= contact.Text.Trim();
            string Address= address.Text;

            // First Name
            if (string.IsNullOrWhiteSpace(Fname))
            {
                MessageBox.Show("First name is required.");
                return;
            }

            // Last Name
            if (string.IsNullOrWhiteSpace(Lname))
            {
                MessageBox.Show("Last name is required.");
                return;
            }

            // Email
            if (string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Email is required.");
                return;
            }

            // Contact
            if (string.IsNullOrWhiteSpace(Contact))
            {
                MessageBox.Show("Contact number is required.");
                return;
            }

            // Address
            if (string.IsNullOrWhiteSpace(Address))
            {
                MessageBox.Show("Address is required.");
                return;
            }

            if (Contact.Length != 11 || !Contact.All(char.IsDigit))
            {
                MessageBox.Show("Contact must be exactly 11 digits with no spaces or letters.");
                return;
            }

            CustomerBL c=new CustomerBL(Fname,Lname, Contact, Address, Email);
            bool isAdd =CustomerDL.AddCustomer(c);
            if (isAdd)
            {
                MessageBox.Show("Customer Added successfully");
                main.LoadData();
            }
            else
            {
                MessageBox.Show("Customer Not added");
            }
        }
    }
}
