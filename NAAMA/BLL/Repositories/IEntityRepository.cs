using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// חוזה גנרי לפעולות הגישה לנתונים עבור ישות ומפתח.
/// </summary>
public interface IEntityRepository<TEntity, TKey> // מגדיר את חוזה הפעולות של IEntityRepository.
    where TEntity : class // מגביל את הטיפוס הגנרי לישות שהיא טיפוס הפניה.
    where TKey : notnull // מבטיח שהמפתח הגנרי לא יוכל לקבל ערך null.
{
    Task<TEntity?> GetByIdAsync(TKey id); // מאחזר את הרשומה לפי המזהה שסופק.
    Task<IReadOnlyList<TEntity>> GetAllAsync(); // מאחזר את כל הרשומות מסוג זה.
    Task<TEntity> AddAsync(TEntity entity); // מוסיף רשומה חדשה למאגר.
    Task UpdateAsync(TKey id, TEntity entity); // מעדכן רשומה לפי המפתח שסופק.
    Task DeleteAsync(TKey id); // מוחק רשומה לפי המפתח שסופק.
}
