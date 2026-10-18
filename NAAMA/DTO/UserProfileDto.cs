// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מייצג פרטי פרופיל משתמש להעברה או להצגה.
    /// </summary>
    public class UserProfileDto
    {
        // המזהה הייחודי של הרשומה.
        public string Id { get; set; }
        // השם המלא של המשתמש.
        public string FullName { get; set; }
        // כתובת הדואר האלקטרוני של המשתמש.
        public string Email { get; set; }
        // מספר הטלפון של המשתמש.
        public string PhoneNumber { get; set; }
        // הדירוג הממוצע של המשתמש.
        public double AverageRating { get; set; }
    }
}