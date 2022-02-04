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

namespace online_store.Data.Repositories
{
    public class CostumerRepository : ICostumerRepository
    {
        private readonly DbContext dbContext;

        public CostumerRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Costumer Add(Costumer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Costumer> FilterBy(Costumer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Costumer> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CostumerDTO> GetBestCoatumers()
        {
            var costumers = new List<CostumerDTO>();

            using (var context = dbContext.CreateConnection())
            {
                context.Open();
                var command = new SqlCommand("SELECT TOP 10 C.COSTUMER_ID, C.NAME, t.TOTAL_PRICE FROM backend_project.dbo.[ORDER] t INNER JOIN COSTUMER C on C.COSTUMER_ID = t.COSTUMER_ID ORDER BY t.TOTAL_PRICE DESC", context);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var costumer = new CostumerDTO
                        {
                            CostumerId = (int)reader["COSTUMER_ID"],
                            Name = (string)reader["NAME"],
                            TotalPrice = (double)reader["TOTAL_PRICE"],
                        };
                        costumers.Add(costumer);
                    }
                }
            }
            return costumers;
        }

        public List<SearchCostumerDTO> GetCostumersByProduct(string product)
        {
            var costumers = new List<SearchCostumerDTO>();

            using (var context = dbContext.CreateConnection())
            {
                context.Open();
                var command = new SqlCommand("SELECT C.COSTUMER_ID, C.NAME, P.NAME PRODUCT, I.QUANTITY, O.TOTAL_PRICE FROM backend_project.dbo.PRODUCT P INNER JOIN ITEM I on P.PRODUCT_ID = I.PRODUCT_ID INNER JOIN[ORDER] O on O.ORDER_ID = I.ORDER_ID INNER JOIN COSTUMER C on C.COSTUMER_ID = O.COSTUMER_ID WHERE P.NAME LIKE @query", context);

                command.Parameters.AddWithValue("@query", $"%{product}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var costumer = new SearchCostumerDTO
                        {
                            Id = (int)reader["COSTUMER_ID"],
                            Name = (string)reader["NAME"],
                            ProductName = (string)reader["PRODUCT"],
                            Quantity= (int)reader["QUANTITY"],
                            TotalPrice = (double)reader["TOTAL_PRICE"]
                        };
                        costumers.Add(costumer);
                    }
                }

            }
            return costumers;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Costumer Update(Costumer entity)
        {
            throw new NotImplementedException();
        }
    }
}
