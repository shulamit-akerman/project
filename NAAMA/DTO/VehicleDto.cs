namespace NAAMA.DTOs;

public sealed class VehicleDto
{
    public int VehicleId { get; set; }
    public int DriverId { get; set; }
    public string LicensePlate { get; set; } = "";
    public string Model { get; set; } = "";
    public string Color { get; set; } = "";
    public int AvailableSeats { get; set; }
}