
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectG27
{
    internal class staffDL
    {
        public static bool AddStaff(staffBL s)
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

            try
            {
                databasehelper.ExecuteDML(query, parameter);
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error adding product: " + ex.Message);
                return false;
            }
        }
        public static DataTable GetStaff()
        {
            string query = "select staff_id,first_name,last_name,contact,email,address,status from staff";
            return databasehelper.GetDataTable(query);
        }
        public static void UpdateStaff(staffBL s,int id)
        {
            try
            {
                string query = @"update staff 
                             set first_name = @fname, 
                                 last_name = @lname, 
                                 contact = @contact, 
                                 email = @email, 
                                 address = @address, 
                                 status = @status 
                             where staff_id = @id";
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
        public static bool DeleteStaff(int id)
        {
            string query = @"delete from staff where staff_id=@ID";
            var parameter = new Dictionary<string, object>
    {
        {"@ID", id }
    };
            try
            {
                databasehelper.ExecuteDML(query, parameter); // Pass parameters here
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting staff: " + ex.Message);
                return false;
            }
        }

    }
}
