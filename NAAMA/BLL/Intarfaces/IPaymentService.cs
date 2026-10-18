using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מרכז פעולות CRUD ותהליכים עסקיים של תשלומים.
/// </summary>
public interface IPaymentService : IEntityService<Payments, int> // מגדיר את חוזה הפעולות של IPaymentService.
{
    /// <summary>
    /// מאחזר את התשלום האחרון של הזמנה.
    /// </summary>
    Task<Payments?> GetPaymentByBookingIdAsync(int bookingId); // מאחזר את התשלום האחרון של ההזמנה הנתונה.

    /// <summary>
    /// מעבד ושומר תשלום חדש.
    /// </summary>
    Task ProcessPaymentAsync(Payments payment); // מאתחל את פרטי התשלום החסרים ושומר אותו במאגר.
}