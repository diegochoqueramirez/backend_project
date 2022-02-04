using online_store.Core.Models;
using online_store.Data.Common.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.EntityCreators
{
    class TagCreator : IEntityCreator<Tag>
    {
        public Tag Entity { get; set; }

        public Tag CreateEntity(SqlDataReader dr)
        {
            return new Tag
            {
                TagId = dr.GetFieldValue<string>(TagQueryBuilder.TagId),
            };
        }

        public void FillParameters(SqlCommand cmd)
        {
            if (Entity == null)
            {
                return;
            }

            if (Entity.TagId != null)
            {
                cmd.Parameters.Add(new SqlParameter($"@{TagQueryBuilder.TagId}", Entity.TagId));
            }
        }
    }
}
