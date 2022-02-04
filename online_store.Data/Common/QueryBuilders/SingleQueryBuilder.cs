using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryBuilders
{
    abstract class SingleQueryBuilder : IQueryBuilder
    {
        protected abstract string Table { get; }
        protected abstract string Id { get; }
        public abstract string[] Columns { get; }

        protected virtual string Cols => string.Join(",", Columns.Select(c => $"[{c}]").ToArray());

        public virtual string FilterOne => $"WHERE {Id} = @{Id}";

        public virtual string DeleteOneQuery => $"DELETE FROM [{Table}] {FilterOne}";

        public virtual string GetAllQuery => $"SELECT {Cols} FROM [{Table}]";

        public virtual string GetOneQuery => $"{GetAllQuery} {FilterOne}";

        public virtual string InsertQuery
        {
            get
            {
                var values = string.Join(",", Columns.Select(c => $"@{c}").ToArray());

                return $"INSERT INTO [{Table}] ({Cols}) VALUES ({values})";
            }
        }

        public List<string> Filters { get; set; }

        protected abstract List<string> MakeSetUpdate(object entity);

        public virtual string UpdateOneQuery(object entity)
        {
            var updates = "SET";
            var sets = MakeSetUpdate(entity);
            var strSets = string.Join(",", sets.Select(s => $"{s} = @{s}").ToArray());
            updates = $"{updates} {strSets}";

            return $"UPDATE [{Table}] {updates} {FilterOne}";
        }

        public virtual string GetFilteredQuery(object entity)
        {
            MakeSetUpdate(entity);

            if (Filters != null && Filters.Count > 0)
            {
                var filter = $"WHERE {Filters[0]} = @{Filters[0]}";
                var filters = string.Join(" AND ", Filters.Skip(1).Select(f => $"{f} = @{f}").ToArray());
                return $"{filter} {filters}";
            }

            return null;
        }
    }
}
