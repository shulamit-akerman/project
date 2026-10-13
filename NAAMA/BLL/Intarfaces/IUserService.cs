using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users?> GetByIdAsync(int id);
        Task AddAsync(Users user);
        Task UpdateAsync(Users user);
        Task DeleteAsync(int id);
    }
}