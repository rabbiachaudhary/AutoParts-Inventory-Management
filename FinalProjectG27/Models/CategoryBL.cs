using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27.Models
{
    internal class CategoryBL
    {
        public string Name;
        public string Description;
        public decimal Taxp;
        public decimal Markup;

        public CategoryBL(string name,string des,decimal tax,decimal markup) 
        {
            Name = name;
            Description = des;
            Taxp = tax;
            Markup = markup;
        }

        public Views.CategoryMain CategoryMain
        {
            get => default;
            set
            {
            }
        }
    }
}
