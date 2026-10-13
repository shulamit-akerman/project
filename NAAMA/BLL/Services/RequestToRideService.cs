using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class RequestToRideService : IRequestToRideService
    {
        private readonly IRequestToRideRepository _repository;

        public RequestToRideService(IRequestToRideRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(RequestToRide relation)
        {
            await _repository.AddAsync(relation);
        }

        public async Task<IEnumerable<RequestToRide>> GetByRideIdAsync(string rideId)
        {
            return await _repository.GetByRideIdAsync(rideId);
        }
    }
}