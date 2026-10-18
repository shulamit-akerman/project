using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה לנתונים עבור משתמשים.
/// </summary>
public interface IUserRepository : IEntityRepository<Users, int> // מגדיר את חוזה הפעולות של IUserRepository.
{
}
