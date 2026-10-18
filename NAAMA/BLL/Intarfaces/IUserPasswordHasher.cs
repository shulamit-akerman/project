namespace BLL.Interfaces; // משייך את הקוד למרחב השמות BLL.Interfaces.

/// <summary>
/// מגדיר שירות להצפנת סיסמת משתמש בלי לקשור את שכבת הלוגיקה למסגרת Web מסוימת.
/// </summary>
public interface IUserPasswordHasher // מגדיר את חוזה הפעולות של IUserPasswordHasher.
{
    /// <summary>
    /// מחזיר גיבוב מאובטח של סיסמת המשתמש.
    /// </summary>
    string HashPassword(DAL.Models.Users user, string password); // מחשב ומחזיר גיבוב של הסיסמה עבור המשתמש הנתון.
}
