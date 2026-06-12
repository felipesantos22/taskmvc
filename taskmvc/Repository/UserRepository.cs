using System.Data;
using taskmvc.Interfaces;
using taskmvc.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace taskmvc.Repository
{
    public class UserRepository : IUserRepository
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


        public async Task Create(User user)
        {
            var sql = "INSERT INTO Users (Name, Password) VALUES (@Name, @Password)";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var sql = "SELECT * FROM Users";
            using var connection = CreateConnection();
            return await connection.QueryAsync<User>(sql);

        }

        public async Task<User?> GetById(int id)
        {
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, new { Id = id });
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task Update(User user)
        {
            var sql = "UPDATE Users SET Name = @Name, Password = @Password WHERE Id = @Id";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, user);
        }

        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Users WHERE Id = @Id";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task DeleteAll()
        {
            var sql = "DELETE FROM Users";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql);
        }

        public async Task UpdateName(int id, string name)
        {
            var sql = "UPDATE Users SET Name = @Name WHERE Id = @Id";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(sql, new { id, name });
        }
    }
}
