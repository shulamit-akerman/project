using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מספק פעולות CRUD להודעות צ'אט; זמן השליחה נקבע בשירות בעת יצירה.
/// </summary>
public interface IChatMessageService : IEntityService<ChatMessage, int> // מגדיר את חוזה הפעולות של IChatMessageService.
{
}
