using taskmvc.Models;

namespace taskmvc.Interfaces
{
    public interface ITaskRepository
    {
        void Create(TaskItem task);
        IEnumerable<TaskItem> GetAll();
        TaskItem? GetById(int id);
        void Update(TaskItem task);
        void Delete(int id);
    }
}
