using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IRequestToRideService
    {
        Task AddAsync(RequestToRide relation);
        Task<IEnumerable<RequestToRide>> GetByRideIdAsync(string rideId);
    }
}