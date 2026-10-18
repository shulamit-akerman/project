using System.Collections.Generic; // מייבא את מרחב השמות System.Collections.Generic כדי להשתמש בטיפוסים ובפעולות שלו.
using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מנהל בקשות נסיעה, כולל חיפוש בקשות המתאימות לדרישות רכב.
/// </summary>
public interface IRequestService : IEntityService<Request, string> // מגדיר את חוזה הפעולות של IRequestService.
{
    /// <summary>
    /// מאחזר בקשת נסיעה לפי המזהה שלה.
    /// </summary>
    Task<Request?> GetRequestByIdAsync(string requestId); // מאחזר בקשת נסיעה לפי המזהה שלה.

    /// <summary>
    /// מחפש בקשות לפי דרישות הרכב שהוגדרו.
    /// </summary>
    Task<IEnumerable<Request>> FindMatchingRequestsAsync(bool hasTrunk, bool fitsStroller, bool childSeats); // מחפש בקשות שכל דרישות הרכב שלהן מתקיימות.
}