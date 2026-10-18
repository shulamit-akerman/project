using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה לקשרים בין בקשות לבין כלי רכב.
/// </summary>
public interface IRequestToVehiclesRepository : IEntityRepository<RequestToVehicles, string> // מגדיר את חוזה הפעולות של IRequestToVehiclesRepository.
{
    /// <summary>
    /// מאחזר את כל הקשרים המשויכים לכלי רכב מסוים.
    /// </summary>
    Task<IReadOnlyList<RequestToVehicles>> GetByVehicleIdAsync(string vehicleId); // מאחזר את קשרי הבקשות של כלי הרכב שצוין.
}
