using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה לנתונים עבור בקשות הצטרפות לנסיעה.
/// </summary>
public interface IRideRequestRepository : IEntityRepository<RideRequest, int> // מגדיר את חוזה הפעולות של IRideRequestRepository.
{
}
