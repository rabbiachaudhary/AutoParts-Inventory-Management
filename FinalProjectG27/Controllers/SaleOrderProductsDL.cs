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

namespace FinalProjectG27.Controllers
{
    public class SaleOrderProductsDL
    {
        public static DataTable Getorder()
        {
            string query = @"select so.sale_order_id as sale_order_id,so.sodetail_id as sodetail_id ,
                             so.product_id as product_id ,p.product_name as Product, so.quantity as quantity 
                             from sale_order_details so join products p on p.product_id = so.product_id";
            return databasehelper.GetDataTable(query);

        }

        public static DataTable GetProductData()
        {
            string query = @"select p.product_id , p.product_name , c.name as category from products p join product_categories c
                            on p.category_id = c.category_id";
            return databasehelper.GetDataTable(query);

        }
        public static bool AddOrderProducts(SaleOrderProductsBL sale)
        {

            string query = @"insert into sale_order_details (sale_order_id,product_id, quantity) values (@saleid,@productid,@quantity)";
            var parameter = new Dictionary<string, object>
            {
                {"@saleid", sale.SaleOrderID },
                { "@productid", sale.ProductID },
                { "@quantity", sale.Quantity},

            };
            try
            {
                databasehelper.ExecuteDML(query, parameter);
                return true;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error occurred: " + sqlEx.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            catch (InvalidOperationException invOpEx)
            {
                MessageBox.Show("Invalid operation: " + invOpEx.Message, "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public static void UpdateOrderProducts(SaleOrderProductsBL sale, int sodetailId)
        {
            try
            {
                string query = @"update sale_order_details
                             set
                                 product_id = @productid, 
                                 quantity = @quantity                        
                             where sodetail_id = @id";
                var parameter = new Dictionary<string, object>
            {

                { "@productid", sale.ProductID },
                { "@quantity", sale.Quantity},
                { "@id" , sodetailId }

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
        public static void DeleteOrder(int id)
        {
            string query = @"delete from sale_order_details  where sodetail_id = @ID";
            var parameter = new Dictionary<string, object>
            {
                {"@ID", id }
            };
            databasehelper.ExecuteDML(query, parameter);
        }
    }
}
