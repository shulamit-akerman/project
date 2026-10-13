using DAL.Models;

namespace BLL.Repositories;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(int id);
    Task<IReadOnlyList<Booking>> GetAllAsync();
    Task<Booking> AddAsync(Booking entity);
    Task UpdateAsync(int id, Booking entity);
    Task DeleteAsync(int id);
}
