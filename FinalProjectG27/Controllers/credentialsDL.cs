using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectG27.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalProjectG27.Controllers
{
    internal class credentialsDL
    {
        internal Models.credentialsBL credentialsBL
        {
            get => default;
            set
            {
            }
        }

        public static int AuthenticateUser(string username, string password)
        {
            try
            {
                string query = "SELECT role_id FROM credentials WHERE username = @username AND password_hash = @password";

                var parameter = new Dictionary<string, object>
        {
            { "@username", username },
            { "@password",password } 
        };

                object result = databasehelper.GetSingleInt(query, parameter);

                if (result != null && int.TryParse(result.ToString(), out int roleId))
                {
                    return roleId;
                }
                else
                {
                    return -1; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public static string GetRole(int id)
        {
            try
            {
                string query = "SELECT value FROM lookup WHERE lookup_id = @id";
                var parameter = new Dictionary<string, object>
        {
            { "@id", id }
        };

                object result = databasehelper.GetSingleValue(query, parameter);

                if (result != null)
                {
                    return result.ToString();
                }
                else
                {
                    MessageBox.Show("Not Such Registration Found");
                    return "Unknown"; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving role: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }
    }
}

