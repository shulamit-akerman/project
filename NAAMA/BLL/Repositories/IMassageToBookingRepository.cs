using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה להודעות המשויכות להזמנות.
/// </summary>
public interface IMassageToBookingRepository : IEntityRepository<MassageToBooking, int> // מגדיר את חוזה הפעולות של IMassageToBookingRepository.
{
    /// <summary>
    /// מאחזר את כל ההודעות השייכות להזמנה מסוימת.
    /// </summary>
    Task<IReadOnlyList<MassageToBooking>> GetByBookingIdAsync(int bookingId); // מאחזר הודעות המקושרות להזמנה שצוינה.
}
