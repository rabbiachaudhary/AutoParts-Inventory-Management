
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectG27
{
    internal class staffDL
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
        public static void UpdateStaff(staffBL s,int id)
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
