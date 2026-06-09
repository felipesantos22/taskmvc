using taskmvc.Models;

namespace taskmvc.Interfaces
{
    public interface IUser
    {
        Task<User> Create(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User> Update(User user);
        Task Delete(int id);
        Task DeleteAll();
    }
}
