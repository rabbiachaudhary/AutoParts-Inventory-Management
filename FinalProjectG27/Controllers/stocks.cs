using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectG27.Database;

namespace FinalProjectG27.Models
{
    internal class stocks

    {

        public static DataTable getWarehouseStock()
        {

            string query = @"select warehouse_name,product_name,quantity,last_updated from warehouse_stock join warehouses on warehouses.warehouse_id=warehouse_stock.warehouse_id join products on products.product_id=warehouse_stock.product_id";

            return databasehelper.GetDataTable(query);
        }
        public static DataTable WSGetSearchData(string search)
        {
            DataTable dt2 = new DataTable();
            string query;

            if (string.IsNullOrWhiteSpace(search))
            {
                query = @"select warehouse_name,product_name,quantity,last_updated from warehouse_stock join warehouses on warehouses.warehouse_id=warehouse_stock.warehouse_id join products on products.product_id=warehouse_stock.product_id";

            }

            else
            {
                query = @"select warehouse_name,product_name,quantity,last_updated from warehouse_stock join warehouses on warehouses.warehouse_id=warehouse_stock.warehouse_id join products on products.product_id=warehouse_stock.product_id WHERE warehouse_name like '%"+search+"%'";



            }
            return databasehelper.GetDataTable(query);
        }
        public static DataTable getShopStock()
        {

            string query = @"select product_name,quantity,last_updated from shop_stock  join products on products.product_id=shop_stock.product_id";

            return databasehelper.GetDataTable(query);
        }
        public static DataTable SSGetSearchData(string search)
        {
            DataTable dt2 = new DataTable();
            string query;

            if (string.IsNullOrWhiteSpace(search))
            {
                query = @"select product_name,quantity,last_updated from shop_stock  join products on products.product_id=shop_stock.product_id";

            }

            else
            {

                 query = @"select product_name,quantity,last_updated from shop_stock  join products on products.product_id=shop_stock.product_id where product_name like '%"+search+"%'";


            }
            return databasehelper.GetDataTable(query);
        }
    }
}
