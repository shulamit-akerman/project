using System.Collections.Generic; // מייבא את מרחב השמות System.Collections.Generic כדי להשתמש בטיפוסים ובפעולות שלו.
using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מנהל קישורים בין בקשות לנסיעות ומספק חיפוש לפי נסיעה.
/// </summary>
public interface IRequestToRideService : IEntityService<RequestToRide, string> // מגדיר את חוזה הפעולות של IRequestToRideService.
{
    /// <summary>
    /// מאחזר קשרים בין בקשות לנסיעה מסוימת.
    /// </summary>
    Task<IEnumerable<RequestToRide>> GetByRideIdAsync(string rideId); // מאחזר את קשרי הבקשות של הנסיעה שצוינה.
}