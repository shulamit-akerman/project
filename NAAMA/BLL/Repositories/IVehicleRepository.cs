using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה לכלי רכב ושליפה לפי הנהג.
/// </summary>
public interface IVehicleRepository : IEntityRepository<Vehicle, int> // מגדיר את חוזה הפעולות של IVehicleRepository.
{
    /// <summary>
    /// מאחזר את כלי הרכב המשויכים לנהג מסוים.
    /// </summary>
    Task<IReadOnlyList<Vehicle>> GetByDriverIdAsync(int driverId); // מאחזר את כלי הרכב המשויכים לנהג שצוין.
}
