using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27
{
    internal class staffBL
    {
        public string fname;
        public string lname;
        public string contact;
        public string email;
        public string address;
        public string status; // active or inactive
        public staffBL(string fname,string lname, string contact,string email,string address, string status)
        {
            this.fname = fname;
            this.lname = lname;
            this.contact = contact;
            this.email = email;
            this.address = address;
            this.status = status;
        }

        public Views.EmployeesMain EmployeesMain
        {
            get => default;
            set
            {
            }
        }
    }
}
