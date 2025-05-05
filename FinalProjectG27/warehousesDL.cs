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
        public static void AddStaff(staffBL s)
        {
            string query = @"insert into staff (first_name,last_name,contact, email,address,status) values (@fname,@lname,@contact,@email,@address,@status)";
            var parameter = new Dictionary<string, object>
            {
                {"@fname",s.fname },
                { "@lname", s.lname },
                { "@contact", s.contact },
                { "@email", s.email },
                { "@address", s.address },
                { "@status", s.status }
            };
            databasehelper.ExecuteDML(query, parameter);
        }
        public static DataTable GetStaff()
        {
            string query = "select first_name,last_name,contact,email,address,status from staff";
            return databasehelper.GetDataTable(query);
        }
    }
}
