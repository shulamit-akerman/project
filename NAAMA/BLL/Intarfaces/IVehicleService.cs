using System.Collections.Generic; // מייבא את מרחב השמות System.Collections.Generic כדי להשתמש בטיפוסים ובפעולות שלו.
using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מספק פעולות CRUD לכלי רכב ופעולות עסקיות לפי הנהג.
/// </summary>
public interface IVehicleService : IEntityService<Vehicle, int> // מגדיר את חוזה הפעולות של IVehicleService.
{
    /// <summary>
    /// מאחזר את כלי הרכב של נהג מסוים.
    /// </summary>
    Task<IEnumerable<Vehicle>> GetVehiclesByDriverAsync(int driverId); // מאחזר את כלי הרכב של הנהג הנתון.

    /// <summary>
    /// מוסיף כלי רכב חדש.
    /// </summary>
    Task AddVehicleAsync(Vehicle vehicle); // יוצר כלי רכב באמצעות פעולת ההוספה המשותפת.
}