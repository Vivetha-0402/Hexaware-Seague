using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace StudentInformationSystem.Util
{
    // Utility class to handle SQL connection creation
    public static class DBConnUtil
    {
        // Method to create and return a new SQL connection using the provided connection string
        public static SqlConnection GetConnection(string connectionString)
        {
            // Create a new SQL connection using the provided connection string
            var connection = new SqlConnection(connectionString);

            // Open the SQL connection to interact with the database
            connection.Open();

            // Return the open SQL connection
            return connection;
        }


    }
}
