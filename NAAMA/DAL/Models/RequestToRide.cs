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
    /// מייצג קשר בין בקשת משתמש לבין נסיעה.
    /// </summary>
    public class RequestToRide
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]
        // מזהה הקישור בין בקשת המשתמש לנסיעה.
        public string RequestToRideId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("Request")]

        // מזהה בקשת הנסיעה.
        public string RequestId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("RideRequests")]

        // מזהה הנסיעה שאליה מתייחסים.
        public string RideId { get; set; }
    }
}
