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
    /// מייצג נסיעה שפורסמה במערכת ואת מאפייניה.
    /// </summary>
    public class Ride
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]

        // מזהה הנסיעה שאליה מתייחסים.
        public int RideId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("Users")]

        // מזהה הנהג.
        public int DriverId { get; set; }

        // נקודת המוצא של הנסיעה.
        public string Origin { get; set; }

        // שם או תיאור נקודת היעד.
        public string DestinationName { get; set; }
        // קו הרוחב של נקודת היעד.
        public decimal DestinationLat { get; set; }

        // מועד יציאת הנסיעה.
        public DateTime DepartureTime { get; set; }

        // האם הנסיעה מתקיימת באופן חוזר.
        public bool IsRecurring { get; set; }

        // מספר המושבים המרבי הזמין בנסיעה.
        public int MaxSeats { get; set; }

        // המצב הנוכחי או המבוקש של הרשומה.
        public int Status { get; set; }
    }
}
