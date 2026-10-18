using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.
using Microsoft.EntityFrameworkCore; // מייבא את מרחב השמות Microsoft.EntityFrameworkCore כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים עבור הודעות המשויכות להזמנות.
/// </summary>
public sealed class MassageToBookingRepository(AppDbContext context) // מגדיר את הטיפוס MassageToBookingRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<MassageToBooking, int>(context), IMassageToBookingRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    private readonly AppDbContext _context = context; // שומר את הקשר מסד הנתונים המשמש להרצת השאילתות.

    public Task<MassageToBooking?> GetByIdAsync(int id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<MassageToBooking>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.

    public async Task<IReadOnlyList<MassageToBooking>> GetByBookingIdAsync(int bookingId) // מאחזר הודעות המקושרות להזמנה שצוינה.
    {
        return await _context.MassageToBookings // ממתין להשלמת הפעולה האסינכרונית ומחזיר את התוצאה.
            .AsNoTracking() // מריץ שאילתת קריאה בלבד בלי לעקוב אחר הישויות שהוחזרו.
            .Where(message => message.BookingId == bookingId) // מסנן את התוצאות לפי מזהה ההזמנה המבוקש.
            .ToListAsync(); // מריץ את השאילתה ומממש את התוצאות לרשימה.
    }

    public Task<MassageToBooking> AddAsync(MassageToBooking entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(int id, MassageToBooking entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(int id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
