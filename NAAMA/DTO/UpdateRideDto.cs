using System;

namespace RideSharing.DTOs
{
    public class UpdateRideDto
    {
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
        public decimal PricePerSeat { get; set; }
        public string Notes { get; set; }
    }
}