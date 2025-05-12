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
    public class PurchaseOrderDL
    {
        public static DataTable Getorder()
        {
            string query = @"
                                 SELECT 
                                   po.purchase_order_id , 
                                   w.warehouse_name,l.address as address ,
                                   CONCAT(COALESCE(s.first_name, ''), ' ', COALESCE(s.last_name, '')) AS Supplier,
                                   s.contact as contact ,po.payment_method_id as payment_id,
                                   po.supplier_id as supplier_id , po.warehouse_id as warehouse_id,
                              CASE
                                   WHEN po.payment_method_id = 4 THEN 'Cash'
                                   WHEN po.payment_method_id = 5 THEN 'Card'
                                   WHEN po.payment_method_id = 6 THEN 'Online' 
                               END AS Payment_Method,
                                   po.date , po.status 
                                   FROM purchase_orders po 
                                   JOIN suppliers s ON po.supplier_id = s.supplier_id 
                                   JOIN warehouses w ON po.warehouse_id = w.warehouse_id
                                   join locations l on l.location_id = w.location_id
                                ";
            return databasehelper.GetDataTable(query);

        }
        public static DataTable GetSupplier()
        {
            string query = @"select supplier_id , CONCAT(first_name, ' ', last_name) AS full_name,contact FROM suppliers ";
            return databasehelper.GetDataTable(query);
        }
        public static DataTable GetWarehouse()
        {
            string query = @"select warehouse_id , warehouse_name ,locations.address as location FROM warehouses join locations 
                             on locations.location_id = warehouses.location_id";
            return databasehelper.GetDataTable(query);
        }

        public static DataTable GetPaymentmethod()
        {
            string query = @"select lookup_id , value FROM lookup where category = 'Payment Method' ";
            return databasehelper.GetDataTable(query);
        }

        public static int AddPurchaseOrder(PurchaseOrderBL purchase)
        {
            string query = @"insert into purchase_orders (date , payment_method_id , supplier_id ,warehouse_id) values (@date,@paymentid,@supplierid,@warehouseid);
                             SELECT LAST_INSERT_ID(); ";
            var parameter = new Dictionary<string, object>
            {
                {"@date",purchase.Date.ToString("yyyy-MM-dd")},
                { "@paymentid", purchase.PaymentID },
                { "@supplierid", purchase.SupplierID },
                { "@warehouseid", purchase.WarehouseID},


            };
            try
            {
                int newOrderId = Convert.ToInt32(databasehelper.GetSingleInt(query, parameter));
                return newOrderId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
                return 0;
            }

        }
        public static void UpdatePurchaseOrder(PurchaseOrderBL purchase, int purchaseID)
        {
            try
            {
                string query = @"update purchase_orders 
                             set supplier_id = @supplierid, 
                                 warehouse_id = @warehouseid, 
                                 payment_method_id = @paymentid, 
                                 date = @date, 
                                 status = @status                                 
                             where purchase_order_id = @id";
                var parameter = new Dictionary<string, object>
            {
                {"@supplierid", purchase.SupplierID},
                {"@warehouseid", purchase.WarehouseID },
                {"@paymentid", purchase.PaymentID },
                {"@date", purchase.Date},
                {"@status", purchase.Status},
                {"@id", purchaseID }
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
            string query = @"delete from purchase_orders  where purchase_order_id = @ID";
            var parameter = new Dictionary<string, object>
            {
                {"@ID", id }
            };
            databasehelper.ExecuteDML(query, parameter);
        }

        public static DataTable GetSearchData(string search)
        {
            DataTable dt2 = new DataTable();
            string query;

            if (string.IsNullOrWhiteSpace(search))
            {

                query = @"
                                 SELECT 
                                   po.purchase_order_id , 
                                   w.warehouse_name, l.address as address ,
                                   CONCAT(COALESCE(s.first_name, ''), ' ', COALESCE(s.last_name, '')) AS Supplier,
                                   s.contact as contact,po.payment_method_id as payment_id,
                                   po.supplier_id as supplier_id , po.warehouse_id as warehouse_id,
                              CASE
                                   WHEN po.payment_method_id = 4 THEN 'Cash'
                                   WHEN po.payment_method_id = 5 THEN 'Card'
                                   WHEN po.payment_method_id = 6 THEN 'Online' 
                               END AS Payment_Method,
                                   po.date , po.status 
                                   FROM purchase_orders po 
                                   JOIN suppliers s ON po.supplier_id = s.supplier_id 
                                   JOIN warehouses w ON po.warehouse_id = w.warehouse_id
                                   join locations l on l.location_id = w.location_id
                                ";
            }

            else
            {

                query = @"
                                SELECT 
                                   po.purchase_order_id , 
                                   w.warehouse_name, l.address as address ,
                                   CONCAT(COALESCE(s.first_name, ''), ' ', COALESCE(s.last_name, '')) AS Supplier,
                                   s.contact as contact,po.payment_method_id as payment_id,
                                   po.supplier_id as supplier_id , po.warehouse_id as warehouse_id,
                              CASE
                                   WHEN po.payment_method_id = 4 THEN 'Cash'
                                   WHEN po.payment_method_id = 5 THEN 'Card'
                                   WHEN po.payment_method_id = 6 THEN 'Online' 
                               END AS Payment_Method,
                                   po.date , po.status 
                                   FROM purchase_orders po
                                   JOIN suppliers s ON po.supplier_id = s.supplier_id 
                                   JOIN warehouses w ON po.warehouse_id = w.warehouse_id
                                   join locations l on l.location_id = w.location_id
                                   where  po.purchase_order_id LIKE '%" + search + "%'";


            }
            return databasehelper.GetDataTable(query);
        }
    }
}
