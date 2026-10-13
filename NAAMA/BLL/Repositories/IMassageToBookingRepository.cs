using DAL.Models;

namespace BLL.Repositories;

public interface IMassageToBookingRepository
{
    Task<MassageToBooking?> GetByIdAsync(int id);
    Task<IReadOnlyList<MassageToBooking>> GetAllAsync();
    Task<IReadOnlyList<MassageToBooking>> GetByBookingIdAsync(int bookingId);
    Task<MassageToBooking> AddAsync(MassageToBooking entity);
    Task UpdateAsync(int id, MassageToBooking entity);
    Task DeleteAsync(int id);
}
