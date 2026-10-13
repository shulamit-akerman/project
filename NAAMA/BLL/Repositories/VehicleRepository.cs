using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public sealed class VehicleRepository(AppDbContext context)
    : EntityRepository<Vehicle, int>(context), IVehicleRepository
{
    private readonly AppDbContext _context = context;

    public Task<Vehicle?> GetByIdAsync(int id) => FindByIdAsync(id);
    public Task<IReadOnlyList<Vehicle>> GetAllAsync() => ListAsync();

    public async Task<IReadOnlyList<Vehicle>> GetByDriverIdAsync(int driverId)
    {
        return await _context.Vehicles
            .AsNoTracking()
            .Where(vehicle => vehicle.DriverId == driverId)
            .ToListAsync();
    }

    public Task<Vehicle> AddAsync(Vehicle entity) => InsertAsync(entity);
    public Task UpdateAsync(int id, Vehicle entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(int id) => RemoveAsync(id);
}
