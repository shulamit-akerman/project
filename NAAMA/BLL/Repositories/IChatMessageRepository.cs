using DAL.Models;

namespace BLL.Repositories;

public interface IChatMessageRepository
{
    Task<ChatMessage?> GetByIdAsync(int id);
    Task<IReadOnlyList<ChatMessage>> GetAllAsync();
    Task<ChatMessage> AddAsync(ChatMessage entity);
    Task UpdateAsync(int id, ChatMessage entity);
    Task DeleteAsync(int id);
}
