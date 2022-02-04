using online_store.Core.Interfaces;
using online_store.Core.Models;
using online_store.Data.Common;
using online_store.Data.Common.EntityCreators;
using online_store.Data.Common.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private DbContext dataManagerBase;
        IQueryBuilder queryBuilder = new TagQueryBuilder();
        IEntityCreator<Tag> creator = new TagCreator();

        public TagRepository(DbContext dataManagerBase)
        {
            this.dataManagerBase = dataManagerBase;
        }

        public string ConnectionString { get; set; }
        public IEnumerable<Tag> GetAll()
        {
            creator.Entity = null;

            return dataManagerBase.GetRecords<Tag>(queryBuilder.GetAllQuery);
        }

        public Tag Add(Tag tag)
        {
            creator.Entity = tag;

            dataManagerBase.ExecuteNonQuery(queryBuilder.InsertQuery, creator);

            return tag;
        }

        public Tag Update(Tag tag)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string id)
        {
            int result = 0;

            creator.Entity = new Tag { TagId = id };

            result = dataManagerBase.ExecuteNonQuery(queryBuilder.DeleteOneQuery, creator);

            return result > 0;
        }

        public IEnumerable<Tag> FilterBy(Tag tag)
        {
            creator.Entity = tag;
            var sql = $"{queryBuilder.GetAllQuery} {queryBuilder.GetFilteredQuery(tag)}";

            return dataManagerBase.GetRecords(sql, creator);
        }
    }
}
