using System;

namespace RideSharing.DTOs
{
    public class BookingDto
    {
        public string Id { get; set; }
        public string RideId { get; set; }
        public string PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int RequestedSeats { get; set; }
        public string Status { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}