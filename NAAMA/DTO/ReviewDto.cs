// ייבוא טיפוסים בסיסיים של .NET, כגון תאריך ושעה.
using System;

// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מייצג פרטי חוות דעת להעברה בין שכבות המערכת.
    /// </summary>
    public class ReviewDto
    {
        // המזהה הייחודי של הרשומה.
        public string Id { get; set; }
        // שם המשתמש שכתב את חוות הדעת.
        public string ReviewerName { get; set; }
        // הדירוג המספרי שניתן.
        public int Rating { get; set; }
        // הטקסט של חוות הדעת.
        public string Comment { get; set; }
        // מועד יצירת הרשומה.
        public DateTime CreatedAt { get; set; }
    }
}