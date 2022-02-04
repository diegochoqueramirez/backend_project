using online_store.Core.Interfaces;
using online_store.Core.Models;
using online_store.Data.Common;
using online_store.Data.Common.EntityCreators;
using online_store.Data.Common.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace online_store.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private DbContext dataManagerBase;
        IQueryBuilder queryBuilder = new TaskQueryBuilder();
        IEntityCreator<TodoTask> creator = new TaskCreator();

        public TaskRepository(DbContext dataManagerBase)
        {
            this.dataManagerBase = dataManagerBase;
        }

        public string ConnectionString { get; set; }
        public IEnumerable<TodoTask> GetAll()
        {
            creator.Entity = null;

            return dataManagerBase.GetRecords<TodoTask>(queryBuilder.GetAllQuery);
        }

        public TodoTask Add(TodoTask task)
        {
            task.TaskId = Guid.NewGuid();
            creator.Entity = task;

            dataManagerBase.ExecuteNonQuery(queryBuilder.InsertQuery, creator);

            return task;
        }

        public TodoTask Update(TodoTask task)
        {
            creator.Entity = task;

            dataManagerBase.ExecuteNonQuery(queryBuilder.UpdateOneQuery(task), creator);

            return task;
        }

        public bool Remove(Guid id)
        {
            int result = 0;

            creator.Entity = new TodoTask { TaskId = id };

            result = dataManagerBase.ExecuteNonQuery(queryBuilder.DeleteOneQuery, creator);

            return result > 0;
        }

        public IEnumerable<TodoTask> FilterBy(TodoTask task)
        {
            creator.Entity = task;
            var sql = $"{queryBuilder.GetAllQuery} {queryBuilder.GetFilteredQuery(task)}";

            return dataManagerBase.GetRecords(sql, creator);
        }
    }
}
