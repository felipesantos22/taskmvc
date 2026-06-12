namespace taskmvc.Repository;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using taskmvc.Models;
using taskmvc.Interfaces;

public class TaskRepository : ITaskRepository
{
    private readonly string _connectionString;

    public TaskRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new Exception("Connection string não encontrada.");
    }

    private IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public IEnumerable<TaskItem> GetAll()
    {
        using var connection = CreateConnection();

        return connection.Query<TaskItem>(
            "sp_GetTasks",
            commandType: CommandType.StoredProcedure
        );
    }

    public TaskItem? GetById(int id)
    {
        using var connection = CreateConnection();

        return connection.QueryFirstOrDefault<TaskItem>(
            "sp_GetTaskById",
            new { Id = id },
            commandType: CommandType.StoredProcedure
        );
    }

    public void Create(TaskItem task)
    {
        using var connection = CreateConnection();

        connection.Execute(
            "sp_CreateTask",
            new
            {
                task.Name,
                task.IsDone
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public void Update(TaskItem task)
    {
        using var connection = CreateConnection();

        connection.Execute(
            "sp_UpdateTask",
            new
            {
                task.Id,
                task.Name,
                task.IsDone
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public void Delete(int id)
    {
        using var connection = CreateConnection();

        connection.Execute(
            "sp_DeleteTask",
            new { Id = id },
            commandType: CommandType.StoredProcedure
        );
    }
}