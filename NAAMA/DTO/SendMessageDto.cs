namespace RideSharingApp.DTOs.Chat
{
    public class SendMessageDto
    {
        public int RideId { get; set; }
        public int? RecipientUserId { get; set; } // אופציונלי: אם המודול תומך בשיחה אישית ולא רק בצ'אט קבוצתי של הנסיעה
        public string MessageText { get; set; }
    }
}