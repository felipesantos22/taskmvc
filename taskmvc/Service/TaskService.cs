namespace taskmvc.Service;

using taskmvc.Models;
using taskmvc.Interfaces;

public class TaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<TaskItem> GetAll()
    {
        return _repository.GetAll();
    }

    public TaskItem? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Create(TaskItem task)
    {
        _repository.Create(task);
    }

    public void Update(TaskItem task)
    {
        _repository.Update(task);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}