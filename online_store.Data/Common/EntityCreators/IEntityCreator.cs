using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.EntityCreators
{
    public interface IEntityCreator<T>
    {
        public T Entity { get; set; }
        T CreateEntity(SqlDataReader dr);
        void FillParameters(SqlCommand cmd);
    }
}
