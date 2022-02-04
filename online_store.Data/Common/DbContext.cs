using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common
{
    public class DbContext
    {
        private readonly string connectionString;

        public DbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
