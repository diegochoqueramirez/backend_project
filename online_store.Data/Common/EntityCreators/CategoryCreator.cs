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
    class CategoryCreator : IEntityCreator<Category>
    {
        public Category Entity { get; set; }

        public Category CreateEntity(SqlDataReader dr)
        {
            return new Category
            {
                //CategoryId = dr.GetFieldValue<Guid>(CategoryQueryBuilder.CategoryId),
                Name = dr.GetFieldValue<string>(CategoryQueryBuilder.Name),
                //Description = dr.GetFieldValue<string>(CategoryQueryBuilder.Description),
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
                cmd.Parameters.Add(new SqlParameter($"@{CategoryQueryBuilder.Name}", Entity.Name));
            }

            //if (Entity.Description != null)
            //{
            //    cmd.Parameters.Add(new SqlParameter($"@{CategoryQueryBuilder.Description}", Entity.Description));
            //}

            //if (Entity.CategoryId != Guid.Empty)
            //{
            //    cmd.Parameters.Add(new SqlParameter($"@{CategoryQueryBuilder.CategoryId}", Entity.CategoryId));
            //}
        }
    }
}
