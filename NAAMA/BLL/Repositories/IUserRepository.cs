using DAL.Models;

namespace BLL.Repositories;

public interface IUserRepository
{
    Task<Users?> GetByIdAsync(int id);
    Task<IReadOnlyList<Users>> GetAllAsync();
    Task<Users> AddAsync(Users entity);
    Task UpdateAsync(int id, Users entity);
    Task DeleteAsync(int id);
}
