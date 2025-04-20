using Microsoft.Extensions.Configuration;
using System.IO;

namespace Asset_Management.Util
{
    public static class PropertyUtil
    {
        private static IConfigurationRoot configuration;

        static PropertyUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // or AppContext.BaseDirectory
                .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);
            configuration = builder.Build();
        }

        public static string GetConnectionString()
        {
            var connStr = configuration.GetConnectionString("DefaultConnection");
            if (connStr == null)
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found in AppSettings.json.");
            return connStr;
        }
    }
}
