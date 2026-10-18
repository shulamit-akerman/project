// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מכיל את פרטי הזיהוי הנשלחים בבקשת התחברות.
    /// </summary>
    public class LoginRequestDto
    {
        // כתובת הדואר האלקטרוני של המשתמש.
        public string Email { get; set; }
        // הסיסמה שהוזנה בבקשה.
        public string Password { get; set; }
    }
}