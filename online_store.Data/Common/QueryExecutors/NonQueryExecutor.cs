using online_store.Data.Common.EntityCreators;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryExecutors
{
    class NonQueryExecutor<T> : IQueryExecutable<int>
    {
        public IEntityCreator<T> Creator { get; init; }
        public int Execute(SqlCommand cmd)
        {
            int result = 0;

            Creator.FillParameters(cmd);
            result = cmd.ExecuteNonQuery();
            
            return result;
        }
    }
}
