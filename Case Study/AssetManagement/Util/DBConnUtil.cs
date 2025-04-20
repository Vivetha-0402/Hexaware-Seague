using Microsoft.Data.SqlClient;


namespace Asset_Management.Util
{
    public class DBConnection
    {
        private static SqlConnection? connection;

        private DBConnection() { }

        public static SqlConnection GetConnection()
        {
            if (connection == null || connection.State == System.Data.ConnectionState.Closed)
            {
                string connStr = PropertyUtil.GetConnectionString();
                connection = new SqlConnection(connStr);
            }
            return connection;
        }
    }
}

