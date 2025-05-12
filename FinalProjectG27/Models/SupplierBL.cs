using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace FinalProjectG27.Models
{
    public class SupplierBL
    {
        public string Firstname;
        public string Lastname;
        public string Contact;
        public string Email;
        public string Address;

        public SupplierBL(string fname, string lname, string contact, string email, string address)
        {
            Firstname = fname;
            Lastname = lname;
            Contact = contact;
            Email = email;
            Address = address;

        }
    }
}
