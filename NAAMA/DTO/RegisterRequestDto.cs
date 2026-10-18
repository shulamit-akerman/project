// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מכיל את פרטי הקלט לרישום משתמש חדש.
    /// </summary>
    public class RegisterRequestDto
    {
        // השם המלא של המשתמש.
        public string FullName { get; set; }
        // כתובת הדואר האלקטרוני של המשתמש.
        public string Email { get; set; }
        // הסיסמה שהוזנה בבקשה.
        public string Password { get; set; }
        // מספר הטלפון של המשתמש.
        public string PhoneNumber { get; set; }
    }
}