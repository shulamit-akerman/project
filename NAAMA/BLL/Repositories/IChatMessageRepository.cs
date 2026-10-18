using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה לנתונים עבור הודעות צ'אט.
/// </summary>
public interface IChatMessageRepository : IEntityRepository<ChatMessage, int> // מגדיר את חוזה הפעולות של IChatMessageRepository.
{
}
