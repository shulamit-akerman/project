using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IRequestService
    {
        Task<Request?> GetRequestByIdAsync(string requestId);
        Task AddRequestAsync(Request request);
        Task UpdateRequestAsync(Request request);
        Task<IEnumerable<Request>> FindMatchingRequestsAsync(bool hasTrunk, bool fitsStroller, bool childSeats);
    }
}