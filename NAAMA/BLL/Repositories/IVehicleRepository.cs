using DAL.Models;

namespace BLL.Repositories;

public interface IVehicleRepository
{
    Task<Vehicle?> GetByIdAsync(int id);
    Task<IReadOnlyList<Vehicle>> GetAllAsync();
    Task<IReadOnlyList<Vehicle>> GetByDriverIdAsync(int driverId);
    Task<Vehicle> AddAsync(Vehicle entity);
    Task UpdateAsync(int id, Vehicle entity);
    Task DeleteAsync(int id);
}
