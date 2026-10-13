using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public sealed class RequestToVehiclesRepository(AppDbContext context)
    : EntityRepository<RequestToVehicles, string>(context), IRequestToVehiclesRepository
{
    private readonly AppDbContext _context = context;

    public Task<RequestToVehicles?> GetByIdAsync(string id) => FindByIdAsync(id);
    public Task<IReadOnlyList<RequestToVehicles>> GetAllAsync() => ListAsync();

    public async Task<IReadOnlyList<RequestToVehicles>> GetByVehicleIdAsync(string vehicleId)
    {
        return await _context.RequestToVehicle
            .AsNoTracking()
            .Where(relation => relation.VehicleId == vehicleId)
            .ToListAsync();
    }

    public Task<RequestToVehicles> AddAsync(RequestToVehicles entity) => InsertAsync(entity);
    public Task UpdateAsync(string id, RequestToVehicles entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(string id) => RemoveAsync(id);
}
