using DAL;
using DAL.Models;

namespace BLL.Repositories;

public sealed class BookingRepository(AppDbContext context)
    : EntityRepository<Booking, int>(context), IBookingRepository
{
    public Task<Booking?> GetByIdAsync(int id) => FindByIdAsync(id);
    public Task<IReadOnlyList<Booking>> GetAllAsync() => ListAsync();
    public Task<Booking> AddAsync(Booking entity) => InsertAsync(entity);
    public Task UpdateAsync(int id, Booking entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(int id) => RemoveAsync(id);
}
