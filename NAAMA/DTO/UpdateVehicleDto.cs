namespace NAAMA.DTOs;

public sealed class UpdateVehicleDto
{
    public string LicensePlate { get; set; } = "";
    public string Model { get; set; } = "";
    public string Color { get; set; } = "";
    public int AvailableSeats { get; set; }
}