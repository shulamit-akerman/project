using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;

        public RequestService(IRequestRepository repository)
        {
            _repository = repository;
        }

        public Task<Request?> GetRequestByIdAsync(string requestId) => _repository.GetByIdAsync(requestId);

        public async Task AddRequestAsync(Request request)
        {
            await _repository.AddAsync(request);
        }

        public Task UpdateRequestAsync(Request request) => _repository.UpdateAsync(request.RequestId, request);

        public async Task<IEnumerable<Request>> FindMatchingRequestsAsync(
            bool hasTrunk,
            bool fitsStroller,
            bool childSeats)
        {
            return await _repository.FindMatchingAsync(hasTrunk, fitsStroller, childSeats);
        }
    }
}