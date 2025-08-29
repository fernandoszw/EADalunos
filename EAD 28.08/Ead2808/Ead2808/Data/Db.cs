using System.Data; 
using Microsoft.Data.SqlClient;


namespace Ead2808.Data
{
    public class Db
    {
        public static string ConnectionString { get; set; }

        public static IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}