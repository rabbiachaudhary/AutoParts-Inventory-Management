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
    public class SupplierDL
    {
        public static DataTable GetSupplier()
        {
            string query = "select * from suppliers";
            return databasehelper.GetDataTable(query);
        }
        public static DataTable GetSearchData(string search)
        {
            DataTable dt2 = new DataTable();
            string query;

            if (string.IsNullOrWhiteSpace(search))
            {

                query = "select * from suppliers";
            }

            else
            {

                query = "select * from suppliers where first_name  LIKE '%" + search + "%'";


            }
            return databasehelper.GetDataTable(query);
        }
        public static void AddSupplier(SupplierBL supplier)
        {
            string query = @"insert into suppliers (first_name,last_name,contact, email,address) values (@fname,@lname,@contact,@email,@address)";
            var parameter = new Dictionary<string, object>
            {
                {"@fname",supplier.Firstname },
                { "@lname", supplier.Lastname },
                { "@contact", supplier.Contact },
                { "@email", supplier.Email },
                { "@address", supplier.Address },

            };
            databasehelper.ExecuteDML(query, parameter);
        }

        public static void UpdateSupplier(SupplierBL supplier, int supplierID)
        {
            string query = @"update suppliers 
                             set first_name = @fname, 
                                 last_name = @lname, 
                                 contact = @contact, 
                                 email = @email, 
                                 address = @address                                 
                             where supplier_id = @id";
            var parameter = new Dictionary<string, object>
            {
                {"@fname", supplier.Firstname },
                {"@lname", supplier.Lastname },
                {"@contact", supplier.Contact },
                {"@email", supplier.Email },
                {"@address", supplier.Address },
                {"@id", supplierID }
            };
            databasehelper.ExecuteDML(query, parameter);
        }
        public static void DeleteSupplier(int id)
        {
            string query = @"delete from suppliers where supplier_id=@ID";
            var parameter = new Dictionary<string, object>
            {
                {"@ID",id }
            };
            databasehelper.ExecuteDML(query, parameter);
        }
    }
}
