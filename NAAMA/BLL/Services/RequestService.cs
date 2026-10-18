using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מנהל בקשות נסיעה ואת תהליך ההתאמה שלהן לדרישות רכב.
    /// </summary>
    public class RequestService : EntityService<Request, string>, IRequestService // מגדיר את הטיפוס RequestService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IRequestRepository _repository; // שומר את מאגר הנתונים שבו השירות משתמש.

        public RequestService(IRequestRepository repository) // מאתחל מופע של RequestService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _repository = repository; // שומר את המאגר שהועבר לבנאי לשימוש פעולות השירות.
        }

        public override Task<Request> InsertAsync(Request request) // מוסיף ושומר רשומה חדשה.
        {
            ArgumentNullException.ThrowIfNull(request); // מוודא שהערך request אינו null, לפני שימוש בו.
            request.RequestId = Guid.NewGuid().ToString("N"); // יוצר לבקשה מזהה חדש בפורמט N ללא מפרידים.
            return base.InsertAsync(request); // מחזיר את משימת ההוספה דרך השירות הבסיסי.
        }

        public Task<Request?> GetRequestByIdAsync(string requestId) => _repository.GetByIdAsync(requestId); // מאחזר בקשת נסיעה לפי המזהה שלה.

        public async Task AddRequestAsync(Request request) // יוצר בקשה באמצעות פעולת ההוספה המשותפת.
        {
            await InsertAsync(request); // מוסיף ושומר רשומה חדשה.
        }

        public Task UpdateRequestAsync(Request request) => UpdateAsync(request.RequestId, request); // מעדכן את הבקשה שזוהתה לפי המזהה שלה.

        public async Task<IEnumerable<Request>> FindMatchingRequestsAsync( // מחפש בקשות שכל דרישות הרכב שלהן מתקיימות.
            bool hasTrunk, // מגדיר פרמטר המספק את הנתון הדרוש לפעולה.
            bool fitsStroller, // מגדיר פרמטר המספק את הנתון הדרוש לפעולה.
            bool childSeats) // מגדיר פרמטר המספק את הנתון הדרוש לפעולה.
        {
            return await _repository.FindMatchingAsync(hasTrunk, fitsStroller, childSeats); // ממתין להשלמת הפעולה האסינכרונית ומחזיר את התוצאה.
        }
    }
}