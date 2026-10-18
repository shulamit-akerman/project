using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מנהל בקשות לנסיעה ומגדיר להן מצב וזמן בעת יצירתן.
    /// </summary>
    public class RideRequestService : EntityService<RideRequest, int>, IRideRequestService // מגדיר את הטיפוס RideRequestService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IRideRequestRepository _repository; // שומר את מאגר הנתונים שבו השירות משתמש.

        public RideRequestService(IRideRequestRepository repository) // מאתחל מופע של RideRequestService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _repository = repository; // שומר את המאגר שהועבר לבנאי לשימוש פעולות השירות.
        }

        public override Task<RideRequest> InsertAsync(RideRequest request) // מוסיף ושומר רשומה חדשה.
        {
            ArgumentNullException.ThrowIfNull(request); // מוודא שהערך request אינו null, לפני שימוש בו.
            request.RequestedTime = DateTime.UtcNow; // קובע את מועד הגשת הבקשה לפי שעון UTC.
            request.Status = 0; // מאתחל את מצב בקשת ההצטרפות לערך הראשוני.
            return base.InsertAsync(request); // מחזיר את משימת ההוספה דרך השירות הבסיסי.
        }

        public Task<RideRequest?> GetRequestByIdAsync(int id) => _repository.GetByIdAsync(id); // מאחזר בקשת נסיעה לפי המזהה שלה.

        public async Task CreateRideRequestAsync(RideRequest request) // יוצר בקשה חדשה להצטרפות לנסיעה ושומר אותה.
        {
            await InsertAsync(request); // מוסיף ושומר רשומה חדשה.
        }
    }
}