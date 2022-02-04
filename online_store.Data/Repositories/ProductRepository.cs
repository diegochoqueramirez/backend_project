using online_store.Core.DTOs;
using online_store.Core.Interfaces;
using online_store.Core.Models;
using online_store.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace online_store.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DbContext dbcontext;

        public ProductRepository(DbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public ProductDTO Add(ProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            using (var transaction = new TransactionScope())
            {
                using (var context = dbcontext.CreateConnection())
                {
                    context.Open();
                    AddHeader(product, context);
                }
                transaction.Complete();
            }
        }

        private void AddHeader(Product product, SqlConnection sqlConnection)
        {
            var query = "INSERT INTO PRODUCT (PRODUCT_ID, CATEGORY_ID, NAME) VALUES (@ProductId, @CategoryId, @Name)";

            var command = new SqlCommand(query, sqlConnection);

            Random rnd = new Random();
            command.Parameters.AddWithValue("@ProductId", rnd.Next(1060, 99999));
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@Name", product.Name);

            command.ExecuteNonQuery();
        }

        public IEnumerable<ProductDTO> FilterBy(ProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = new List<ProductDTO>();

            using (var context = dbcontext.CreateConnection())
            {
                context.Open();
                var command = new SqlCommand("SELECT * FROM PRODUCT", context);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new ProductDTO
                        {
                            Id = (int)reader["PRODUCT_ID"],
                            Name = (string)reader["NAME"],
                        };
                        products.Add(product);
                    }
                }

            }
            return products;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDTO Update(ProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetBestProducts()
        {
            var products = new List<ProductDTO>();

            using (var context = dbcontext.CreateConnection())
            {
                context.Open();
                var command = new SqlCommand("SELECT TOP 10 P.PRODUCT_ID, P.NAME FROM backend_project.dbo.[ORDER] t INNER JOIN ITEM I on t.ORDER_ID = I.ORDER_ID INNER JOIN PRODUCT P on P.PRODUCT_ID = I.PRODUCT_ID ORDER BY t.TOTAL_PRICE DESC", context);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new ProductDTO
                        {
                            Id = (int)reader["PRODUCT_ID"],
                            Name = (string)reader["NAME"],
                        };
                        products.Add(product);
                    }
                }

            }
            return products;
        }

        public List<SearchProductDTO> GetProductsByName(string name)
        {
            var products = new List<SearchProductDTO>();

            using (var context = dbcontext.CreateConnection())
            {
                context.Open();
                var command = new SqlCommand("SELECT P.PRODUCT_ID, P.NAME, C.NAME Category FROM backend_project.dbo.PRODUCT P INNER JOIN CATEGORY C on C.CATEGORY_ID = P.CATEGORY_ID WHERE P.NAME LIKE @query", context);

                command.Parameters.AddWithValue("@query", $"%{name}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new SearchProductDTO
                        {
                            Id = (int)reader["PRODUCT_ID"],
                            Name = (string)reader["NAME"],
                            CategoryName = (string)reader["Category"],
                        };
                        products.Add(product);
                    }
                }

            }
            return products;
        }

        public List<SearchProductDTO> GetProductsByCategory(string category)
        {
            var products = new List<SearchProductDTO>();

            using (var context = dbcontext.CreateConnection())
            {
                context.Open();
                var command = new SqlCommand("SELECT PRODUCT_ID, P.NAME, C.NAME Category FROM CATEGORY C INNER JOIN PRODUCT P on C.CATEGORY_ID = P.CATEGORY_ID WHERE C.NAME LIKE @query", context);

                command.Parameters.AddWithValue("@query", $"%{category}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new SearchProductDTO
                        {
                            Id = (int)reader["PRODUCT_ID"],
                            Name = (string)reader["NAME"],
                            CategoryName = (string)reader["Category"],
                        };
                        products.Add(product);
                    }
                }

            }
            return products;
        }
    }
}
