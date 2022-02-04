using online_store.Core.Models;
using online_store.Data.Common.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.EntityCreators
{
    class ProjectCreator : IEntityCreator<Project>
    {
        public Project Entity { get; set; }

        public Project CreateEntity(SqlDataReader dr)
        {
            throw new NotImplementedException();
        }

        //public Project CreateEntity(SqlDataReader dr)
        //{
        //    return new Project
        //    {
        //        ProjectId = dr.GetFieldValue<Guid>(ProjectQueryBuilder.ProjectId),
        //        Name = dr.GetFieldValue<string>(ProjectQueryBuilder.Name),
        //    };
        //}

        public void FillParameters(SqlCommand cmd)
        {
            if (Entity == null)
            {
                return;
            }

            if (Entity.Name != null)
            {
                cmd.Parameters.Add(new SqlParameter($"@{ProjectQueryBuilder.Name}", Entity.Name));
            }

            if (Entity.ProjectId != Guid.Empty)
            {
                cmd.Parameters.Add(new SqlParameter($"@{ProjectQueryBuilder.ProjectId}", Entity.ProjectId));
            }
        }
    }
}
