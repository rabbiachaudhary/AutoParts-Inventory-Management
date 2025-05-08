using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27
{
    internal class warehousesDL
    {
        public static void AddWarehouse(warehousesBL q)
        {
            string query = @"insert into locations(address , city,postal_code) values(@a,@c,@p)";
            var parameter = new Dictionary<string, object>
            {
                {"@a",q.address },
                { "@c", q.city },
                { "@p", q.postalcode }
            };
            databasehelper.ExecuteDML(query, parameter);

            
            string query1 = @"insert into warehuses(warehouse_name,location_id) values (@w,(select location_id from locations where address=@a and city=@c and postal_code=@p))";
            var parameters = new Dictionary<string, object>
            {
                {"@w",q.name },
                {"@a",q.address },
                { "@c", q.city },
                { "@p", q.postalcode }
            };
            databasehelper.ExecuteDML(query, parameters);
        }
        public static DataTable GetWarehouses()
        {
            string query = "select warehouse_name, address, city, postal_code from warehouses join locations on locations.location_id=warehouses.location_id";
            return databasehelper.GetDataTable(query);
        }
        public static void UpdateStaff(staffBL s, int id)
        {
            string query = @"update staff 
                             set first_name = @fname, 
                                 last_name = @lname, 
                                 contact = @contact, 
                                 email = @email, 
                                 address = @address, 
                                 status = @status 
                             where id = @id";
            var parameter = new Dictionary<string, object>
            {
                {"@fname", s.fname },
                {"@lname", s.lname },
                {"@contact", s.contact },
                {"@email", s.email },
                {"@address", s.address },
                {"@status", s.status },
                {"@id", id }
            };
            databasehelper.ExecuteDML(query, parameter);
        }
        public static void DeleteStaff(int id)
        {
            string query = @"delete from staff where id=@ID";
            var parameter = new Dictionary<string, object>
            {
                {"@ID",id }
            };
            databasehelper.ExecuteDML(query);
        }
    }
}
