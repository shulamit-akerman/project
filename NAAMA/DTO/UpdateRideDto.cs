// ייבוא טיפוסים בסיסיים של .NET, כגון תאריך ושעה.
using System;

// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מכיל את פרטי הקלט לעדכון נסיעה קיימת.
    /// </summary>
    public class UpdateRideDto
    {
        // מועד יציאת הנסיעה.
        public DateTime DepartureTime { get; set; }
        // מספר המושבים הפנויים.
        public int AvailableSeats { get; set; }
        // המחיר לנוסע עבור מושב אחד.
        public decimal PricePerSeat { get; set; }
        // הערות נוספות לגבי הנסיעה.
        public string Notes { get; set; }
    }
}