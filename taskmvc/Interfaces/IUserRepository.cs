using taskmvc.Models;

namespace taskmvc.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task Update(User user);
        Task Delete(int id);
        Task DeleteAll();
        Task UpdateName(int id, string name);
    }
}
