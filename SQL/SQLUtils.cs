using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class SQLUtils
    {
        private static readonly string connect = ConfigurationManager.ConnectionStrings["NewConnectionString"].ToString();

    }
}
