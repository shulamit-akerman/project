using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class RequestToVehiclesService : IRequestToVehiclesService
    {
        private readonly IRequestToVehiclesRepository _repository;

        public RequestToVehiclesService(IRequestToVehiclesRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(RequestToVehicles relation)
        {
            await _repository.AddAsync(relation);
        }

        public async Task<IEnumerable<RequestToVehicles>> GetByVehicleIdAsync(string vehicleId)
        {
            return await _repository.GetByVehicleIdAsync(vehicleId);
        }
    }
}