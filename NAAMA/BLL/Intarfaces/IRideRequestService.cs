using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IRideRequestService
    {
        Task<RideRequest?> GetRequestByIdAsync(int id);
        Task CreateRideRequestAsync(RideRequest request);
    }
}