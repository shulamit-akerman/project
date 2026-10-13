using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByDriverAsync(int driverId) =>
            await _repository.GetByDriverIdAsync(driverId);

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            await _repository.AddAsync(vehicle);
        }
    }
}