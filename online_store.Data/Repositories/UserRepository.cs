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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext dbContext;

        public UserRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FilterBy(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var user = new User();

            using (var context = dbContext.CreateConnection())
            {
                context.Open();
                var command = new SqlCommand("SELECT * FROM [USER] WHERE USERNAME = @username AND PASSWORD = @password", context);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();

                    user.Id = (int)reader["ID"];
                    user.Username = (string)reader["USERNAME"];
                    user.Password = (string)reader["PASSWORD"];

                }
            }

            return user;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
