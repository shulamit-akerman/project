using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.
using Microsoft.EntityFrameworkCore; // מייבא את מרחב השמות Microsoft.EntityFrameworkCore כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים לכלי רכב ולחיפוש לפי הנהג.
/// </summary>
public sealed class VehicleRepository(AppDbContext context) // מגדיר את הטיפוס VehicleRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<Vehicle, int>(context), IVehicleRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    private readonly AppDbContext _context = context; // שומר את הקשר מסד הנתונים המשמש להרצת השאילתות.

    public Task<Vehicle?> GetByIdAsync(int id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<Vehicle>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.

    public async Task<IReadOnlyList<Vehicle>> GetByDriverIdAsync(int driverId) // מאחזר את כלי הרכב המשויכים לנהג שצוין.
    {
        return await _context.Vehicles // ממתין להשלמת הפעולה האסינכרונית ומחזיר את התוצאה.
            .AsNoTracking() // מריץ שאילתת קריאה בלבד בלי לעקוב אחר הישויות שהוחזרו.
            .Where(vehicle => vehicle.DriverId == driverId) // מסנן כלי רכב לפי מזהה הנהג המבוקש.
            .ToListAsync(); // מריץ את השאילתה ומממש את התוצאות לרשימה.
    }

    public Task<Vehicle> AddAsync(Vehicle entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(int id, Vehicle entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(int id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
