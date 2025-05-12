using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectG27.Database;

namespace FinalProjectG27.Controllers
{
    internal class ProductsDL
    {
        public static bool AddProduct(ProductsBL s)
        {
            string query = @"insert into products (product_name,weight,description, size,warranty,category_id,purchase_price,sale_price)
                            values (@name,@weight,@description,@size,@warranty,@category,@purPrice,@salePrice)";
            var parameter = new Dictionary<string, object>
            {
                {"@name",s.ProductName },
                { "@description", s.ProductDescription },
                { "@size", s.Size },
                { "@warranty", s.Warranty },
                { "@weight", s.Weight },
                { "@category", s.CategoryId },
                { "@purPrice", s.PurPrice },
                { "@salePrice", s.SalePrice }
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
        public static DataTable GetStaff()
        {
            string query = "select* from products";
            return databasehelper.GetDataTable(query);
        }
        public static void UpdateProduct(ProductsBL s, int id)
        {
            string query = @"update products 
                             set product_name = @pn, 
                                 weight = @w, 
                                 description = @d, 
                                 size = @s, 
                                 warranty = @war, 
                                 category_id = @c,
                                 purchase_price=@pp,
                                 sale_price=@sp
                                 where product_id = @id";
            var parameter = new Dictionary<string, object>
            {
                {"@pn", s.ProductName },
                {"@w", s.Weight },
                {"@d", s.ProductDescription },
                {"@s", s.Size },
                {"@war", s.Warranty },
                {"@c", s.CategoryId },
                {"@pp", s.PurPrice },
                {"@sp", s.SalePrice },
                {"@id", id }
            };
            databasehelper.ExecuteDML(query, parameter);
        }
        public static void DeleteProduct(int id)
        {
            string query = @"delete from products where product_id=@ID";
            var parameter = new Dictionary<string, object>
            {
                {"@ID",id }
            };
            databasehelper.ExecuteDML(query,parameter);
        }

        public static int GetCategoryIdByName(string categoryName)
        {
            int categoryId = -1;
            string query = "SELECT category_id FROM product_categories WHERE name = @categoryName";

            var parameter = new Dictionary<string, object>
            {
                { "@categoryName" , categoryName }
            };

            object result = databasehelper.GetSingleInt(query, parameter);

            if (result != null && int.TryParse(result.ToString(), out int id))
            {
                categoryId = id;
            }

            return categoryId;
        }

        public static DataTable GetData()
        {
            string query = "select* from products";
            return databasehelper.GetDataTable(query);
        }

        public static string GetCategoryNameById(int categoryId)
        {
            string categoryName = "";
            string query = "SELECT name FROM product_categories WHERE category_id = @categoryId";

            var parameter = new Dictionary<string, object>
    {
        { "@categoryId", categoryId }
    };

            object result = databasehelper.GetSingleValue(query, parameter);

            if (result != null)
            {
                categoryName = result.ToString();
            }

            return categoryName;
        }

        public static DataTable SearchProductByName(string ProductName)
        {
            string query = "SELECT * FROM products WHERE product_name LIKE @search";
            var parameter = new Dictionary<string, object>
            {
                { "@search", "%" + ProductName + "%" }
            };
            return databasehelper.GetDataTable(query, parameter);
        }
    }
}
