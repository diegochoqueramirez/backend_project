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
    public class CategoryRepository : ICategoryRepository
    {
        private DbContext dbcontext;
        IQueryBuilder queryBuilder = new CategoryQueryBuilder();
        IEntityCreator<Category> creator = new CategoryCreator();
        public string ConnectionString { get; set; }

        public CategoryRepository(DbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = new List<Category>();

            using (var context = dbcontext.CreateConnection())
            {
                context.Open();
                var command = new SqlCommand("SELECT * FROM CATEGORY", context);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category = new Category
                        {
                            CategoryId = (int)reader["CATEGORY_ID"],
                            Name = (string)reader["NAME"],
                        };
                        categories.Add(category);
                    }
                }

            }
            return categories;
        }

        public Category Add(Category category)
        {
            category.CategoryId = 1;
            creator.Entity = category;
            dbcontext.ExecuteNonQuery<Category>(queryBuilder.InsertQuery, creator);

            return category;
        }

        public Category Update(Category category)
        {
            creator.Entity = category;

            dbcontext.ExecuteNonQuery<Category>(queryBuilder.UpdateOneQuery(category), creator);

            return category;
        }

        public bool Remove(Guid id)
        {
            //int result = 0;

            //creator.Entity = new Category { CategoryId = id };

            //result = dbcontext.ExecuteNonQuery(queryBuilder.DeleteOneQuery, creator);

            //return result > 0;

            return true;
        }

        public IEnumerable<Category> FilterBy(Category category)
        {
            creator.Entity = category;
            var sql = $"{queryBuilder.GetAllQuery} {queryBuilder.GetFilteredQuery(category)}";

            return dbcontext.GetRecords<Category>(sql, creator);
        }
    }
}
