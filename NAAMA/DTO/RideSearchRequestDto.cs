using System;

namespace RideSharing.DTOs
{
    public class RideSearchRequestDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public int RequiredSeats { get; set; } = 1;
    }
}