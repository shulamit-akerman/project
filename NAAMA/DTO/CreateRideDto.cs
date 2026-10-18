// ייבוא טיפוסים בסיסיים של .NET, כגון תאריך ושעה.
using System;

// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מכיל את פרטי הקלט לפרסום נסיעה חדשה.
    /// </summary>
    public class CreateRideDto
    {
        // כתובת המוצא של הנסיעה.
        public string OriginAddress { get; set; }
        // קו הרוחב של נקודת המוצא.
        public double OriginLatitude { get; set; }
        // קו האורך של נקודת המוצא.
        public double OriginLongitude { get; set; }

        // כתובת היעד של הנסיעה.
        public string DestinationAddress { get; set; }
        // קו הרוחב של נקודת היעד.
        public double DestinationLatitude { get; set; }
        // קו האורך של נקודת היעד.
        public double DestinationLongitude { get; set; }

        // מועד יציאת הנסיעה.
        public DateTime DepartureTime { get; set; }
        // מספר המושבים הפנויים.
        public int AvailableSeats { get; set; }
        // המחיר לנוסע עבור מושב אחד.
        public decimal PricePerSeat { get; set; }
        // מזהה כלי הרכב המשויך.
        public string VehicleId { get; set; }
        // הערות נוספות לגבי הנסיעה.
        public string Notes { get; set; }
    }
}