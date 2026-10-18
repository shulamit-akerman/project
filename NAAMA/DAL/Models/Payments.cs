// ייבוא טיפוסים בסיסיים של .NET, כגון תאריך ושעה.
using System;
// ייבוא אוספים גנריים של .NET.
using System.Collections.Generic;
// ייבוא פעולות שאילתת LINQ.
using System.Linq;
// ייבוא כלי עבודה למחרוזות ולקידוד טקסט.
using System.Text;
// ייבוא טיפוסים לביצוע פעולות אסינכרוניות.
using System.Threading.Tasks;
// ייבוא מאפייני אימות ומיפוי, כגון Key.
using System.ComponentModel.DataAnnotations;
// ייבוא מאפייני מיפוי לסכמת מסד הנתונים, כגון ForeignKey.
using System.ComponentModel.DataAnnotations.Schema;
// הגדרת מרחב השמות DAL.Models כדי לשייך את הטיפוסים למודול המתאים.
namespace DAL.Models
{
    /// <summary>
    /// מייצג תשלום הקשור להזמנה ואת פרטי הסטטוס והזמן שלו.
    /// </summary>
    public class Payments
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]

        // מזהה רשומת התשלום.
        public int PaymentsId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("Bookings")]

        // מזהה ההזמנה.
        public int BookingId { get; set; }

        // סכום התשלום.
        public decimal Amount { get; set; }

        // סוג אמצעי התשלום.
        public int PaymentType { get; set; }

        // מצב התשלום.
        public int PaymentStatus { get; set; }

        // שלב התשלום.
        public int PaymentStage { get; set; }
        // מועד יצירת פרטי התשלום.
        public DateTime CreateAt { get; set; }
    }
}
