using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectG27.Models;

namespace FinalProjectG27.Controllers
{
    internal class CategoryDL
    {
        public static bool AddCategory(CategoryBL s)
        {


            string query = @"insert into product_categories (name,description,tax_percent,markup_percent )
                            values (@name,@description,@tax,@markup)";
            var parameter = new Dictionary<string, object>
            {
                {"@name",s.Name },
                { "@description", s.Description },
                { "@tax", s.Taxp },
                { "@markup", s.Markup }

            };
            try
            {
                databasehelper.ExecuteDML(query, parameter);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error adding product: " + ex.Message);
                return false;
            }
        }

        public static DataTable GetCategories()
        {
            string query = "select name,description,tax_percent,markup_percent from product_categories";
            return databasehelper.GetDataTable(query);
        }
    }
}
