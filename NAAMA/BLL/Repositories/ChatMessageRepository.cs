using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים עבור הודעות צ'אט.
/// </summary>
public sealed class ChatMessageRepository(AppDbContext context) // מגדיר את הטיפוס ChatMessageRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<ChatMessage, int>(context), IChatMessageRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    public Task<ChatMessage?> GetByIdAsync(int id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<ChatMessage>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.
    public Task<ChatMessage> AddAsync(ChatMessage entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(int id, ChatMessage entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(int id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
