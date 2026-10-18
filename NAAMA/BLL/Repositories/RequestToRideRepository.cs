using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.
using Microsoft.EntityFrameworkCore; // מייבא את מרחב השמות Microsoft.EntityFrameworkCore כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים לקשרים בין בקשות לנסיעות.
/// </summary>
public sealed class RequestToRideRepository(AppDbContext context) // מגדיר את הטיפוס RequestToRideRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<RequestToRide, string>(context), IRequestToRideRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    private readonly AppDbContext _context = context; // שומר את הקשר מסד הנתונים המשמש להרצת השאילתות.

    public Task<RequestToRide?> GetByIdAsync(string id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<RequestToRide>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.

    public async Task<IReadOnlyList<RequestToRide>> GetByRideIdAsync(string rideId) // מאחזר את קשרי הבקשות של הנסיעה שצוינה.
    {
        return await _context.RequestToRides // ממתין להשלמת הפעולה האסינכרונית ומחזיר את התוצאה.
            .AsNoTracking() // מריץ שאילתת קריאה בלבד בלי לעקוב אחר הישויות שהוחזרו.
            .Where(relation => relation.RideId == rideId) // מסנן קשרים לפי מזהה הנסיעה המבוקש.
            .ToListAsync(); // מריץ את השאילתה ומממש את התוצאות לרשימה.
    }

    public Task<RequestToRide> AddAsync(RequestToRide entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(string id, RequestToRide entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(string id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
