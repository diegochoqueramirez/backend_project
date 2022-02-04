using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryExecutors
{
    public interface IQueryExecutable<T>
    {
        T Execute(SqlCommand cmd);
    }
}
