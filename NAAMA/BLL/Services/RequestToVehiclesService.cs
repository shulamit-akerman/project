using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מנהל קשרים בין בקשות לכלי רכב ומאפשר לאחזר קשרים לפי רכב.
    /// </summary>
    public class RequestToVehiclesService : EntityService<RequestToVehicles, string>, IRequestToVehiclesService // מגדיר את הטיפוס RequestToVehiclesService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IRequestToVehiclesRepository _repository; // שומר את מאגר הנתונים שבו השירות משתמש.

        public RequestToVehiclesService(IRequestToVehiclesRepository repository) // מאתחל מופע של RequestToVehiclesService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _repository = repository; // שומר את המאגר שהועבר לבנאי לשימוש פעולות השירות.
        }

        public override Task<RequestToVehicles> InsertAsync(RequestToVehicles relation) // מוסיף ושומר רשומה חדשה.
        {
            ArgumentNullException.ThrowIfNull(relation); // מוודא שהערך relation אינו null, לפני שימוש בו.
            relation.RequestToVehiclesId = Guid.NewGuid().ToString("N"); // יוצר לקשר בין בקשה לרכב מזהה חדש בפורמט N.
            return base.InsertAsync(relation); // מחזיר את משימת ההוספה דרך השירות הבסיסי.
        }

        public async Task AddAsync(RequestToVehicles relation) // מוסיף רשומה חדשה למאגר.
        {
            await InsertAsync(relation); // מוסיף ושומר רשומה חדשה.
        }

        public async Task<IEnumerable<RequestToVehicles>> GetByVehicleIdAsync(string vehicleId) // מאחזר את קשרי הבקשות של כלי הרכב שצוין.
        {
            return await _repository.GetByVehicleIdAsync(vehicleId); // ממתין להשלמת הפעולה האסינכרונית ומחזיר את התוצאה.
        }
    }
}