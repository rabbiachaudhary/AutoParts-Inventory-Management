using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27.Models
{
    internal class StockTransferBL
    {
        public string warehouse;
        public string product;
        public string note;
        public int quantity;
        public StockTransferBL(string warehouse, string product, string note, int quantity)
        {
            this.warehouse = warehouse;
            this.product = product;
            this.note = note;
            this.quantity = quantity;
        }

        public Views.StockTransferMain StockTransferMain
        {
            get => default;
            set
            {
            }
        }
    }
}
