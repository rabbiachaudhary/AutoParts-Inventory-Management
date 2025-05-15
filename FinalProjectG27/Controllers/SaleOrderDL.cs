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
    public class SaleOrderDL
    {
        public SaleOrderBL SaleOrderBL
        {
            get => default;
            set
            {
            }
        }

        public static DataTable Getorder()
        {
            string query = @"
                                 SELECT 
                                   s.sale_order_id ,
                                   CONCAT(COALESCE(c.first_name, ''), ' ', COALESCE(c.last_name, '')) AS Customer,
                                   c.contact,
                                   s.payment_method_id as payment_id,
                                   s.customer_id,
                              CASE
                                   WHEN s.payment_method_id = 4 THEN 'Cash'
                                   WHEN s.payment_method_id = 5 THEN 'Card'
                                   WHEN s.payment_method_id = 6 THEN 'Online' 
                               END AS Payment_Method,
                                   s.date , s.status 
                                   FROM sale_orders s 
                                   JOIN customers c on c.customer_id = s.customer_id ";
            return databasehelper.GetDataTable(query);

        }
        public static DataTable GetPaymentmethod()
        {
            string query = @"select lookup_id , value FROM lookup where category = 'Payment Method' ";
            return databasehelper.GetDataTable(query);
        }
        public static DataTable GetCustomer()
        {
            string query = @"select customer_id , CONCAT(COALESCE(first_name, ''), ' ', COALESCE(last_name, '')) AS fullname,contact FROM customers ";
            return databasehelper.GetDataTable(query);
        }
        public static int AddSaleOrder(SaleOrderBL sale)
        {
            string query = @"insert into sale_orders (date , payment_method_id , customer_id ) values (@date,@paymentid,@customerid);
                             SELECT LAST_INSERT_ID();";
            var parameter = new Dictionary<string, object>
            {
                {"@date",sale.Date.ToString("yyyy-MM-dd")},
                { "@paymentid", sale.PaymentID },
                { "@customerid", sale.CustomerID },

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
        public static void UpdateSaleOrder(SaleOrderBL sale, int SaleID)
        {
            try
            {
                string query = @"update sale_orders 
                             set customer_id = @customerid,                                
                                 payment_method_id = @paymentid, 
                                 date = @date, 
                                 status = @status                                 
                             where sale_order_id = @id";
                var parameter = new Dictionary<string, object>
            {
                {"@customerid", sale.CustomerID},
                {"@paymentid", sale .PaymentID },
                {"@date",sale.Date},
                {"@status",sale.Status},
                {"@id", SaleID }
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
            string query = @"delete from sale_orders  where sale_order_id = @ID";
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
                                   s.sale_order_id ,
                                   CONCAT(COALESCE(c.first_name, ''), ' ', COALESCE(c.last_name, '')) AS Customer,
                                   c.contact,
                                   s.payment_method_id as payment_id,
                                   s.customer_id,
                              CASE
                                   WHEN s.payment_method_id = 4 THEN 'Cash'
                                   WHEN s.payment_method_id = 5 THEN 'Card'
                                   WHEN s.payment_method_id = 6 THEN 'Online' 
                               END AS Payment_Method,
                                   s.date , s.status 
                                   FROM sale_orders s 
                                   JOIN customers c on c.customer_id = s.customer_id ";
            }

            else
            {

                query = @"
                                 SELECT 
                                   s.sale_order_id ,
                                   CONCAT(COALESCE(c.first_name, ''), ' ', COALESCE(c.last_name, '')) AS Customer,
                                   c.contact,
                                   s.payment_method_id as payment_id,
                                   s.customer_id,
                              CASE
                                   WHEN s.payment_method_id = 4 THEN 'Cash'
                                   WHEN s.payment_method_id = 5 THEN 'Card'
                                   WHEN s.payment_method_id = 6 THEN 'Online' 
                               END AS Payment_Method,
                                   s.date , s.status 
                                   FROM sale_orders s 
                                   JOIN customers c on c.customer_id = s.customer_id where   s.sale_order_id LIKE '%" + search + "%'";


            }
            return databasehelper.GetDataTable(query);
        }
    }
}
