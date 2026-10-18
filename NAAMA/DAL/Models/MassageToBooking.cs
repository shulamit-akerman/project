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
    /// מייצג הודעה המשויכת להזמנה מסוימת.
    /// </summary>
    public class MassageToBooking
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]
        // מזהה הקישור בין ההודעה להזמנה.
        public int MassageToBookingId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("ChatMassages")]
        // מזהה הודעת הצ׳אט המקושרת.
        public int MassageId { get; set;}
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("Booking")]

        // מזהה ההזמנה.
        public int BookingId { get; set;}
    }
}
