using online_store.Data.Common.EntityCreators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryExecutors
{
    class ReaderExecutor<T> : IQueryExecutable<List<T>>
    {
        public IEntityCreator<T> Creator { get; init; }

        public List<T> Execute(SqlCommand cmd)
        {
            var results = new List<T>();
            Creator.FillParameters(cmd);
            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    results.Add(Creator.CreateEntity(dr));
                }
            }

            return results;
        }
    }
}
