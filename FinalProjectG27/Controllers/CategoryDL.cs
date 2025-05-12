using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Database;
using FinalProjectG27.Models;
using MySql.Data.MySqlClient;

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

        public static void updateCategory(CategoryBL c, int id)
        {
            try
            {
                string query = @"UPDATE product_categories
                         SET name = @name,
                             description = @des,
                             tax_percent = @tax,
                             markup_percent = @markup
                         WHERE category_id = @id";

                var parameter = new Dictionary<string, object>
        {
                        { "@name", c.Name },
                        { "@des", c.Description },
                        { "@tax", c.Taxp },
                        { "@markup", c.Markup },
                        { "@id", id }
        };

                databasehelper.ExecuteDML(query, parameter);
                
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error occurred: " + sqlEx.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (InvalidOperationException invOpEx)
            {
                MessageBox.Show("Invalid operation: " + invOpEx.Message, "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static DataTable GetCategories()
        {
            string query = "select category_id, name,description,tax_percent,markup_percent from product_categories";
            return databasehelper.GetDataTable(query);
        }

        //for combo box

        public static DataTable GetAllCategories()
        {
            string query = "SELECT category_id,name FROM product_categories"; 
            return databasehelper.GetDataTable(query);
        }

        public static void DeleteCategory(int id)

        {

            try
            {
                string query = "Delete from product_categories where category_id=@id";
                var parameter = new Dictionary<string, object>
            {
                { "@id", id },
            };
                databasehelper.ExecuteDML(query, parameter);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("error: " + sqlEx.Message);
            }
        }

        public static DataTable SearchCategoryByName(string categoryName)
        {
            string query = "SELECT * FROM product_categories WHERE name LIKE @search";
            var parameter = new Dictionary<string, object>
            {
                { "@search", "%" + categoryName + "%" }
            };
            return databasehelper.GetDataTable(query, parameter);
        }

    }
}