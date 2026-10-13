using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IRequestToVehiclesService
    {
        Task AddAsync(RequestToVehicles relation);
        Task<IEnumerable<RequestToVehicles>> GetByVehicleIdAsync(string vehicleId);
    }
}