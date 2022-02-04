using online_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryBuilders
{
    class TagQueryBuilder : SingleQueryBuilder
    {
        public const string TagId = "TagId";

        protected override string Table => "Tags";

        protected override string Id => TagId;

        public override string[] Columns { get; } = { TagId };


        protected override List<string> MakeSetUpdate(object entity)
        {
            Filters = new List<string>();
            var tag = entity as Tag;
            var sets = new List<string>();
            if (tag != null)
            {
                if (tag.TagId != null)
                {
                    //sets.Add(TagId);
                    Filters.Add(TagId);
                }
            }

            return sets;
        }
    }
}
