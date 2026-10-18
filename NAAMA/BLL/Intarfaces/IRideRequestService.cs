using System.Threading.Tasks; // מייבא את מרחב השמות System.Threading.Tasks כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// מטפל בבקשות לנסיעה ובפעולות הייעודיות ליצירתן ולשליפתן.
/// </summary>
public interface IRideRequestService : IEntityService<RideRequest, int> // מגדיר את חוזה הפעולות של IRideRequestService.
{
    /// <summary>
    /// מאחזר בקשת נסיעה לפי המזהה שלה.
    /// </summary>
    Task<RideRequest?> GetRequestByIdAsync(int id); // מאחזר בקשת נסיעה לפי המזהה שלה.

    /// <summary>
    /// יוצר בקשת הצטרפות לנסיעה.
    /// </summary>
    Task CreateRideRequestAsync(RideRequest request); // יוצר בקשה חדשה להצטרפות לנסיעה ושומר אותה.
}