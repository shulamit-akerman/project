using System;

namespace RideSharing.DTOs
{
    public class CreateRideDto
    {
        public string OriginAddress { get; set; }
        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }

        public string DestinationAddress { get; set; }
        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }

        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
        public decimal PricePerSeat { get; set; }
        public string VehicleId { get; set; }
        public string Notes { get; set; }
    }
}