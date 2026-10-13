using DAL.Models;

namespace BLL.Repositories;

public interface IPaymentRepository
{
    Task<Payments?> GetByIdAsync(int id);
    Task<IReadOnlyList<Payments>> GetAllAsync();
    Task<Payments?> GetLatestByBookingIdAsync(int bookingId);
    Task<Payments> AddAsync(Payments entity);
    Task UpdateAsync(int id, Payments entity);
    Task DeleteAsync(int id);
}
