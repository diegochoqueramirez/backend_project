using online_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryBuilders
{
    class CategoryQueryBuilder : SingleQueryBuilder
    {
        public const string CategoryId = "CategoryId";
        public const string Name = "Name";
        public const string Description = "Description";

        protected override string Table => "Categories";

        protected override string Id => CategoryId;

        public override string[] Columns { get; } = { CategoryId, Name, Description };


        protected override List<string> MakeSetUpdate(object entity)
        {
            Filters = new List<string>();
            var category = entity as Category;
            var sets = new List<string>();
            if (category != null)
            {
                if (category.Name != null)
                {
                    sets.Add(Name);
                    Filters.Add(Name);
                }

                //if (category.Description != null)
                //{
                //    sets.Add(Description);
                //    Filters.Add(Description);
                //}

                //if (category.CategoryId != Guid)
                //{
                //}
                Filters.Add(CategoryId);
            }

            return sets;
        }
    }
}
