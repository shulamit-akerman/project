using System;

namespace RideSharing.DTOs
{
    public class RideSummaryDto
    {
        public string Id { get; set; }
        public string OriginAddress { get; set; }
        public string DestinationAddress { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal PricePerSeat { get; set; }
        public int AvailableSeats { get; set; }
        public string DriverName { get; set; }
        public double DriverRating { get; set; }
    }
}