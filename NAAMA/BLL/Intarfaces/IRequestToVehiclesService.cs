using System.Collections.Generic; // מייבא את מרחב השמות System.Collections.Generic כדי להשתמש בטיפוסים ובפעולות שלו.
using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מנהל קישורים בין בקשות לכלי רכב ומספק חיפוש לפי כלי רכב.
/// </summary>
public interface IRequestToVehiclesService : IEntityService<RequestToVehicles, string> // מגדיר את חוזה הפעולות של IRequestToVehiclesService.
{
    /// <summary>
    /// מאחזר קשרים בין בקשות לכלי רכב מסוים.
    /// </summary>
    Task<IEnumerable<RequestToVehicles>> GetByVehicleIdAsync(string vehicleId); // מאחזר את קשרי הבקשות של כלי הרכב שצוין.
}