// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מכיל את המצב החדש המבוקש לעדכון הזמנה.
    /// </summary>
    public class UpdateBookingStatusDto
    {
        // מזהה ההזמנה.
        public string BookingId { get; set; }
        // המצב הנוכחי או המבוקש של הרשומה.
        public string Status { get; set; }
    }
}