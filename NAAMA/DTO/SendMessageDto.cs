// הגדרת מרחב השמות RideSharingApp.DTOs.Chat כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharingApp.DTOs.Chat
{
    /// <summary>
    /// מכיל את פרטי הקלט לשליחת הודעה.
    /// </summary>
    public class SendMessageDto
    {
        // מזהה הנסיעה שאליה מתייחסים.
        public int RideId { get; set; }
        // מזהה הנמען בשיחה אישית.
        public int? RecipientUserId { get; set; } // אופציונלי: אם המודול תומך בשיחה אישית ולא רק בצ'אט קבוצתי של הנסיעה
        // תוכן הודעת הצ׳אט.
        public string MessageText { get; set; }
    }
}