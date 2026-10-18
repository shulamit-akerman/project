// ייבוא טיפוסי הגירה של Entity Framework Core.
using Microsoft.EntityFrameworkCore.Migrations;
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
    /// מייצג בקשה של משתמש להצטרף לנסיעה ואת מצבה.
    /// </summary>
    public class RideRequest
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]

        // מזהה בקשת הנסיעה.
        public int RequestId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("Users")]

        // מזהה הנוסע.
        public int PassengerId { get; set; }

        // שם או תיאור נקודת האיסוף.
        public string PickupName { get; set; }

        // שם או תיאור נקודת ההורדה.
        public string DropoffName { get; set; }
        // קו הרוחב של נקודת האיסוף.
        public decimal PickupLat { get; set; }
        // קו הרוחב של נקודת ההורדה.
        public decimal DropoffLat { get; set; }

        // המועד המבוקש לנסיעה.
        public DateTime RequestedTime { get; set; }

        // המצב הנוכחי או המבוקש של הרשומה.
        public int Status { get; set; }
    }
}
