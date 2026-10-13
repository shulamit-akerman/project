using DAL;
using DAL.Models;

namespace BLL.Repositories;

public sealed class RideRepository(AppDbContext context)
    : EntityRepository<Ride, int>(context), IRideRepository
{
    public Task<Ride?> GetByIdAsync(int id) => FindByIdAsync(id);
    public Task<IReadOnlyList<Ride>> GetAllAsync() => ListAsync();
    public Task<Ride> AddAsync(Ride entity) => InsertAsync(entity);
    public Task UpdateAsync(int id, Ride entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(int id) => RemoveAsync(id);
}
