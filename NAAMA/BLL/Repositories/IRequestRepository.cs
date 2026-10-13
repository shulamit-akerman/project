using DAL.Models;

namespace BLL.Repositories;

public interface IRequestRepository
{
    Task<Request?> GetByIdAsync(string id);
    Task<IReadOnlyList<Request>> GetAllAsync();
    Task<IReadOnlyList<Request>> FindMatchingAsync(bool hasTrunk, bool fitsStroller, bool childSeats);
    Task<Request> AddAsync(Request entity);
    Task UpdateAsync(string id, Request entity);
    Task DeleteAsync(string id);
}
