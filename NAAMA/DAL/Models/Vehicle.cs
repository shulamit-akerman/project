// ייבוא טיפוסים בסיסיים של .NET, כגון תאריך ושעה.
using System;
// ייבוא אוספים גנריים של .NET.
using System.Collections.Generic;
// ייבוא מאפייני אימות ומיפוי, כגון Key.
using System.ComponentModel.DataAnnotations;
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
    /// מייצג כלי רכב הרשום במערכת ומשויך לנהג.
    /// </summary>
    public class Vehicle
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]
        // מזהה כלי הרכב המשויך.
        public int VehicleId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey ("Users")]

        // מזהה הנהג.
        public int DriverId { get; set; }

        // מספר לוחית הרישוי של כלי הרכב.
        public string LicensePlate { get; set; }

        // דגם כלי הרכב.
        public string Model { get; set; }

        // צבע כלי הרכב.
        public string Color { get; set; }

        // מספר המושבים הפנויים.
        public int AvailableSeats { get; set; }
    }
}
