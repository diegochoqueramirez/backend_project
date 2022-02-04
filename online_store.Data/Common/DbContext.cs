using online_store.Data.Common.EntityCreators;
using online_store.Data.Common.QueryExecutors;
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

        protected T RunQuery<T>(string sql, IQueryExecutable<T> executor)
        {
            T result;
            using (var cnn = CreateConnection())
            {
                using (var cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    result = executor.Execute(cmd);
                }
            }

            return result;
        }

        public List<T> GetRecords<T>(string sql)
        {
            var executor = new ReaderExecutor<T>
            { Creator = CreatorFactory.Create<T>() };

            return RunQuery<List<T>>(sql, executor);
        }

        public List<T> GetAll<T>(string sql)
        {
            var executor = new ReaderExecutor<T>
            { Creator = CreatorFactory.Create<T>() };

            return RunQuery<List<T>>(sql, executor);

        }

        public List<T> GetRecords<T>(string sql, IEntityCreator<T> creator)
        {
            var executor = new ReaderExecutor<T> { Creator = creator };

            return RunQuery<List<T>>(sql, executor);
        }

        public int ExecuteNonQuery<T>(string sql, IEntityCreator<T> creator)
        {
            var executor = new NonQueryExecutor<T> { Creator = creator };

            return RunQuery(sql, executor);
        }
    }
}
