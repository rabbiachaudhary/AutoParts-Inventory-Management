using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27
{
    internal class warehousesBL
    {
        public string name;
        public locationsBL location;
        public warehousesBL(string name, locationsBL location)
        {
            this.name = name;
            this.location = location;
        }
    }
}
