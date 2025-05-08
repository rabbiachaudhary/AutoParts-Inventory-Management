using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectG27.Controllers
{
    internal class CustomerDL
    {
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
    }
}
