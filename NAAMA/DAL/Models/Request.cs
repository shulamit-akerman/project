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
    /// מייצג בקשת נסיעה עם דרישות המשתמש לצורך איתור התאמות.
    /// </summary>
    public class Request
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]
        // מזהה בקשת הנסיעה.
        public string RequestId { get; set; }
        // האם נדרש או קיים מקום בתא המטען.
        public bool HasTrunkSpace { get; set; }
        // האם נדרש או קיים מקום לעגלת תינוק.
        public bool FitsStroller { get; set; }
        // האם נדרשים או קיימים מושבי בטיחות לילדים.
        public bool HasChildSeats { get; set; }
        // האם מותר להשמיע מוזיקה בנסיעה.
        public bool AllowMusic { get; set; }
        // ז׳אנר המוזיקה המועדף.
        public string MusicGenre { get; set; }
    }
}
