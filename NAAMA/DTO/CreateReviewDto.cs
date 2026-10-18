// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מכיל את פרטי הקלט ליצירת חוות דעת.
    /// </summary>
    public class CreateReviewDto
    {
        // מזהה הנסיעה שאליה מתייחסים.
        public string RideId { get; set; }
        // מזהה המשתמש שעליו נכתבה חוות הדעת.
        public string ReviewedUserId { get; set; }
        // הדירוג המספרי שניתן.
        public int Rating { get; set; }
        // הטקסט של חוות הדעת.
        public string Comment { get; set; }
    }
}