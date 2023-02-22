using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_SqlClient.Repositories
{
    public class ConnectionStringHelper
    {
        /// <summary>
        /// Returns a connection string for the Chinook database on a local SQL Server instance. The connection string specifies the local host name, the database name, and uses integrated security for authentication.
        /// </summary>
        /// <returns>The connection string for the Chinook database on a local SQL Server instance.</returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            // !important! Change the string Datasource to your own local host name
            connectionStringBuilder.DataSource = "N-DK-01-01-3908\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate= true;
            return connectionStringBuilder.ConnectionString;
        }
    }
}
