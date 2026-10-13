using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public sealed class PaymentRepository(AppDbContext context)
    : EntityRepository<Payments, int>(context), IPaymentRepository
{
    private readonly AppDbContext _context = context;

    public Task<Payments?> GetByIdAsync(int id) => FindByIdAsync(id);
    public Task<IReadOnlyList<Payments>> GetAllAsync() => ListAsync();

    public Task<Payments?> GetLatestByBookingIdAsync(int bookingId)
    {
        return _context.Payments
            .AsNoTracking()
            .Where(payment => payment.BookingId == bookingId)
            .OrderByDescending(payment => payment.CreateAt)
            .FirstOrDefaultAsync();
    }

    public Task<Payments> AddAsync(Payments entity) => InsertAsync(entity);
    public Task UpdateAsync(int id, Payments entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(int id) => RemoveAsync(id);
}
