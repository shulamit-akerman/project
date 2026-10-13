using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IPaymentService
    {
        Task<Payments?> GetPaymentByBookingIdAsync(int bookingId);
        Task ProcessPaymentAsync(Payments payment);
    }
}