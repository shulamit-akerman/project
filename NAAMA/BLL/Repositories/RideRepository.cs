using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים עבור נסיעות.
/// </summary>
public sealed class RideRepository(AppDbContext context) // מגדיר את הטיפוס RideRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<Ride, int>(context), IRideRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    public Task<Ride?> GetByIdAsync(int id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<Ride>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.
    public Task<Ride> AddAsync(Ride entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(int id, Ride entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(int id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
