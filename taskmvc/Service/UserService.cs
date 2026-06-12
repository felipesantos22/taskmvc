using taskmvc.Repository;
using taskmvc.Interfaces;
using taskmvc.Models;


namespace taskmvc.Service
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(User user)
        {
            await _repository.Create(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<User?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(User user)
        {
            await _repository.Update(user);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task UpdateName(int id, string name)
        {
            await _repository.UpdateName(id, name);
        }


    }
}
