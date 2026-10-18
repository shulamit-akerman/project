using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using Microsoft.EntityFrameworkCore; // מייבא את מרחב השמות Microsoft.EntityFrameworkCore כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מממש פעולות גישה גנריות לישות באמצעות Entity Framework Core.
/// </summary>
public abstract class EntityRepository<TEntity, TKey> // מגדיר את הטיפוס EntityRepository ואת אחריותו בשכבת הלוגיקה.
    where TEntity : class // מגביל את הטיפוס הגנרי לישות שהיא טיפוס הפניה.
    where TKey : notnull // מבטיח שהמפתח הגנרי לא יוכל לקבל ערך null.
{
    private readonly DbSet<TEntity> _entities; // שומר את קבוצת הישויות מטיפוס זה בהקשר מסד הנתונים.
    private readonly AppDbContext _context; // שומר את הקשר מסד הנתונים המשמש להרצת השאילתות.

    protected EntityRepository(AppDbContext context) // מאתחל מופע של EntityRepository עם התלות שנמסרה לבנאי.
    {
        _context = context; // שומר את הקשר מסד הנתונים שהועבר לבנאי.
        _entities = context.Set<TEntity>(); // שומר את קבוצת הישויות המתאימה לטיפוס מתוך ההקשר.
    }

    protected Task<TEntity?> FindByIdAsync(TKey id) // מחפש ישות לפי המפתח ומחזיר משימה עם הישות או null אם אינה קיימת.
    {
        return _entities.FindAsync(new object?[] { id }).AsTask(); // מחזיר את הרשומה שנמצאה לפי המפתח.
    }

    protected async Task<IReadOnlyList<TEntity>> ListAsync() // מאחזר את כל הישויות ללא מעקב ומחזיר אותן כרשימה לקריאה בלבד.
    {
        return await _entities.AsNoTracking().ToListAsync(); // מריץ שאילתת קריאה בלבד בלי לעקוב אחר הישויות שהוחזרו.
    }

    protected async Task<TEntity> InsertAsync(TEntity entity) // מוסיף את הישות למאגר, שומר את השינוי ומחזיר אותה.
    {
        ArgumentNullException.ThrowIfNull(entity); // מוודא שהערך entity אינו null, לפני שימוש בו.

        await _entities.AddAsync(entity); // מוסיף את הישות החדשה לקבוצת הישויות של EF Core.
        await _context.SaveChangesAsync(); // שומר במסד הנתונים את השינויים שבוצעו בהקשר.
        return entity; // מחזיר את הערך שחושב או את תוצאת הפעולה.
    }

    protected async Task SaveUpdateAsync(TKey id, TEntity entity) // מעדכן את הישות המזוהה במפתח ושומר את השינויים.
    {
        ArgumentNullException.ThrowIfNull(entity); // מוודא שהערך entity אינו null, לפני שימוש בו.

        var existingEntity = await FindByIdAsync(id); // טוען את הישות הקיימת לפי המזהה כדי לעדכן אותה.
        if (existingEntity is null) // בודק אם הרשומה לא נמצאה במאגר.
        {
            throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID '{id}' was not found."); // זורק חריגה שמציינת כי הישות בעלת המפתח הנתון אינה קיימת.
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity); // מעתיק את ערכי הישות החדשה אל הישות הקיימת שבמעקב EF Core.
        await _context.SaveChangesAsync(); // שומר במסד הנתונים את השינויים שבוצעו בהקשר.
    }

    protected async Task RemoveAsync(TKey id) // מאתר את הישות לפי המפתח, מסיר אותה ושומר את השינוי.
    {
        var entity = await FindByIdAsync(id); // טוען את הישות לפי המזהה לפני בדיקת קיומה ומחיקתה.
        if (entity is null) // בודק אם הרשומה לא נמצאה במאגר.
        {
            throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID '{id}' was not found."); // זורק חריגה שמציינת כי הישות בעלת המפתח הנתון אינה קיימת.
        }

        _entities.Remove(entity); // מסמן את הישות הקיימת למחיקה ממסד הנתונים.
        await _context.SaveChangesAsync(); // שומר במסד הנתונים את השינויים שבוצעו בהקשר.
    }
}
