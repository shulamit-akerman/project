using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מנהל תשלומים, כולל אתחול פרטי תשלום ושליפת התשלום האחרון להזמנה.
    /// </summary>
    public class PaymentService : EntityService<Payments, int>, IPaymentService // מגדיר את הטיפוס PaymentService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IPaymentRepository _repository; // שומר את מאגר הנתונים שבו השירות משתמש.

        public PaymentService(IPaymentRepository repository) // מאתחל מופע של PaymentService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _repository = repository; // שומר את המאגר שהועבר לבנאי לשימוש פעולות השירות.
        }

        public override Task<Payments> InsertAsync(Payments payment) // מוסיף ושומר רשומה חדשה.
        {
            ArgumentNullException.ThrowIfNull(payment); // מוודא שהערך payment אינו null, לפני שימוש בו.
            payment.PaymentStatus = 0; // מאתחל את מצב התשלום לערך הראשוני.
            payment.CreateAt = DateTime.UtcNow; // קובע את מועד יצירת התשלום לפי שעון UTC.
            return base.InsertAsync(payment); // מחזיר את משימת ההוספה דרך השירות הבסיסי.
        }

        public Task<Payments?> GetPaymentByBookingIdAsync(int bookingId) => // מאחזר את התשלום האחרון של ההזמנה הנתונה.
            _repository.GetLatestByBookingIdAsync(bookingId); // מבצע את הפעולה המוצהרת בשורה זו.

        public async Task ProcessPaymentAsync(Payments payment) // מאתחל את פרטי התשלום החסרים ושומר אותו במאגר.
        {
            ArgumentNullException.ThrowIfNull(payment); // מוודא שהערך payment אינו null, לפני שימוש בו.

            if (payment.CreateAt == default) // בודק אם לא הוגדר עדיין מועד יצירה.
            {
                payment.CreateAt = DateTime.UtcNow; // קובע את מועד יצירת התשלום לפי שעון UTC.
            }

            await _repository.AddAsync(payment); // ממתין להוספת הרשומה למאגר ולשמירתה.
        }
    }
}