using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מנהל קשרים בין בקשות לנסיעות ומאפשר לאחזר קשרים לפי נסיעה.
    /// </summary>
    public class RequestToRideService : EntityService<RequestToRide, string>, IRequestToRideService // מגדיר את הטיפוס RequestToRideService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IRequestToRideRepository _repository; // שומר את מאגר הנתונים שבו השירות משתמש.

        public RequestToRideService(IRequestToRideRepository repository) // מאתחל מופע של RequestToRideService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _repository = repository; // שומר את המאגר שהועבר לבנאי לשימוש פעולות השירות.
        }

        public override Task<RequestToRide> InsertAsync(RequestToRide relation) // מוסיף ושומר רשומה חדשה.
        {
            ArgumentNullException.ThrowIfNull(relation); // מוודא שהערך relation אינו null, לפני שימוש בו.
            relation.RequestToRideId = Guid.NewGuid().ToString("N"); // יוצר לקשר בין בקשה לנסיעה מזהה חדש בפורמט N.
            return base.InsertAsync(relation); // מחזיר את משימת ההוספה דרך השירות הבסיסי.
        }

        public async Task AddAsync(RequestToRide relation) // מוסיף רשומה חדשה למאגר.
        {
            await InsertAsync(relation); // מוסיף ושומר רשומה חדשה.
        }

        public async Task<IEnumerable<RequestToRide>> GetByRideIdAsync(string rideId) // מאחזר את קשרי הבקשות של הנסיעה שצוינה.
        {
            return await _repository.GetByRideIdAsync(rideId); // ממתין להשלמת הפעולה האסינכרונית ומחזיר את התוצאה.
        }
    }
}