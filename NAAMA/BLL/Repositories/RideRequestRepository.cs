using DAL;
using DAL.Models;

namespace BLL.Repositories;

public sealed class RideRequestRepository(AppDbContext context)
    : EntityRepository<RideRequest, int>(context), IRideRequestRepository
{
    public Task<RideRequest?> GetByIdAsync(int id) => FindByIdAsync(id);
    public Task<IReadOnlyList<RideRequest>> GetAllAsync() => ListAsync();
    public Task<RideRequest> AddAsync(RideRequest entity) => InsertAsync(entity);
    public Task UpdateAsync(int id, RideRequest entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(int id) => RemoveAsync(id);
}
