using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetVehiclesByDriverAsync(int driverId);
        Task AddVehicleAsync(Vehicle vehicle);
    }
}