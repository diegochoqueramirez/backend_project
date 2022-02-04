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
    public class UserRepository : IUserRepository
    {
        private DbContext dataManagerBase;
        IQueryBuilder queryBuilder = new UserQueryBuilder();
        IEntityCreator<User> creator = new UserCreator();

        public UserRepository(DbContext dataManagerBase)
        {
            this.dataManagerBase = dataManagerBase;
        }

        public string ConnectionString { get; set; }
        public IEnumerable<User> GetAll()
        {
            creator.Entity = null;

            return dataManagerBase.GetRecords<User>(queryBuilder.GetAllQuery);
        }

        public User Add(User user)
        {
            user.UserId = Guid.NewGuid();
            creator.Entity = user;

            dataManagerBase.ExecuteNonQuery(queryBuilder.InsertQuery, creator);

            return user;
        }

        public User Update(User user)
        {
            creator.Entity = user;

            dataManagerBase.ExecuteNonQuery(queryBuilder.UpdateOneQuery(user), creator);

            return user;
        }

        public bool Remove(Guid id)
        {
            int result = 0;

            creator.Entity = new User { UserId = id };

            result = dataManagerBase.ExecuteNonQuery(queryBuilder.DeleteOneQuery, creator);

            return result > 0;
        }

        public IEnumerable<User> FilterBy(User user)
        {
            creator.Entity = user;
            var sql = $"{queryBuilder.GetAllQuery} {queryBuilder.GetFilteredQuery(user)}";

            return dataManagerBase.GetRecords(sql, creator);
        }
    }
}
