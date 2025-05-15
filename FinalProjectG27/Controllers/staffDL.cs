
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
using MySql.Data.MySqlClient;

namespace FinalProjectG27
{
    internal class staffDL
    {
        internal staffBL staffBL
        {
            get => default;
            set
            {
            }
        }

        public static bool AddStaff(staffBL s, credentialsBL c)
        {
            using (MySqlConnection con = new MySqlConnection(databasehelper.constring))
            {
                try
                {
                    con.Open();

                    string staffQuery = @"
                INSERT INTO staff (first_name, last_name, contact, email, address, status)
                VALUES (@fname, @lname, @contact, @email, @address, @status);
                SELECT LAST_INSERT_ID();";

                    int staffId = -1;

                    using (MySqlCommand cmd = new MySqlCommand(staffQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@fname", s.fname);
                        cmd.Parameters.AddWithValue("@lname", s.lname);
                        cmd.Parameters.AddWithValue("@contact", s.contact);
                        cmd.Parameters.AddWithValue("@email", s.email);
                        cmd.Parameters.AddWithValue("@address", s.address);
                        cmd.Parameters.AddWithValue("@status", s.status.Trim());

                        object result = cmd.ExecuteScalar();
                        if (result == null || !int.TryParse(result.ToString(), out staffId))
                        {
                            MessageBox.Show("Failed to insert staff or retrieve staff ID.");
                            return false;
                        }
                    }

                    int roleId = -1;
                    string roleQuery = "SELECT lookup_id FROM lookup WHERE value = @role AND category = 'UserRole'";
                    using (MySqlCommand cmd = new MySqlCommand(roleQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@role", c.Role.Trim());
                        object result = cmd.ExecuteScalar();
                        if (result == null || !int.TryParse(result.ToString(), out roleId))
                        {
                            MessageBox.Show("Invalid role: " + c.Role);
                            return false;
                        }
                    }

                    string credentialsQuery = @"
                INSERT INTO credentials (staff_id, username, password_hash, role_id)
                VALUES (@staff, @username, @pass, @roleId)";
                    using (MySqlCommand cmd = new MySqlCommand(credentialsQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@staff", staffId);
                        cmd.Parameters.AddWithValue("@username", c.Username);
                        cmd.Parameters.AddWithValue("@pass", c.Password);
                        cmd.Parameters.AddWithValue("@roleId", roleId);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows <= 0)
                        {
                            MessageBox.Show("Failed to insert credentials.");
                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public static DataTable GetStaff()
        {
            string query = "select staff.staff_id,first_name,last_name,contact,email,address,status,username,password_hash,value from staff join credentials on staff.staff_id=credentials.staff_id join lookup on lookup.lookup_id=role_id";
            return databasehelper.GetDataTable(query);
        }
        public static void UpdateStaff(staffBL s,int id,credentialsBL c)
        {
            try
            {
                string query = @"update staff 
                             set first_name = @fname, 
                                 last_name = @lname, 
                                 contact = @contact, 
                                 email = @email, 
                                 address = @address, 
                                 status = @stats 
                             where staff_id = @id";
                var parameter = new Dictionary<string, object>
                {
                    {"@fname", s.fname },
                    {"@lname", s.lname },
                    {"@contact", s.contact },
                    {"@email", s.email },
                    {"@address", s.address },
                    {"@stats", s.status },
                    {"@id", id }
                };
                MessageBox.Show(query);
                databasehelper.ExecuteDML(query, parameter);

                string querycred = @"update credentials
                             set username=@user, password_hash=@pass,role_id=(select lookup_id from lookup where value=@role and category='UserRole' )
                             where staff_id = @id";
                var parameter1 = new Dictionary<string, object>
                {
                    {"@user", c.Username },
                    {"@pass", c.Password },
                    {"@role", c.Role },
                    {"@id", id }
                };
                databasehelper.ExecuteDML(querycred, parameter1);

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
            string query1 = @"delete from credentials where staff_id=@id";

            var parameter1 = new Dictionary<string, object>
            {
                {"@ID", id }
            };
            try
            {
                
                databasehelper.ExecuteDML(query, parameter);
                databasehelper.ExecuteDML(query1, parameter1); // Pass parameters here
                // Pass parameters here
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting staff: " + ex.Message);
                return false;
            }
        }

        public static DataTable GetSearchData(string search)
        {
            DataTable dt2 = new DataTable();
            string query;

            if (string.IsNullOrWhiteSpace(search))
            {

                query = "select staff.staff_id,first_name,last_name,contact,email,address,status,username,password_hash,value from staff join credentials on staff.staff_id=credentials.staff_id join lookup on lookup.lookup_id=role_id";
            }

            else
            {

                query = "select staff.staff_id,first_name,last_name,contact,email,address,status,username,password_hash,value from staff join credentials on staff.staff_id=credentials.staff_id join lookup on lookup.lookup_id=role_id where username like '%"+search+"%'";


            }
            return databasehelper.GetDataTable(query);
        }

    }
}
