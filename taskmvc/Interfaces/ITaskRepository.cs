using taskmvc.Models;

namespace taskmvc.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem? GetById(int id);
        void Create(TaskItem task);
        void Update(TaskItem task);
        void Delete(int id);
    }
}
