using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace HospitalManagementSystem.Util
{
    public class PropertyUtil
    {
        public static string GetPropertyString(string propertyName)
        {
            try
            {
                // Create the configuration builder to read from appsettings.json
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // Ensure the current directory is set
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Read the JSON file

                IConfiguration configuration = builder.Build();

                // Retrieve the connection string based on the property name
                string? connectionString = configuration.GetConnectionString(propertyName);

                // If the connection string is not found, throw an exception with details
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception($"Connection string '{propertyName}' not found in appsettings.json.");
                }

                return connectionString; // Return the connection string if found
            }
            catch (FileNotFoundException fileEx)
            {
                // Specifically handle the file not found scenario
                throw new Exception("appsettings.json not found in the directory.", fileEx);
            }
            catch (DirectoryNotFoundException dirEx)
            {
                // Handle directory not found
                throw new Exception("Directory not found for the configuration file.", dirEx);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                throw new Exception($"Error reading the property: {propertyName}.", ex);
            }
        }
    }
}
