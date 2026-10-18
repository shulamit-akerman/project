using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים עבור משתמשים.
/// </summary>
public sealed class UserRepository(AppDbContext context) // מגדיר את הטיפוס UserRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<Users, int>(context), IUserRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    public Task<Users?> GetByIdAsync(int id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<Users>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.
    public Task<Users> AddAsync(Users entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(int id, Users entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(int id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
