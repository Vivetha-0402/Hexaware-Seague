using System;
using Microsoft.Data.SqlClient;

namespace HospitalManagementSystem.Util
{
    // Class responsible for establishing and managing the database connection
    public class DBConnection
    {
        // Static variable that holds the database connection object (nullable)
        public static SqlConnection? connection;

        // Static method to get the database connection
        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = PropertyUtil.GetPropertyString("DefaultConnection");
                connection = new SqlConnection(connectionString);
                connection.Open();
            }

            return connection;
        }
    }
}
