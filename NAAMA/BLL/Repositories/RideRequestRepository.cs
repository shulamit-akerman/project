using DAL; // מייבא את מרחב השמות DAL כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מבצע פעולות מסד נתונים עבור בקשות להצטרפות לנסיעה.
/// </summary>
public sealed class RideRequestRepository(AppDbContext context) // מגדיר את הטיפוס RideRequestRepository ואת אחריותו בשכבת הלוגיקה.
    : EntityRepository<RideRequest, int>(context), IRideRequestRepository // יורש את פעולות המאגר הגנריות ומממש את חוזה המאגר המסוים.
{
    public Task<RideRequest?> GetByIdAsync(int id) => FindByIdAsync(id); // מאחזר את הרשומה לפי המזהה שסופק.
    public Task<IReadOnlyList<RideRequest>> GetAllAsync() => ListAsync(); // מאחזר את כל הרשומות מסוג זה.
    public Task<RideRequest> AddAsync(RideRequest entity) => InsertAsync(entity); // מוסיף רשומה חדשה למאגר.
    public Task UpdateAsync(int id, RideRequest entity) => SaveUpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.
    public Task DeleteAsync(int id) => RemoveAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
