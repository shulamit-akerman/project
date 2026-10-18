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
    /// מייצג הודעה שנשלחה בשיחת צ'אט במערכת.
    /// </summary>
    public class ChatMessage
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]
        // מזהה הודעת הצ׳אט.
        public int MessageId { get; set; }
        // הגדרת המאפיין הבא כמפתח זר המקושר לישות שצוינה במאפיין.
        [ForeignKey("Users")]

        // מזהה המשתמש ששלח את ההודעה.
        public int SenderId { get; set; }

        // תוכן הודעת הצ׳אט.
        public string MessageText { get; set; }

        // מועד שליחת ההודעה.
        public DateTime SentAt { get; set; }
    }
}
