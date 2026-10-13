using NAAMA.DTOs;

namespace RideSharing.DTOs
{
    public class RideDetailsDto : RideSummaryDto
    {
        public string Notes { get; set; }
        public VehicleDto Vehicle { get; set; }
    }
}