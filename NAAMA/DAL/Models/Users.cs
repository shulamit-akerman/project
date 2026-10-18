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
    /// מייצג משתמש, פרטי חשבונו ומצב אימות מספר הטלפון שלו.
    /// </summary>
    public class Users
    {
        // סימון המאפיין הבא כמפתח הראשי של הישות.
        [Key]

        // מזהה המשתמש שאליו שייכת התגובה.
        public int UserId { get; set; }
            // שם פרטי של המשתמש.
            public string FirstName { get; set; }

            // שם משפחה של המשתמש.
            public string LastName { get; set; }

            // מספר הטלפון של המשתמש.
            public string Phone { get; set; }

            // כתובת הדואר האלקטרוני של המשתמש.
            public string Email { get; set; }

            // גיבוב הסיסמה השמור עבור המשתמש.
            public string PasswordHash { get; set; }

            // סוג המשתמש במערכת.
            public int UserType { get; set; }
        // האם מספר הטלפון של המשתמש אומת.
        public bool IsPhoneVerified { get; set; }

            // מועד יצירת הרשומה.
            public DateTime CreatedAt { get; set; }
       
    }
}
