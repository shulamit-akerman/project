// ייבוא מחלקות הישויות של שכבת הגישה לנתונים.
using DAL.Models;
// ייבוא ממשקי Entity Framework Core לניהול הקשר ואוספי הישויות.
using Microsoft.EntityFrameworkCore;
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
// ייבוא מחלקות הישויות של שכבת הגישה לנתונים.
using DAL.Models;



// הגדרת מרחב השמות DAL כדי לשייך את הטיפוסים למודול המתאים.
namespace DAL
{
    /// <summary>
    /// מגדיר את חיבור Entity Framework למסד הנתונים ואת אוספי הישויות של המערכת.
    /// </summary>
    public class AppDbContext : DbContext
    {
        // קבלת אפשרויות התצורה של EF Core והעברתן לבנאי DbContext כדי לקבוע את חיבור מסד הנתונים.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // אוסף ישויות בקשות הנסיעה במסד הנתונים.
        public DbSet<Request> Requests { get; set; }
        // אוסף קישורים בין בקשות לנסיעות במסד הנתונים.
        public DbSet<RequestToRide> RequestToRides { get; set; }
        // אוסף קישורים בין בקשות לכלי רכב במסד הנתונים.
        public DbSet<RequestToVehicles> RequestToVehicle { get; set; }
        // אוסף קישורים בין הודעות להזמנות במסד הנתונים.
        public DbSet<MassageToBooking> MassageToBookings { get; set; }
        // אוסף ההזמנות במסד הנתונים.
        public DbSet<Booking> Bookings { get; set; }
        // אוסף הודעות הצ׳אט במסד הנתונים.
        public DbSet<ChatMessage> ChatMessages { get; set; }
        // אוסף התשלומים במסד הנתונים.
        public DbSet<Payments> Payments { get; set; }
        // אוסף בקשות ההצטרפות לנסיעה במסד הנתונים.
        public DbSet<RideRequest> RideRequests { get; set; }
        // אוסף הנסיעות במסד הנתונים.
        public DbSet<Ride> Rides { get; set; }
        // אוסף המשתמשים במסד הנתונים.
        public DbSet<Users> Users { get; set; }
        // אוסף כלי הרכב במסד הנתונים.
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}