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
    class TaskCreator : IEntityCreator<TodoTask>
    {
        public TodoTask Entity { get; set; }

        public TodoTask CreateEntity(SqlDataReader dr)
        {
            return new TodoTask
            {
                TaskId = dr.GetFieldValue<Guid>(TaskQueryBuilder.TaskId),
                CategoryId = dr.GetFieldValue<Guid>(TaskQueryBuilder.CategoryId),
                UserId = dr.GetFieldValue<Guid>(TaskQueryBuilder.UserId),
                Title = dr.GetFieldValue<string>(TaskQueryBuilder.Title),
                Description = dr.GetFieldValue<string>(TaskQueryBuilder.Description),
                Status = (Core.Models.TaskStatus)dr.GetFieldValue<int>(TaskQueryBuilder.Status)
            };
        }

        public void FillParameters(SqlCommand cmd)
        {
            if (Entity == null)
            {
                return;
            }

            if (Entity.Title != null)
            {
                cmd.Parameters.Add(new SqlParameter($"@{TaskQueryBuilder.Title}", Entity.Title));
            }

            if (Entity.Description != null)
            {
                cmd.Parameters.Add(new SqlParameter($"@{TaskQueryBuilder.Description}", Entity.Description));
            }

            if (Entity.Status != Core.Models.TaskStatus.None)
            {
                cmd.Parameters.Add(new SqlParameter($"@{TaskQueryBuilder.Status}", Entity.Status));
            }

            if (Entity.CategoryId != Guid.Empty)
            {
                cmd.Parameters.Add(new SqlParameter($"@{TaskQueryBuilder.CategoryId}", Entity.CategoryId));
            }

            if (Entity.UserId != Guid.Empty)
            {
                cmd.Parameters.Add(new SqlParameter($"@{TaskQueryBuilder.UserId}", Entity.UserId));
            }

            if (Entity.TaskId != Guid.Empty)
            {
                cmd.Parameters.Add(new SqlParameter($"@{TaskQueryBuilder.TaskId}", Entity.TaskId));
            }
        }
    }
}
