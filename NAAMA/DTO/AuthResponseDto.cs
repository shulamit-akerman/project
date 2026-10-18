// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מייצג את נתוני התגובה לאחר אימות משתמש.
    /// </summary>
    public class AuthResponseDto
    {
        // אסימון האימות שהוחזר לאחר התחברות מוצלחת.
        public string Token { get; set; }
        // מזהה המשתמש שאליו שייכת התגובה.
        public string UserId { get; set; }
        // השם המלא של המשתמש.
        public string FullName { get; set; }
    }
}