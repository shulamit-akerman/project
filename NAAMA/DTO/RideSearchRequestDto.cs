// ייבוא טיפוסים בסיסיים של .NET, כגון תאריך ושעה.
using System;

// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מכיל את התנאים לחיפוש נסיעות מתאימות.
    /// </summary>
    public class RideSearchRequestDto
    {
        // נקודת המוצא של הנסיעה.
        public string Origin { get; set; }
        // נקודת היעד של הנסיעה.
        public string Destination { get; set; }
        // התאריך שלגביו מתבצע החיפוש.
        public DateTime Date { get; set; }
        // מספר המושבים הדרוש בחיפוש.
        public int RequiredSeats { get; set; } = 1;
    }
}