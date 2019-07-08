using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PortfolioDBConnection
    {
        
            public static SqlConnection CreateSQLConnection()
            {
                SqlConnection sqlConnection = new SqlConnection();
                string path = ConfigurationManager.ConnectionStrings["NewConnectionString"].ConnectionString;

                sqlConnection.ConnectionString = path;
                return sqlConnection;
            }
        
    }
}
