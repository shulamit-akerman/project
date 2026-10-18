using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה לתשלומים וחיפוש התשלום האחרון להזמנה.
/// </summary>
public interface IPaymentRepository : IEntityRepository<Payments, int> // מגדיר את חוזה הפעולות של IPaymentRepository.
{
    /// <summary>
    /// מאחזר את התשלום האחרון שנרשם עבור הזמנה מסוימת.
    /// </summary>
    Task<Payments?> GetLatestByBookingIdAsync(int bookingId); // מאחזר את התשלום האחרון להזמנה לפי מועד יצירתו.
}
