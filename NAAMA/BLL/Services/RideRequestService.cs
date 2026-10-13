using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class RideRequestService : IRideRequestService
    {
        private readonly IRideRequestRepository _repository;

        public RideRequestService(IRideRequestRepository repository)
        {
            _repository = repository;
        }

        public Task<RideRequest?> GetRequestByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task CreateRideRequestAsync(RideRequest request)
        {
            await _repository.AddAsync(request);
        }
    }
}