using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FinalProjectG27.Database;
using MySql.Data.MySqlClient;

namespace FinalProjectG27
{
    internal class warehousesDL
    {
        public static bool AddWarehouse(warehousesBL warehouse)
        {
            try
            {
                string checkLocationQuery = @"SELECT location_id FROM locations 
                                       WHERE address = @address AND city = @city AND postal_code = @postal_code";

                var locationParams = new Dictionary<string, object>
                {
                    { "@address", warehouse.address },
                    { "@city", warehouse.city },
                    { "@postal_code", warehouse.postalcode }
                };

                int locationId = databasehelper.GetSingleInt(checkLocationQuery, locationParams);

                if (locationId == 0)
                {
                    string insertLocationQuery = @"INSERT INTO locations(address, city, postal_code) 
                                           VALUES(@address, @city, @postal_code)";
                    databasehelper.ExecuteDML(insertLocationQuery, locationParams);

                    locationId = databasehelper.GetSingleInt("SELECT LAST_INSERT_ID()");
                    if (locationId == 0)
                        throw new Exception("Failed to retrieve location_id after insertion.");
                }
                string checkWarehouseQuery = @"SELECT COUNT(*) FROM warehouses 
                                       WHERE warehouse_name = @name AND location_id = @location_id";

                var checkWarehouseParams = new Dictionary<string, object>
                {
                    { "@name", warehouse.name },
                    { "@location_id", locationId }
                };

                int existingCount = databasehelper.GetSingleInt(checkWarehouseQuery, checkWarehouseParams);

                if (existingCount > 0)
                {
                    throw new Exception("A warehouse with this name already exists at this location.");
                }

                string insertWarehouseQuery = @"INSERT INTO warehouses(warehouse_name, location_id) 
                                        VALUES(@name, @location_id)";

                var warehouseParams = new Dictionary<string, object>
                {
                    { "@name", warehouse.name },
                    { "@location_id", locationId }
                };

                databasehelper.ExecuteDML(insertWarehouseQuery, warehouseParams);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding warehouse: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable GetWarehouses()
        {
            string query = @"SELECT w.warehouse_id, w.warehouse_name, 
                                   l.address, l.city, l.postal_code, l.location_id
                            FROM warehouses w
                            JOIN locations l ON w.location_id = l.location_id
                            ORDER BY w.warehouse_name";

            return databasehelper.GetDataTable(query);
        }

        public static bool UpdateWarehouses(warehousesBL warehouse, int warehouseId)
        {
            try
            {
                string getLocationQuery = @"SELECT location_id FROM warehouses 
                                     WHERE warehouse_id = @warehouse_id";

                var getLocationParams = new Dictionary<string, object>
                {
                    { "@warehouse_id", warehouseId }
                };

                int currentLocationId = databasehelper.GetSingleInt(getLocationQuery, getLocationParams);

                string checkLocationQuery = @"SELECT location_id FROM locations 
                                       WHERE address = @address AND city = @city AND postal_code = @postal_code";

                var locationParams = new Dictionary<string, object>
                {
                    { "@address", warehouse.address },
                    { "@city", warehouse.city },
                    { "@postal_code", warehouse.postalcode }
                };

                int newLocationId = databasehelper.GetSingleInt(checkLocationQuery, locationParams);

                if (newLocationId == 0)
                {
                    string insertLocationQuery = @"INSERT INTO locations(address, city, postal_code) 
                                           VALUES(@address, @city, @postal_code)";
                    databasehelper.ExecuteDML(insertLocationQuery, locationParams);

                    newLocationId = databasehelper.GetSingleInt("SELECT LAST_INSERT_ID()");
                    if (newLocationId == 0)
                        throw new Exception("Failed to retrieve location_id after insertion.");
                }

                string updateWarehouseQuery = @"UPDATE warehouses 
                                          SET warehouse_name = @name, 
                                              location_id = @location_id
                                          WHERE warehouse_id = @warehouse_id";

                var warehouseParams = new Dictionary<string, object>
                {
                    { "@name", warehouse.name },
                    { "@location_id", newLocationId },
                    { "@warehouse_id", warehouseId }
                };

                databasehelper.ExecuteDML(updateWarehouseQuery, warehouseParams);

                string checkOldLocationUsage = @"SELECT COUNT(*) FROM warehouses 
                                          WHERE location_id = @location_id";

                var usageParams = new Dictionary<string, object>
                {
                    { "@location_id", currentLocationId }
                };

                int locationUsageCount = databasehelper.GetSingleInt(checkOldLocationUsage, usageParams);

                if (locationUsageCount == 0)
                {
                    string deleteLocationQuery = @"DELETE FROM locations 
                                             WHERE location_id = @location_id";

                    databasehelper.ExecuteDML(deleteLocationQuery, usageParams);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating warehouse: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeleteWarehouse(int warehouseId)
        {
            try
            {
                string getLocationQuery = @"SELECT location_id FROM warehouses 
                                     WHERE warehouse_id = @warehouse_id";

                var getLocationParams = new Dictionary<string, object>
                {
                    { "@warehouse_id", warehouseId }
                };

                int locationId = databasehelper.GetSingleInt(getLocationQuery, getLocationParams);

                string deleteWarehouseQuery = @"DELETE FROM warehouses 
                                         WHERE warehouse_id = @warehouse_id";

                databasehelper.ExecuteDML(deleteWarehouseQuery, getLocationParams);

                string checkLocationUsage = @"SELECT COUNT(*) FROM warehouses 
                                       WHERE location_id = @location_id";

                var usageParams = new Dictionary<string, object>
                {
                    { "@location_id", locationId }
                };

                int locationUsageCount = databasehelper.GetSingleInt(checkLocationUsage, usageParams);

                if (locationUsageCount == 0)
                {
                    string deleteLocationQuery = @"DELETE FROM locations 
                                             WHERE location_id = @location_id";

                    databasehelper.ExecuteDML(deleteLocationQuery, usageParams);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting warehouse: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}