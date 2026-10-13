using BLL.Interfaces;
using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<Users?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task AddAsync(Users user)
        {
            await _repository.AddAsync(user);
        }

        public Task UpdateAsync(Users user) => _repository.UpdateAsync(user.UserId, user);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
