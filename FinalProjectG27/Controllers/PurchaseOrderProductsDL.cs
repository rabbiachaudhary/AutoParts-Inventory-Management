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
    public class PurchaseOrderProductsDL
    {
        public static DataTable Getorder()
        {
            string query = @"select po.purchase_order_id as purchase_order_id,po.podetail_id as podetail_id ,
                             po.product_id as product_id ,p.product_name as product, po.quantity as quantity 
                             from purchase_order_details po join products p on p.product_id = po.product_id";
            return databasehelper.GetDataTable(query);

        }
        public static DataTable GetProductData()
        {
            string query = @"select p.product_id , p.product_name , c.name as category from products p join product_categories c
                            on p.category_id = c.category_id";
            return databasehelper.GetDataTable(query);

        }
        public static bool AddOrderProducts(PurchaseOrderProductsBL purchase)
        {
            string query = @"insert into purchase_order_details (purchase_order_id,product_id, quantity) values (@purchaseid,@productid,@quantity)";
            var parameter = new Dictionary<string, object>
            {
                {"@purchaseid", purchase.PurchaseOrderID },
                { "@productid", purchase.ProductID },
                { "@quantity", purchase.Quantity},

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
        public static void UpdateOrderProducts(PurchaseOrderProductsBL purchase, int PodetailId)
        {
            try
            {
                string query = @"update purchase_order_details
                             set
                                 product_id = @productid, 
                                 quantity = @quantity                        
                             where podetail_id = @id";
                var parameter = new Dictionary<string, object>
            {

                { "@productid", purchase.ProductID },
                { "@quantity", purchase.Quantity},
                { "@id" , PodetailId }

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
            string query = @"delete from purchase_order_details  where podetail_id = @ID";
            var parameter = new Dictionary<string, object>
            {
                {"@ID", id }
            };
            databasehelper.ExecuteDML(query, parameter);
        }

    }
}
