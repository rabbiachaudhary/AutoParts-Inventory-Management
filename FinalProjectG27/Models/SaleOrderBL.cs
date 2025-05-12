using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27.Models
{
    public class SaleOrderBL
    {
        public int CustomerID;
        public int PaymentID;
        public DateTime Date;
        public string Status;

        public SaleOrderBL(int customerid, int paymentid, DateTime date)
        {

            CustomerID = customerid;
            PaymentID = paymentid;
            Date = date;

        }
        public SaleOrderBL(int customerid, int paymentid, DateTime date, string status)
        {
            CustomerID = customerid;
            PaymentID = paymentid;
            Date = date;
            Status = status;

        }
    }
}

