using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.
using Microsoft.EntityFrameworkCore; // מייבא את מרחב השמות Microsoft.EntityFrameworkCore כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים לבקשות ולחיפוש בקשות מתאימות.
/// </summary>
public sealed class RequestRepository(AppDbContext context) // מגדיר את הטיפוס RequestRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<Request, string>(context), IRequestRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    private readonly AppDbContext _context = context; // שומר את הקשר מסד הנתונים המשמש להרצת השאילתות.

    public Task<Request?> GetByIdAsync(string id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<Request>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.

    public async Task<IReadOnlyList<Request>> FindMatchingAsync( // מחפש בקשות שכל דרישות הרכב שלהן מתקיימות.
        bool hasTrunk, // מגדיר פרמטר המספק את הנתון הדרוש לפעולה.
        bool fitsStroller, // מגדיר פרמטר המספק את הנתון הדרוש לפעולה.
        bool childSeats) // מגדיר פרמטר המספק את הנתון הדרוש לפעולה.
    {
        return await _context.Requests // ממתין להשלמת הפעולה האסינכרונית ומחזיר את התוצאה.
            .AsNoTracking() // מריץ שאילתת קריאה בלבד בלי לעקוב אחר הישויות שהוחזרו.
            .Where(request => // מסנן את הרשומות לפי תנאי השאילתה.
                (!request.HasTrunkSpace || hasTrunk) && // משלב את תנאי ההתאמה כדי לוודא שכל הדרישות מתקיימות.
                (!request.FitsStroller || fitsStroller) && // משלב את תנאי ההתאמה כדי לוודא שכל הדרישות מתקיימות.
                (!request.HasChildSeats || childSeats)) // משלב את תנאי ההתאמה כדי לוודא שכל הדרישות מתקיימות.
            .ToListAsync(); // מריץ את השאילתה ומממש את התוצאות לרשימה.
    }

    public Task<Request> AddAsync(Request entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(string id, Request entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(string id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
