using DAL;
using DAL.Models;

namespace BLL.Repositories;

public sealed class ChatMessageRepository(AppDbContext context)
    : EntityRepository<ChatMessage, int>(context), IChatMessageRepository
{
    public Task<ChatMessage?> GetByIdAsync(int id) => FindByIdAsync(id);
    public Task<IReadOnlyList<ChatMessage>> GetAllAsync() => ListAsync();
    public Task<ChatMessage> AddAsync(ChatMessage entity) => InsertAsync(entity);
    public Task UpdateAsync(int id, ChatMessage entity) => SaveUpdateAsync(id, entity);
    public Task DeleteAsync(int id) => RemoveAsync(id);
}
