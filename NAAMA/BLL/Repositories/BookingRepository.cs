using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים עבור הזמנות.
/// </summary>
public sealed class BookingRepository(AppDbContext context) // מגדיר את הטיפוס BookingRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<Booking, int>(context), IBookingRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    public Task<Booking?> GetByIdAsync(int id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<Booking>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.
    public Task<Booking> AddAsync(Booking entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(int id, Booking entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(int id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
