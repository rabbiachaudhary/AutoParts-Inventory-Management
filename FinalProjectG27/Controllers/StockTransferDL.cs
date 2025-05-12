using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectG27.Database;
using FinalProjectG27.Models;
namespace FinalProjectG27.Controllers
{
    internal class StockTransferDL
    {
        public static bool Addtransfer(StockTransferBL s)
        {
            string query = @"insert into stock_transfer(warehouse_id,product_id,quantity,note)
                            values((select warehouse_id from warehouses where warehouse_name=@name),(select product_id from products where product_name=@p),@q,@n)";
            var parameter = new Dictionary<string, object>
            {
                {"@name",s.warehouse },
                {"@p",s.product },
                {"@q",s.quantity },
                {"@n",s.note }

            };
            try
            {
                databasehelper.ExecuteDML(query, parameter);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error adding transfer: " + ex.Message);
                return false;
            }
        }
        public static void UpdateTransfer(StockTransferBL s, int id)
        {
            string query = @"update stock_transfer set warehouse_id=(select warehouse_id from warehouses where warehouse_name=@name),
                            product_id=(select product_id from products where product_name=@p),
                             quantity=@q, note=@n";
            var parameter = new Dictionary<string, object>
            {
                {"@name",s.warehouse },
                {"@p",s.product },
                {"@q",s.quantity },
                {"@n",s.note }

            };
            databasehelper.ExecuteDML(query, parameter);
        }
        public static void DeleteTransfer(int id)
        {
            string query = @"delete from stock_transfer where transfer_id=@ID";
            var parameter = new Dictionary<string, object>
            {
                {"@ID",id }
            };
            databasehelper.ExecuteDML(query, parameter);
        }


        public static DataTable GetTransfer()
        {
            string query = "select transfer_id,warehouse_name,product_name, quantity,note from stock_transfer st join warehouses w on w.warehouse_id=st.warehouse_id join products on p.product_id=st.product_id";
            return databasehelper.GetDataTable(query);
        }

        public static DataTable GetSearchData(string search)
        {
            DataTable dt2 = new DataTable();
            string query;

            if (string.IsNullOrWhiteSpace(search))
            {
                 query = "select transfer_id, warehouse_name,product_name, quantity,note from stock_transfer st join warehouses w on w.warehouse_id=st.warehouse_id join products on p.product_id=st.product_id";

            }

            else
            {
                query = "select  transfer_id,warehouse_name,product_name, quantity,note from stock_transfer st join warehouses w on w.warehouse_id=st.warehouse_id join products on p.product_id=st.product_id where warehouse_name like '%" + search+"%'";



            }
            return databasehelper.GetDataTable(query);
        }
    }
}
