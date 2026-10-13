using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public sealed class MassageToBookingRepository(AppDbContext context)
    : EntityRepository<MassageToBooking, int>(context), IMassageToBookingRepository
{
    private readonly AppDbContext _context = context;

    public Task<MassageToBooking?> GetByIdAsync(int id) => FindByIdAsync(id);
    public Task<IReadOnlyList<MassageToBooking>> GetAllAsync() => ListAsync();

    public async Task<IReadOnlyList<MassageToBooking>> GetByBookingIdAsync(int bookingId)
    {
        return await _context.MassageToBookings
            .AsNoTracking()
            .Where(message => message.BookingId == bookingId)
            .ToListAsync();
    }

    public Task<MassageToBooking> AddAsync(MassageToBooking entity) => InsertAsync(entity);
    public Task UpdateAsync(int id, MassageToBooking entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(int id) => RemoveAsync(id);
}
