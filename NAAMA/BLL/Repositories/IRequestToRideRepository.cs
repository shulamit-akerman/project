using DAL.Models;

namespace BLL.Repositories;

public interface IRequestToRideRepository
{
    Task<RequestToRide?> GetByIdAsync(string id);
    Task<IReadOnlyList<RequestToRide>> GetAllAsync();
    Task<IReadOnlyList<RequestToRide>> GetByRideIdAsync(string rideId);
    Task<RequestToRide> AddAsync(RequestToRide entity);
    Task UpdateAsync(string id, RequestToRide entity);
    Task DeleteAsync(string id);
}
