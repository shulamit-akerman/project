using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.
using Microsoft.EntityFrameworkCore; // מייבא את מרחב השמות Microsoft.EntityFrameworkCore כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים לקשרים בין בקשות לכלי רכב.
/// </summary>
public sealed class RequestToVehiclesRepository(AppDbContext context) // מגדיר את הטיפוס RequestToVehiclesRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<RequestToVehicles, string>(context), IRequestToVehiclesRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    private readonly AppDbContext _context = context; // שומר את הקשר מסד הנתונים המשמש להרצת השאילתות.

    public Task<RequestToVehicles?> GetByIdAsync(string id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<RequestToVehicles>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.

    public async Task<IReadOnlyList<RequestToVehicles>> GetByVehicleIdAsync(string vehicleId) // מאחזר את קשרי הבקשות של כלי הרכב שצוין.
    {
        return await _context.RequestToVehicle // ממתין להשלמת הפעולה האסינכרונית ומחזיר את התוצאה.
            .AsNoTracking() // מריץ שאילתת קריאה בלבד בלי לעקוב אחר הישויות שהוחזרו.
            .Where(relation => relation.VehicleId == vehicleId) // מסנן קשרים לפי מזהה כלי הרכב המבוקש.
            .ToListAsync(); // מריץ את השאילתה ומממש את התוצאות לרשימה.
    }

    public Task<RequestToVehicles> AddAsync(RequestToVehicles entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(string id, RequestToVehicles entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(string id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
