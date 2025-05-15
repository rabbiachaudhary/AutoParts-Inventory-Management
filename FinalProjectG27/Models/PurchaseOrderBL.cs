using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27.Models
{
    public class PurchaseOrderBL
    {
        public int SupplierID;
        public int WarehouseID;
        public int PaymentID;
        public DateTime Date;
        public string Status;

        public PurchaseOrderBL(int supplierid, int warehouseid, int paymentid, DateTime date)
        {
            SupplierID = supplierid;
            WarehouseID = warehouseid;
            PaymentID = paymentid;
            Date = date;

        }
        public PurchaseOrderBL(int supplierid, int warehouseid, int paymentid, DateTime date, string status)
        {
            SupplierID = supplierid;
            WarehouseID = warehouseid;
            PaymentID = paymentid;
            Date = date;
            Status = status;

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
