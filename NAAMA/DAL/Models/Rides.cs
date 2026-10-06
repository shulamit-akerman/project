using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class Ride
    {
        [Key]

        public int RideId { get; set; }
        [ForeignKey("Users")]

        public int DriverId { get; set; }

        public string Origin { get; set; }

        public string DestinationName { get; set; }
        public decimal DestinationLat { get; set; }

        public DateTime DepartureTime { get; set; }

        public bool IsRecurring { get; set; }

        public int MaxSeats { get; set; }

        public int Status { get; set; }
    }
}
