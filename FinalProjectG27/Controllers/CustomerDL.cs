using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Database;

namespace FinalProjectG27.Controllers
{
    internal class CustomerDL
    {
        internal CustomerBL CustomerBL
        {
            get => default;
            set
            {
            }
        }

        public static bool AddCustomer(CustomerBL c)
        {
            string query = @"insert into customers (first_name,last_name,contact,email,address) values(@fname,@lname,@contact,@email,@address)";

            var parameter = new Dictionary<string, object>
            {
                {"@fname",c.fname },
                {"@lname", c.lname },
                {"@contact", c.Contact },
                {"@email", c.Email },
                {"@address",c.Address }

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

        public static void UpdateCustomer(CustomerBL s,int id)
        {
            try
            {
                string query = @"update customers 
                             set first_name = @fname, 
                                 last_name = @lname, 
                                 contact = @contact, 
                                 email = @email, 
                                 address = @address
                                 where customer_id = @id";
                var parameter = new Dictionary<string, object>
            {
                {"@fname", s.fname },
                {"@lname", s.lname },
                {"@contact", s.Contact },
                {"@email", s.Email },
                {"@address", s.Address },
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

        public static DataTable GetData()
        {
            string query = "select * from customers";
            return databasehelper.GetDataTable(query);
        }

        public static void DeleteCustomer(int id)
        {
            string query = @"delete from customers where customer_id=@ID";
            var parameter = new Dictionary<string, object>
            {
                {"@ID",id }
            };
            databasehelper.ExecuteDML(query,parameter);
        }

        public static DataTable SearchCustomerByName(string Name)
        {
            string query = "SELECT * FROM customers WHERE first_name LIKE @search";
            var parameter = new Dictionary<string, object>
            {
                { "@search", "%" + Name + "%" }
            };
            return databasehelper.GetDataTable(query, parameter);
        }
    }
}
