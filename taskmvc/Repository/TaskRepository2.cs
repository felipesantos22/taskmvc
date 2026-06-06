namespace taskmvc.Repository;
using Microsoft.Data.SqlClient;
using System.Data;
using Models;

public class TaskRepository2
{
    private readonly string _connectionString;

    public TaskRepository2(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public List<TaskItem> GetAll()
    {
        var tasks = new List<TaskItem>();

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("sp_GetTasks", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        conn.Open();

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            tasks.Add(new TaskItem
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString()!,
                IsDone = Convert.ToBoolean(reader["IsDone"])
            });
        }

        return tasks;
    }

    public TaskItem? GetById(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("sp_GetTaskById", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", id);

        conn.Open();

        using var reader = cmd.ExecuteReader();

        if (!reader.Read())
            return null;

        return new TaskItem
        {
            Id = Convert.ToInt32(reader["Id"]),
            Name = reader["Name"].ToString()!,
            IsDone = Convert.ToBoolean(reader["IsDone"])
        };
    }

    public void Create(TaskItem task)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("sp_CreateTask", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Name", task.Name);
        cmd.Parameters.AddWithValue("@IsDone", task.IsDone);

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Update(TaskItem task)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("sp_UpdateTask", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Id", task.Id);
        cmd.Parameters.AddWithValue("@Name", task.Name);
        cmd.Parameters.AddWithValue("@IsDone", task.IsDone);

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("sp_DeleteTask", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", id);

        conn.Open();
        cmd.ExecuteNonQuery();
    }
}