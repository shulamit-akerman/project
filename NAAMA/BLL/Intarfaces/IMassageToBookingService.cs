using System.Collections.Generic; // מייבא את מרחב השמות System.Collections.Generic כדי להשתמש בטיפוסים ובפעולות שלו.
using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מנהל הודעות המשויכות להזמנות ומספק חיפוש הודעות לפי הזמנה.
/// </summary>
public interface IMassageToBookingService : IEntityService<MassageToBooking, int> // מגדיר את חוזה הפעולות של IMassageToBookingService.
{
    /// <summary>
    /// מאחזר את ההודעות המשויכות להזמנה מסוימת.
    /// </summary>
    Task<IEnumerable<MassageToBooking>> GetMessagesByBookingIdAsync(int bookingId); // מאחזר את הודעות ההזמנה לפי מזהה ההזמנה.
}