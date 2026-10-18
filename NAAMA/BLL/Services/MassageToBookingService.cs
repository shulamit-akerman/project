using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מנהל הודעות המשויכות להזמנות ומאפשר לאחזר אותן לפי הזמנה.
    /// </summary>
    public class MassageToBookingService : EntityService<MassageToBooking, int>, IMassageToBookingService // מגדיר את הטיפוס MassageToBookingService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IMassageToBookingRepository _repository; // שומר את מאגר הנתונים שבו השירות משתמש.

        public MassageToBookingService(IMassageToBookingRepository repository) // מאתחל מופע של MassageToBookingService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _repository = repository; // שומר את המאגר שהועבר לבנאי לשימוש פעולות השירות.
        }

        public async Task AddAsync(MassageToBooking massageToBooking) // מוסיף רשומה חדשה למאגר.
        {
            await InsertAsync(massageToBooking); // מוסיף ושומר רשומה חדשה.
        }

        public async Task<IEnumerable<MassageToBooking>> GetMessagesByBookingIdAsync(int bookingId) // מאחזר את הודעות ההזמנה לפי מזהה ההזמנה.
        {
            return await _repository.GetByBookingIdAsync(bookingId); // ממתין להשלמת הפעולה האסינכרונית ומחזיר את התוצאה.
        }
    }
}