using DAL;
using DAL.Models;

namespace BLL.Repositories;

public sealed class UserRepository(AppDbContext context)
    : EntityRepository<Users, int>(context), IUserRepository
{
    public Task<Users?> GetByIdAsync(int id) => FindByIdAsync(id);
    public Task<IReadOnlyList<Users>> GetAllAsync() => ListAsync();
    public Task<Users> AddAsync(Users entity) => InsertAsync(entity);
    public Task UpdateAsync(int id, Users entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(int id) => RemoveAsync(id);
}
