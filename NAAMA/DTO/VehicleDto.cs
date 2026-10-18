// הגדרת מרחב השמות NAAMA.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace NAAMA.DTOs;

/// <summary>
/// מייצג פרטי כלי רכב המועברים ללקוח ה־API.
/// </summary>
public sealed class VehicleDto
{
    // מזהה כלי הרכב המשויך.
    public int VehicleId { get; set; }
    // מזהה הנהג.
    public int DriverId { get; set; }
    // מספר לוחית הרישוי של כלי הרכב.
    public string LicensePlate { get; set; } = "";
    // דגם כלי הרכב.
    public string Model { get; set; } = "";
    // צבע כלי הרכב.
    public string Color { get; set; } = "";
    // מספר המושבים הפנויים.
    public int AvailableSeats { get; set; }
}