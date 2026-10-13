using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class RideService : IRideService
    {
        private readonly IRideRepository _repository;

        public RideService(IRideRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Ride>> GetAllRidesAsync() => await _repository.GetAllAsync();

        public Task<Ride?> GetRideByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task AddRideAsync(Ride ride)
        {
            await _repository.AddAsync(ride);
        }

        public Task UpdateRideAsync(Ride ride) => _repository.UpdateAsync(ride.RideId, ride);

        public Task DeleteRideAsync(int id) => _repository.DeleteAsync(id);
    }
}