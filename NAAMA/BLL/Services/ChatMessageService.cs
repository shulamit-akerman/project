using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מנהל הודעות צ'אט ומגדיר את זמן השליחה בעת יצירת הודעה.
/// </summary>
public sealed class ChatMessageService(IChatMessageRepository repository) // מגדיר את הטיפוס ChatMessageService ואת אחריותו בשכבת הלוגיקה.
    : EntityService<ChatMessage, int>(repository), IChatMessageService // יורש את פעולות השירות הגנריות ומממש את חוזה השירות המסוים.
{
    public override Task<ChatMessage> InsertAsync(ChatMessage message) // מוסיף ושומר רשומה חדשה.
    {
        ArgumentNullException.ThrowIfNull(message); // מוודא שהערך message אינו null, לפני שימוש בו.
        message.SentAt = DateTime.UtcNow; // קובע להודעה את זמן השליחה הנוכחי לפי UTC.
        return base.InsertAsync(message); // מחזיר את משימת ההוספה דרך השירות הבסיסי.
    }
}
