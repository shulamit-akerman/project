using System.Collections.Generic; // מייבא את מרחב השמות System.Collections.Generic כדי להשתמש בטיפוסים ובפעולות שלו.
using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מספק פעולות CRUD לניהול נסיעות.
/// </summary>
public interface IRideService : IEntityService<Ride, int> // מגדיר את חוזה הפעולות של IRideService.
{
    /// <summary>
    /// מאחזר את כל הנסיעות הזמינות במאגר.
    /// </summary>
    Task<IEnumerable<Ride>> GetAllRidesAsync(); // מאחזר את כל הנסיעות.

    /// <summary>
    /// מאחזר נסיעה לפי המזהה שלה.
    /// </summary>
    Task<Ride?> GetRideByIdAsync(int id); // מאחזר נסיעה לפי המזהה שלה.

    /// <summary>
    /// מוסיף נסיעה חדשה.
    /// </summary>
    Task AddRideAsync(Ride ride); // יוצר נסיעה באמצעות פעולת ההוספה המשותפת.

    /// <summary>
    /// מעדכן נסיעה קיימת.
    /// </summary>
    Task UpdateRideAsync(Ride ride); // מעדכן את הנסיעה שזוהתה לפי המזהה שלה.

    /// <summary>
    /// מוחק נסיעה לפי המזהה שלה.
    /// </summary>
    Task DeleteRideAsync(int id); // מוחק את הנסיעה לפי המזהה שלה.
}