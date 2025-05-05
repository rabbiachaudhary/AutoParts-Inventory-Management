using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27
{
    internal class locationsBL
    {
        public string address;
        public string city;
        public string postalcode;
        public locationsBL (string address, string city, string postalcode)
        {
            this.address = address;
            this.city = city;
            this.postalcode = postalcode;
        }
    }
}
