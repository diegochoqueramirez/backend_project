using online_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryBuilders
{
    class ProjectQueryBuilder : SingleQueryBuilder
    {
        public const string ProjectId = "ProjectId";
        public const string Name = "Name";

        protected override string Table => "Projects";

        protected override string Id => ProjectId;

        public override string[] Columns { get; } = { ProjectId, Name };


        protected override List<string> MakeSetUpdate(object entity)
        {
            Filters = new List<string>();
            var project = entity as Project;
            var sets = new List<string>();
            if (project != null)
            {
                if (project.Name != null)
                {
                    sets.Add(Name);
                    Filters.Add(Name);
                }

                if (project.ProjectId != Guid.Empty)
                {
                    Filters.Add(ProjectId);
                }
            }

            return sets;
        }
    }
}
