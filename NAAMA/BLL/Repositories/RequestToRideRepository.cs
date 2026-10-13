using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public sealed class RequestToRideRepository(AppDbContext context)
    : EntityRepository<RequestToRide, string>(context), IRequestToRideRepository
{
    private readonly AppDbContext _context = context;

    public Task<RequestToRide?> GetByIdAsync(string id) => FindByIdAsync(id);
    public Task<IReadOnlyList<RequestToRide>> GetAllAsync() => ListAsync();

    public async Task<IReadOnlyList<RequestToRide>> GetByRideIdAsync(string rideId)
    {
        return await _context.RequestToRides
            .AsNoTracking()
            .Where(relation => relation.RideId == rideId)
            .ToListAsync();
    }

    public Task<RequestToRide> AddAsync(RequestToRide entity) => InsertAsync(entity);
    public Task UpdateAsync(string id, RequestToRide entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(string id) => RemoveAsync(id);
}
