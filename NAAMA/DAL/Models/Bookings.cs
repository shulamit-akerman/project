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
    /// מייצג הזמנה ואת הקשרים שלה למשתמשים ולנסיעה.
    /// </summary>
    public class Booking
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]

        // מזהה ההזמנה.
        public int BookingId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("RideRequest")]

        // מזהה בקשת הנסיעה.
        public int RequestId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("Rides")]

        // מזהה הנסיעה שאליה מתייחסים.
        public int RideId { get; set; }
        // מספר הסדר של מקטע הנסיעה.
        public int LegSequence {  get; set; }

        // נקודת האיסוף שנבחרה.
        public string PickupPoint { get; set; }

        // המצב הנוכחי או המבוקש של הרשומה.
        public int Status { get; set; }

        // הסכום הכולל לתשלום עבור ההזמנה.
        public decimal TotalAmount { get; set; }
        // סכום המקדמה ששולמה או נדרשת.
        public decimal AdvanceAmount { get; set; }
        // יתרת הסכום שנותרה לתשלום.
        public decimal ReminingAmount { get; set; }
    }
}
