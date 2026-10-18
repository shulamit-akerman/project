using BLL.Repositories; // מייבא את מרחב השמות BLL.Repositories כדי להשתמש בטיפוסים ובפעולות שלו.
using DAL.Models; // מייבא את מרחב השמות DAL.Models כדי להשתמש בטיפוסים ובפעולות שלו.

namespace BLL.Services // משייך את הקוד למרחב השמות BLL.Services.
{
    /// <summary>
    /// מרכז פעולות CRUD ותהליכים ייעודיים להזמנות.
    /// </summary>
    public class BookingService : EntityService<Booking, int>, IBookingService // מגדיר את הטיפוס BookingService ואת אחריותו בשכבת הלוגיקה.
    {
        private readonly IBookingRepository _repository; // שומר את מאגר הנתונים שבו השירות משתמש.

        public BookingService(IBookingRepository repository) // מאתחל מופע של BookingService עם התלות שנמסרה לבנאי.
            : base(repository) // מעביר את התלות לבנאי מחלקת הבסיס לצורך הפעולות המשותפות.
        {
            _repository = repository; // שומר את המאגר שהועבר לבנאי לשימוש פעולות השירות.
        }

        public Task<Booking?> GetBookingByIdAsync(int id) => _repository.GetByIdAsync(id); // מכריז על הפעולה GetBookingByIdAsync ועל הפרמטרים והטיפוס שהיא מחזירה.

        public async Task CreateBookingAsync(Booking booking) // יוצר הזמנה חדשה ושומר אותה.
        {
            await InsertAsync(booking); // מוסיף ושומר רשומה חדשה.
        }
    }
}