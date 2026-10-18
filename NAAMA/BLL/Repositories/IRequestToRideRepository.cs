using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה לקשרים בין בקשות לבין נסיעות.
/// </summary>
public interface IRequestToRideRepository : IEntityRepository<RequestToRide, string> // מגדיר את חוזה הפעולות של IRequestToRideRepository.
{
    /// <summary>
    /// מאחזר את כל הקשרים המשויכים לנסיעה מסוימת.
    /// </summary>
    Task<IReadOnlyList<RequestToRide>> GetByRideIdAsync(string rideId); // מאחזר את קשרי הבקשות של הנסיעה שצוינה.
}
