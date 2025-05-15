using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Mozilla;

namespace FinalProjectG27
{
    internal class ProductsBL
    {
        public string ProductName;
        public string ProductDescription;
        public decimal Weight;
        public string Size;
        public string Warranty;
        public decimal PurPrice;
        public decimal SalePrice;
        public int CategoryId;

        public ProductsBL(string p,string pd,decimal w,string s,string wa,decimal pp,decimal sp,int Cid )
        {
            ProductName = p;    
            ProductDescription = pd;
            Weight = w;
            Size = s;
            Warranty= wa;
            PurPrice = pp;
            SalePrice = sp;
            CategoryId = Cid;
        }

        public Views.ProductMain ProductMain
        {
            get => default;
            set
            {
            }
        }
    }


}
