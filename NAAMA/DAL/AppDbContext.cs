using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;



namespace DAL
{
    public class AppDbContext : DbContext
    {
        // קונסטרוקטור שמקבל את ההגדרות
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestToRide> RequestToRides { get; set; }
        public DbSet<RequestToVehicles> RequestToVehicle { get; set; }
        public DbSet<MassageToBooking> MassageToBookings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<RideRequest> RideRequests { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}