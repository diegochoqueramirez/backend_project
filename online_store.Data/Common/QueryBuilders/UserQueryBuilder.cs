using online_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryBuilders
{
    class UserQueryBuilder : SingleQueryBuilder
    {
        public const string UserId = "UserId";
        public const string Name = "Name";
        public const string ProjectId = "ProjectId";

        protected override string Table => "Users";

        protected override string Id => UserId;

        public override string[] Columns { get; } = { UserId, Name, ProjectId };


        protected override List<string> MakeSetUpdate(object entity)
        {
            Filters = new List<string>();
            var user = entity as User;
            var sets = new List<string>();
            if (user != null)
            {
                if (user.Name != null)
                {
                    sets.Add(Name);
                    Filters.Add(Name);
                }

                if (user.UserId != Guid.Empty)
                {
                    //sets.Add(UserId);
                    Filters.Add(UserId);
                }

                if (user.ProjectId != Guid.Empty)
                {
                    sets.Add(ProjectId);
                    Filters.Add(ProjectId);
                }
            }

            return sets;
        }
    }
}
