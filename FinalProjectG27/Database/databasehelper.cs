using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace FinalProjectG27.Database
{
    internal class databasehelper
    {
        public static string constring = "Server=localhost;Uid=root;Pwd=javairiaqasim123456789$$;Database=final";

        // ✅ Execute INSERT, UPDATE, DELETE using parameters
        public static void ExecuteDML(string query, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // ✅ Get DataTable with parameters (for SELECT queries)
        public static DataTable GetDataTable(string query, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // ✅ Get a single integer value (like ID) using parameters
        public static int GetSingleInt(string query, Dictionary<string, object> parameters = null)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    object value = cmd.ExecuteScalar();
                    if (value != null && int.TryParse(value.ToString(), out int id))
                    {
                        result = id;
                    }
                }
            }
            return result;
        }

        // ✅ Load ComboBox items using a specific column (parameterized)
        public static List<string> LoadComboBoxItems(string query, string columnName, Dictionary<string, object> parameters = null)
        {
            List<string> items = new List<string>();
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(reader[columnName].ToString());
                        }
                    }
                }
            }
            return items;
        }
        //for string 
        public static object GetSingleValue(string query, Dictionary<string, object> parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
