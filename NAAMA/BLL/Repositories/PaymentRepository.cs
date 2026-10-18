using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.
using Microsoft.EntityFrameworkCore; // מייבא את מרחב השמות Microsoft.EntityFrameworkCore כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים לתשלומים ולשליפת התשלום האחרון להזמנה.
/// </summary>
public sealed class PaymentRepository(AppDbContext context) // מגדיר את הטיפוס PaymentRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<Payments, int>(context), IPaymentRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    private readonly AppDbContext _context = context; // שומר את הקשר מסד הנתונים המשמש להרצת השאילתות.

    public Task<Payments?> GetByIdAsync(int id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<Payments>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.

    public Task<Payments?> GetLatestByBookingIdAsync(int bookingId) // מאחזר את התשלום האחרון להזמנה לפי מועד יצירתו.
    {
        return _context.Payments // מחזיר את הערך שחושב או את תוצאת הפעולה.
            .AsNoTracking() // מריץ שאילתת קריאה בלבד בלי לעקוב אחר הישויות שהוחזרו.
            .Where(payment => payment.BookingId == bookingId) // מסנן את התוצאות לפי מזהה ההזמנה המבוקש.
            .OrderByDescending(payment => payment.CreateAt) // ממיין תשלומים לפי מועד היצירה בסדר יורד, מהחדש לישן.
            .FirstOrDefaultAsync(); // מחזיר את התוצאה הראשונה או ערך null כשלא נמצאה תוצאה.
    }

    public Task<Payments> AddAsync(Payments entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(int id, Payments entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(int id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
