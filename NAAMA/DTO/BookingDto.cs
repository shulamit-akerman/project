// ייבוא טיפוסים בסיסיים של .NET, כגון תאריך ושעה.
using System;

// הגדרת מרחב השמות RideSharing.DTOs כדי לשייך את הטיפוסים למודול המתאים.
namespace RideSharing.DTOs
{
    /// <summary>
    /// מייצג פרטי הזמנה להעברה בין שכבות המערכת.
    /// </summary>
    public class BookingDto
    {
        // המזהה הייחודי של הרשומה.
        public string Id { get; set; }
        // מזהה הנסיעה שאליה מתייחסים.
        public string RideId { get; set; }
        // מזהה הנוסע.
        public string PassengerId { get; set; }
        // שם הנוסע.
        public string PassengerName { get; set; }
        // מספר המושבים שהתבקשו.
        public int RequestedSeats { get; set; }
        // המצב הנוכחי או המבוקש של הרשומה.
        public string Status { get; set; }
        // מועד הגשת הבקשה.
        public DateTime RequestedAt { get; set; }
    }
}