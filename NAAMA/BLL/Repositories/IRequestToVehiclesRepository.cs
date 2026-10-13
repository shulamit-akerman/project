using DAL.Models;

namespace BLL.Repositories;

public interface IRequestToVehiclesRepository
{
    Task<RequestToVehicles?> GetByIdAsync(string id);
    Task<IReadOnlyList<RequestToVehicles>> GetAllAsync();
    Task<IReadOnlyList<RequestToVehicles>> GetByVehicleIdAsync(string vehicleId);
    Task<RequestToVehicles> AddAsync(RequestToVehicles entity);
    Task UpdateAsync(string id, RequestToVehicles entity);
    Task DeleteAsync(string id);
}
