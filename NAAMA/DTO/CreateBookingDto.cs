// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מכיל את פרטי הקלט הנדרשים ליצירת הזמנה.
    /// </summary>
    public class CreateBookingDto
    {
        // מזהה הנסיעה שאליה מתייחסים.
        public string RideId { get; set; }
        // מספר המושבים שהתבקשו.
        public int RequestedSeats { get; set; }
        // הנחיות בנוגע לאיסוף הנוסע.
        public string PickupNotes { get; set; }
    }
}