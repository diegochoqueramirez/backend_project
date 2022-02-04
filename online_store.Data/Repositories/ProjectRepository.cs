using online_store.Core.Interfaces;
using online_store.Core.Models;
using online_store.Data.Common;
using online_store.Data.Common.EntityCreators;
using online_store.Data.Common.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private DbContext dataManagerBase;
        IQueryBuilder queryBuilder = new ProjectQueryBuilder();
        IEntityCreator<Project> creator = new ProjectCreator();

        public ProjectRepository(DbContext dataManagerBase)
        {
            this.dataManagerBase = dataManagerBase;
        }

        public string ConnectionString { get; set; }
        public IEnumerable<Project> GetAll()
        {
            creator.Entity = null;

            return dataManagerBase.GetRecords<Project>(queryBuilder.GetAllQuery);
        }

        public Project Add(Project project)
        {
            var createdProject = new Project { ProjectId = Guid.NewGuid(), Name = project.Name };
            creator.Entity = createdProject;

            dataManagerBase.ExecuteNonQuery<Project>(queryBuilder.InsertQuery, creator);

            return createdProject;
        }

        public Project Update(Project project)
        {
            creator.Entity = project;

            dataManagerBase.ExecuteNonQuery<Project>(queryBuilder.UpdateOneQuery(project), creator);

            return project;
        }

        public bool Remove(Guid id)
        {
            int result = 0;

            creator.Entity = new Project { ProjectId = id };

            result = dataManagerBase.ExecuteNonQuery(queryBuilder.DeleteOneQuery, creator);
            
            return result > 0;
        }

        public IEnumerable<Project> FilterBy(Project project)
        {
            creator.Entity = project;
            //var sql = queryBuilder.GetOneQuery;
            var sql = $"{queryBuilder.GetAllQuery} {queryBuilder.GetFilteredQuery(project)}";

            return dataManagerBase.GetRecords<Project>(sql, creator);
        }
    }
}
