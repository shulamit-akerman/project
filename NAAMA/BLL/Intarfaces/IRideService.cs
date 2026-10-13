using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IRideService
    {
        Task<IEnumerable<Ride>> GetAllRidesAsync();
        Task<Ride?> GetRideByIdAsync(int id);
        Task AddRideAsync(Ride ride);
        Task UpdateRideAsync(Ride ride);
        Task DeleteRideAsync(int id);
    }
}