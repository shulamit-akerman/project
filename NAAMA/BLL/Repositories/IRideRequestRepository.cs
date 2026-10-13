using DAL.Models;

namespace BLL.Repositories;

public interface IRideRequestRepository
{
    Task<RideRequest?> GetByIdAsync(int id);
    Task<IReadOnlyList<RideRequest>> GetAllAsync();
    Task<RideRequest> AddAsync(RideRequest entity);
    Task UpdateAsync(int id, RideRequest entity);
    Task DeleteAsync(int id);
}
