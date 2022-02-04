using online_store.Core.Interfaces;
using online_store.Core.Models;
using online_store.Data.Common;
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

        public IEnumerable<Category> FilterBy(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
