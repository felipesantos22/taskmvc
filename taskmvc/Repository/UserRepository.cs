using System.Data;
using taskmvc.Interfaces;
using taskmvc.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace taskmvc.Repository
{
    public class UserRepository : IUser
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Connection string não encontrada.");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }


        public async Task<User> Create(User user)
        {
            var sql = "INSERT INTO Users (Name, Password) VALUES (@Name, @Password)";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, user);
            return user;

        }

        public IEnumerable<User> GetAll()
        {
            var sql = "SELECT * FROM Users";
            using var connection = CreateConnection();
            return connection.Query<User>(sql);
      
        }

        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Users WHERE Id = @Id";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
