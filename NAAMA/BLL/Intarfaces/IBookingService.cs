using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מספק פעולות CRUD להזמנות, לצד פעולות עסקיות ייעודיות להזמנה.
/// </summary>
public interface IBookingService : IEntityService<Booking, int> // מגדיר את חוזה הפעולות של IBookingService.
{
    /// <summary>
    /// מאחזר הזמנה לפי המזהה שלה.
    /// </summary>
    Task<Booking?> GetBookingByIdAsync(int id); // מכריז על הפעולה GetBookingByIdAsync ועל הפרמטרים והטיפוס שהיא מחזירה.

    /// <summary>
    /// יוצר הזמנה חדשה.
    /// </summary>
    Task CreateBookingAsync(Booking booking); // יוצר הזמנה חדשה ושומר אותה.
}