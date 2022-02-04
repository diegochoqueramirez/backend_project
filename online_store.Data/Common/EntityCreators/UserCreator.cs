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
    class UserCreator : IEntityCreator<User>
    {
        public User Entity { get; set; }

        public User CreateEntity(SqlDataReader dr)
        {
            return new User
            {
                UserId = dr.GetFieldValue<Guid>(UserQueryBuilder.UserId),
                Name = dr.GetFieldValue<string>(UserQueryBuilder.Name),
                ProjectId = dr.GetFieldValue<Guid>(UserQueryBuilder.ProjectId),
            };
        }

        public void FillParameters(SqlCommand cmd)
        {
            if (Entity == null)
            {
                return;
            }

            if (Entity.Name != null)
            {
                cmd.Parameters.Add(new SqlParameter($"@{UserQueryBuilder.Name}", Entity.Name));
            }

            if (Entity.UserId != Guid.Empty)
            {
                cmd.Parameters.Add(new SqlParameter($"@{UserQueryBuilder.UserId}", Entity.UserId));
            }

            if (Entity.ProjectId != Guid.Empty)
            {
                cmd.Parameters.Add(new SqlParameter($"@{UserQueryBuilder.ProjectId}", Entity.ProjectId));
            }
        }
    }
}
