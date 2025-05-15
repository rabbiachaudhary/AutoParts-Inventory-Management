using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27.Models
{
    public class PurchaseOrderProductsBL
    {
        public int PurchaseOrderID;
        public int ProductID;
        public int Quantity;

        public PurchaseOrderProductsBL(int purchaseid, int productid, int quantity)
        {
            PurchaseOrderID = purchaseid;
            ProductID = productid;
            Quantity = quantity;

        }
        public PurchaseOrderProductsBL(int productid, int quantity)
        {

            ProductID = productid;
            Quantity = quantity;

        }

        public Views.PurchaseOrderMain PurchaseOrderMain
        {
            get => default;
            set
            {
            }
        }
    }
}
