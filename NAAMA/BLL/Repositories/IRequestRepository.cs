using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Repositories; // משייך את הקוד למרחב השמות BLL.Repositories.

/// <summary>
/// מגדיר פעולות גישה לבקשות וחיפוש בקשות העונות לדרישות הרכב.
/// </summary>
public interface IRequestRepository : IEntityRepository<Request, string> // מגדיר את חוזה הפעולות של IRequestRepository.
{
    /// <summary>
    /// מחפש בקשות התואמות למאפייני תא המטען, העגלה ומושבי הילדים.
    /// </summary>
    Task<IReadOnlyList<Request>> FindMatchingAsync(bool hasTrunk, bool fitsStroller, bool childSeats); // מחפש בקשות שכל דרישות הרכב שלהן מתקיימות.
}
