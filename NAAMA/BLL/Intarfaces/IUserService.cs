using System.Collections.Generic; // מייבא את מרחב השמות System.Collections.Generic כדי להשתמש בטיפוסים ובפעולות שלו.
using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.
using BLL.Services; // מייבא את מרחב השמות BLL.Services כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Interfaces // משייך את הקוד למרחב השמות BLL.Interfaces.
{
    /// <summary>
    /// מספק פעולות משתמש ומכין משתמש חדש לשמירה באופן מאובטח.
    /// </summary>
    public interface IUserService : IEntityService<Users, int> // מגדיר את חוזה הפעולות של IUserService.
    {
        /// <summary>
        /// מגבב את סיסמת המשתמש ומאתחל את פרטי החשבון לפני יצירתו.
        /// </summary>
        void PrepareForCreate(Users user, string password); // מכין את פרטי המשתמש ליצירה, כולל גיבוב הסיסמה ואתחול מצב החשבון.
    }
}