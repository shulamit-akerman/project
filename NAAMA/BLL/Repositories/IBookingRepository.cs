using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה לנתונים עבור הזמנות.
/// </summary>
public interface IBookingRepository : IEntityRepository<Booking, int> // מגדיר את חוזה הפעולות של IBookingRepository.
{
}
