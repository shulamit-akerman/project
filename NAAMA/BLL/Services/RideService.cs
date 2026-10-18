using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מנהל נסיעות ומאתחל את מצבן בעת יצירת נסיעה חדשה.
    /// </summary>
    public class RideService : EntityService<Ride, int>, IRideService // מגדיר את הטיפוס RideService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IRideRepository _repository; // שומר את מאגר הנתונים שבו השירות משתמש.

        public RideService(IRideRepository repository) // מאתחל מופע של RideService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _repository = repository; // שומר את המאגר שהועבר לבנאי לשימוש פעולות השירות.
        }

        public override Task<Ride> InsertAsync(Ride ride) // מוסיף ושומר רשומה חדשה.
        {
            ArgumentNullException.ThrowIfNull(ride); // מוודא שהערך ride אינו null, לפני שימוש בו.
            ride.Status = 0; // מאתחל את מצב הנסיעה לערך הראשוני.
            return base.InsertAsync(ride); // מחזיר את משימת ההוספה דרך השירות הבסיסי.
        }

        public async Task<IEnumerable<Ride>> GetAllRidesAsync() => await _repository.GetAllAsync(); // מאחזר את כל הנסיעות.

        public Task<Ride?> GetRideByIdAsync(int id) => _repository.GetByIdAsync(id); // מאחזר נסיעה לפי המזהה שלה.

        public async Task AddRideAsync(Ride ride) // יוצר נסיעה באמצעות פעולת ההוספה המשותפת.
        {
            await InsertAsync(ride); // מוסיף ושומר רשומה חדשה.
        }

        public Task UpdateRideAsync(Ride ride) => UpdateAsync(ride.RideId, ride); // מעדכן את הנסיעה שזוהתה לפי המזהה שלה.

        public Task DeleteRideAsync(int id) => DeleteAsync(id); // מוחק את הנסיעה לפי המזהה שלה.
    }
}