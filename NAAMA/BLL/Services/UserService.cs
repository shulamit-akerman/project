using BLL.Interfaces; // מייבא את מרחב השמות BLL.Interfaces כדי להשתמש בטיפוסים ובפעולות שלו.
using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מנהל משתמשים ומרכז את אתחול החשבון ואת גיבוב הסיסמה לפני שמירה.
    /// </summary>
    public class UserService : EntityService<Users, int>, IUserService // מגדיר את הטיפוס UserService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IUserPasswordHasher _passwordHasher; // שומר את שירות גיבוב הסיסמאות המשמש להכנת משתמשים.

        public UserService(IUserRepository repository, IUserPasswordHasher passwordHasher) // מאתחל מופע של UserService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _passwordHasher = passwordHasher; // שומר את שירות גיבוב הסיסמאות שהועבר לבנאי.
        }

        public void PrepareForCreate(Users user, string password) // מכין את פרטי המשתמש ליצירה, כולל גיבוב הסיסמה ואתחול מצב החשבון.
        {
            ArgumentNullException.ThrowIfNull(user); // מוודא שהערך user אינו null, לפני שימוש בו.
            ArgumentNullException.ThrowIfNull(password); // מוודא שהערך password אינו null, לפני שימוש בו.

            user.PasswordHash = _passwordHasher.HashPassword(user, password); // שומר במשתמש את גיבוב הסיסמה שחושב על ידי שירות הגיבוב.
            user.CreatedAt = DateTime.UtcNow; // קובע את מועד יצירת החשבון לפי שעון UTC.
            user.IsPhoneVerified = false; // מסמן שהטלפון עדיין לא אומת בעת יצירת החשבון.
        }
    }
}
