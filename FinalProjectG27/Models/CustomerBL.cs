using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27
{
    internal class CustomerBL
    {
        public string fname;
        public string lname;
        public string Contact;
        public string Address;
        public string Email;

        public CustomerBL(string fname,string lname,string contact,string address,string email)
        {
            this.fname = fname;
            this.lname = lname;
            Contact = contact;
            Address = address;
            Email = email;

        }


    }
}
