// ייבוא טיפוסים בסיסיים של .NET, כגון תאריך ושעה.
using System;

// הגדרת מרחב השמות RideSharingApp.DTOs.Chat כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharingApp.DTOs.Chat
{
    /// <summary>
    /// מייצג פרטי הודעת צ'אט להעברה בין שכבות המערכת.
    /// </summary>
    public class ChatMessageDto
    {
        // המזהה הייחודי של הרשומה.
        public int Id { get; set; }
        // מזהה הנסיעה שאליה מתייחסים.
        public int RideId { get; set; }
        // מזהה המשתמש ששלח את ההודעה.
        public int SenderUserId { get; set; }
        // שם המשתמש ששלח את ההודעה.
        public string SenderName { get; set; }
        // תוכן הודעת הצ׳אט.
        public string MessageText { get; set; }
        // מועד שליחת ההודעה.
        public DateTime SentAt { get; set; }
    }
}