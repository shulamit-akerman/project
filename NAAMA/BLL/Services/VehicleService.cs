using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מרכז פעולות CRUD לכלי רכב וחיפושים הקשורים לנהגים.
    /// </summary>
    public class VehicleService : EntityService<Vehicle, int>, IVehicleService // מגדיר את הטיפוס VehicleService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IVehicleRepository _repository; // שומר את מאגר הנתונים שבו השירות משתמש.

        public VehicleService(IVehicleRepository repository) // מאתחל מופע של VehicleService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _repository = repository; // שומר את המאגר שהועבר לבנאי לשימוש פעולות השירות.
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByDriverAsync(int driverId) => // מאחזר את כלי הרכב של הנהג הנתון.
            await _repository.GetByDriverIdAsync(driverId); // ממתין להשלמת הפעולה האסינכרונית לפני ההמשך.

        public async Task AddVehicleAsync(Vehicle vehicle) // יוצר כלי רכב באמצעות פעולת ההוספה המשותפת.
        {
            await InsertAsync(vehicle); // מוסיף ושומר רשומה חדשה.
        }
    }
}