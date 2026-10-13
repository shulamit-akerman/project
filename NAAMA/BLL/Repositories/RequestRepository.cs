using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public sealed class RequestRepository(AppDbContext context)
    : EntityRepository<Request, string>(context), IRequestRepository
{
    private readonly AppDbContext _context = context;

    public Task<Request?> GetByIdAsync(string id) => FindByIdAsync(id);
    public Task<IReadOnlyList<Request>> GetAllAsync() => ListAsync();

    public async Task<IReadOnlyList<Request>> FindMatchingAsync(
        bool hasTrunk,
        bool fitsStroller,
        bool childSeats)
    {
        return await _context.Requests
            .AsNoTracking()
            .Where(request =>
                (!request.HasTrunkSpace || hasTrunk) &&
                (!request.FitsStroller || fitsStroller) &&
                (!request.HasChildSeats || childSeats))
            .ToListAsync();
    }

    public Task<Request> AddAsync(Request entity) => InsertAsync(entity);
    public Task UpdateAsync(string id, Request entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(string id) => RemoveAsync(id);
}
