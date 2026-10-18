using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services; // משייך את הקוד למרחב השמות BLL.Services.

/// <summary>
/// חוזה לשירות CRUD גנרי שמפריד בין הבקרים לבין שכבת הגישה לנתונים.
/// </summary>
public interface IEntityService<TEntity, TKey> // מגדיר את חוזה הפעולות של IEntityService.
    where TEntity : class // מגביל את הטיפוס הגנרי לישות שהיא טיפוס הפניה.
    where TKey : notnull // מבטיח שהמפתח הגנרי לא יוכל לקבל ערך null.
{
    Task<TEntity?> FindAsync(TKey id); // מאחזר רשומה יחידה לפי מפתח.
    Task<IReadOnlyList<TEntity>> ListAsync(); // מאחזר את כל הרשומות.
    Task<TEntity> InsertAsync(TEntity entity); // מוסיף ושומר רשומה חדשה.
    Task UpdateAsync(TKey id, TEntity entity); // מעדכן רשומה לפי המפתח שסופק.
    Task DeleteAsync(TKey id); // מוחק רשומה לפי המפתח שסופק.
}

/// <summary>
/// מממש פעולות CRUD בסיסיות באמצעות repository ייעודי, בלי לחשוף אותו לבקר.
/// </summary>
public class EntityService<TEntity, TKey>(IEntityRepository<TEntity, TKey> repository) // מגדיר את הטיפוס EntityService ואת אחריותו בשכבת הלוגיקה.
    : IEntityService<TEntity, TKey> // מצהיר שהמחלקה מממשת את חוזה הממשק המתאים.
    where TEntity : class // מגביל את הטיפוס הגנרי לישות שהיא טיפוס הפניה.
    where TKey : notnull // מבטיח שהמפתח הגנרי לא יוכל לקבל ערך null.
{
    public Task<TEntity?> FindAsync(TKey id) => repository.GetByIdAsync(id); // מאחזר רשומה יחידה לפי מפתח.

    public Task<IReadOnlyList<TEntity>> ListAsync() => repository.GetAllAsync(); // מאחזר את כל הרשומות.

    public virtual Task<TEntity> InsertAsync(TEntity entity) => repository.AddAsync(entity); // מוסיף ושומר רשומה חדשה.

    public Task UpdateAsync(TKey id, TEntity entity) => repository.UpdateAsync(id, entity); // מעדכן רשומה לפי המפתח שסופק.

    public Task DeleteAsync(TKey id) => repository.DeleteAsync(id); // מוחק רשומה לפי המפתח שסופק.
}
