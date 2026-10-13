using DAL.Models;

namespace BLL.Repositories;

public interface IRideRepository
{
    Task<Ride?> GetByIdAsync(int id);
    Task<IReadOnlyList<Ride>> GetAllAsync();
    Task<Ride> AddAsync(Ride entity);
    Task UpdateAsync(int id, Ride entity);
    Task DeleteAsync(int id);
}
