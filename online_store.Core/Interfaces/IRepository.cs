using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Core.Interfaces
{
    public interface IRepository<TEntity, TEntityId>
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FilterBy(TEntity entity);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        bool Remove(TEntityId id);
    }
}
