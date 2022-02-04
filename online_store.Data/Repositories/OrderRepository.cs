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
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext dbContext;

        public OrderRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Order Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> FilterBy(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = new List<Order>();

            using (var context = dbContext.CreateConnection())
            {
                context.Open();
                var command = new SqlCommand("SELECT t.* FROM backend_project.dbo.[ORDER] t", context);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Order
                        {
                            OrderId = (int)reader["ORDER_ID"],
                            CostumerId = (int)reader["COSTUMER_ID"],
                            TotalPrice = (double)reader["TOTAL_PRICE"],
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
