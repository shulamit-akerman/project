using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IMassageToBookingService
    {
        Task AddAsync(MassageToBooking massageToBooking);
        Task<IEnumerable<MassageToBooking>> GetMessagesByBookingIdAsync(int bookingId);
    }
}