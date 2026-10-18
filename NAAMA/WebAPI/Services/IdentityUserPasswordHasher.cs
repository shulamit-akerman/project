// מייבא את החוזה של שכבת הלוגיקה עבור גיבוב סיסמאות.
using BLL.Interfaces;
// מייבא את מודל המשתמש שעליו פועל מגבב הסיסמאות.
using DAL.Models;
// מייבא את ממשק ומימוש גיבוב הסיסמאות של ASP.NET Identity.
using Microsoft.AspNetCore.Identity;

// מגדיר את מרחב השמות של שירותי העזר ב-WebAPI.
namespace WebAPI.Services;

/// <summary>
/// מתאם בין שירותי המשתמשים לבין מנגנון גיבוב הסיסמאות של ASP.NET Identity.
/// </summary>
/// <param name="passwordHasher">מימוש ASP.NET Identity שמבצע גיבוב סיסמאות.</param>
// מממש את חוזה ה-BLL תוך שימוש במנגנון הגיבוב שמסופק על ידי ה-Web API.
public sealed class IdentityUserPasswordHasher(IPasswordHasher<Users> passwordHasher)
    : IUserPasswordHasher
{
    /// <summary>מגבש סיסמה באמצעות ASP.NET Identity.</summary>
    /// <param name="user">המשתמש שאליו משויכת הסיסמה.</param>
    /// <param name="password">הסיסמה הגלויה שהתקבלה בעת הרישום.</param>
    /// <returns>מחרוזת הגיבוב שיש לשמור במקום הסיסמה הגלויה.</returns>
    // מעביר את המשתמש והסיסמה למימוש המוכן ומחזיר את תוצאת הגיבוב.
    public string HashPassword(Users user, string password) =>
        passwordHasher.HashPassword(user, password);
}
