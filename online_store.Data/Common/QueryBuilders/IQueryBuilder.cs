using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.QueryBuilders
{
    interface IQueryBuilder
    {
        string[] Columns { get; }

        List<string> Filters { get; set; }

        string GetAllQuery { get; }

        string GetOneQuery { get; }

        string InsertQuery { get; }

        string UpdateOneQuery(object entity);

        string GetFilteredQuery(object entity);

        string DeleteOneQuery { get; }
    }
}
