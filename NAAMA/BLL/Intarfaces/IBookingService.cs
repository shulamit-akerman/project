using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IBookingService
    {
        Task<Booking?> GetBookingByIdAsync(int id);
        Task CreateBookingAsync(Booking booking);
    }
}