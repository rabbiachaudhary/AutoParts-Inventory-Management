using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using FinalProjectG27.Controllers;
using MySql.Data.MySqlClient;
using System.Data;
using FinalProjectG27.Database;

namespace FinalProjectG27.Controllers
{
    internal class ReportsDL
    {
        public static DataTable Getreport(string reporttype)
        {
            DataTable dt = new DataTable();
            string query = "";
            if (reporttype == "Products")
            {
                query = "select * from all_products";

            }
            else if(reporttype== "Available Shop Stock")
            {
                query = "select * from available_shop_stock";

            }
            else if (reporttype == "Category Profits")
            {
                query = "select * from category_profitability";

            }
            else if (reporttype == "Completed Orders")
            {
                query = "select * from completed_orders";

            }
            else if (reporttype == "Customers Purchase History")
            {
                query = "select * from customer_purchase_history";

            }
            else if (reporttype == "Daily Profit")
            {
                query = "select * from daily_profit";

            }
            else if (reporttype == "Expired Batches")
            {
                query = "select * from expiredbatchs";

            }
            else if (reporttype == "Product Price History")
            {
                query = "select * from product_price_history";

            }
            else if (reporttype == "Supplier Performance")
            {
                query = "select * from supplier_performance";

            }
            else if (reporttype == "Top Selling Products")
            {
                query = "select * from top_selling_products";

            }
            else if (reporttype == "Unavailable Shop Stock")
            {
                query = "select * from unaavailable_shop_stock";

            }
            else if (reporttype == "View Stock Transfer")
            {
                query = "select * from view_stock_transfer";

            }
            else if (reporttype == "Purchase Invoice")
            {
                query = "select * from purchases_invoice";

            }
            
            dt = databasehelper.GetDataTable(query);
            return dt;
        }
    }
}
