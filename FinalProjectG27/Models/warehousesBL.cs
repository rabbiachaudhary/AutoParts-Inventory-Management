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
        public string address;
        public string city;
        public string postalcode;
        public warehousesBL(string name, string address,string city,string postal)
        {
            this.name = name;
            this.address = address;
            this.city = city;
            this.postalcode = postal;
        }

        public Views.WarehouseStockMain WarehouseStockMain
        {
            get => default;
            set
            {
            }
        }
    }
}
