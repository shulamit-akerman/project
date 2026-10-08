namespace RideSharing.DTOs
{
    public class CreateVehicleDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int SeatsCount { get; set; }
    }
}