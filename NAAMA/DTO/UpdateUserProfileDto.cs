// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מכיל את פרטי הקלט לעדכון פרופיל משתמש.
    /// </summary>
    public class UpdateUserProfileDto
    {
        // השם המלא של המשתמש.
        public string FullName { get; set; }
        // מספר הטלפון של המשתמש.
        public string PhoneNumber { get; set; }
    }
}