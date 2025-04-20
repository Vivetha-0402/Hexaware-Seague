using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SIS.Util
{
    // Utility class to handle database connection string retrieval
    public static class DBPropertyUtil
    {
        // Method to get the connection string from the specified config file
        public static string GetConnectionString(string configFileName)
        {
            // Build the configuration using the configuration file provided
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // Set the base path to the current directory
                .AddJsonFile(configFileName)  // Load the specified JSON config file
                .Build();

            // Retrieve the connection string named "DefaultConnection" from the config
            // If the connection string is not found, throw an exception
            return configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string not found.");
        }
    }
}
