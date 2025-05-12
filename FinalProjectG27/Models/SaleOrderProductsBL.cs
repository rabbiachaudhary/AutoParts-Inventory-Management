using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27.Models
{
    public class SaleOrderProductsBL
    {
        public int SaleOrderID;
        public int ProductID;
        public int Quantity;

        public SaleOrderProductsBL(int saleid, int productid, int quantity)
        {
            SaleOrderID = saleid;
            ProductID = productid;
            Quantity = quantity;

        }
        public SaleOrderProductsBL(int productid, int quantity)
        {
            ProductID = productid;
            Quantity = quantity;

        }
    }
}
