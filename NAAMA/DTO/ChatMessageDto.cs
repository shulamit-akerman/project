using System;

namespace RideSharingApp.DTOs.Chat
{
    public class ChatMessageDto
    {
        public int Id { get; set; }
        public int RideId { get; set; }
        public int SenderUserId { get; set; }
        public string SenderName { get; set; }
        public string MessageText { get; set; }
        public DateTime SentAt { get; set; }
    }
}