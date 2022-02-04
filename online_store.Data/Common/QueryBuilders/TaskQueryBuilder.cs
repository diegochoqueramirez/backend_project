using online_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryBuilders
{
    class TaskQueryBuilder : SingleQueryBuilder
    {
        public const string TaskId = "TaskId";
        public const string Title = "Title";
        public const string Description = "Description";
        public const string Status = "Status";
        public const string CategoryId = "CategoryId";
        public const string UserId = "UserId";

        protected override string Table => "Tasks";

        protected override string Id => TaskId;

        public override string[] Columns { get; } = { TaskId, Title, Description, Status, CategoryId, UserId };


        protected override List<string> MakeSetUpdate(object entity)
        {
            Filters = new List<string>();
            var task = entity as TodoTask;
            var sets = new List<string>();
            if (task != null)
            {
                if (task.Title != null)
                {
                    sets.Add(Title);
                    Filters.Add(Title);
                }

                if (task.Description != null)
                {
                    sets.Add(Description);
                    Filters.Add(Description);
                }

                if (task.Status > 0)
                {
                    sets.Add(Status);
                    Filters.Add(Status);
                }

                if (task.TaskId != Guid.Empty)
                {
                    //sets.Add(TaskId);
                    Filters.Add(TaskId);
                }

                if (task.CategoryId != Guid.Empty)
                {
                    sets.Add(CategoryId);
                    Filters.Add(CategoryId);
                }

                if (task.UserId != Guid.Empty)
                {
                    sets.Add(UserId);
                    Filters.Add(UserId);
                }
            }

            return sets;
        }
    }
}
