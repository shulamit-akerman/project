// ייבוא טיפוסים בסיסיים של .NET, כגון תאריך ושעה.
using System;

// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מייצג סיכום קצר של נסיעה לצורכי הצגה או העברה.
    /// </summary>
    public class RideSummaryDto
    {
        // המזהה הייחודי של הרשומה.
        public string Id { get; set; }
        // כתובת המוצא של הנסיעה.
        public string OriginAddress { get; set; }
        // כתובת היעד של הנסיעה.
        public string DestinationAddress { get; set; }
        // מועד יציאת הנסיעה.
        public DateTime DepartureTime { get; set; }
        // המחיר לנוסע עבור מושב אחד.
        public decimal PricePerSeat { get; set; }
        // מספר המושבים הפנויים.
        public int AvailableSeats { get; set; }
        // שם הנהג המשויך לנסיעה.
        public string DriverName { get; set; }
        // דירוג הנהג הממוצע.
        public double DriverRating { get; set; }
    }
}