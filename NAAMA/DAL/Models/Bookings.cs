using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class Booking
    {
        [Key]

        public int BookingId { get; set; }
        [ForeignKey("RideRequest")]

        public int RequestId { get; set; }
        [ForeignKey("Rides")]

        public int RideId { get; set; }
        public int LegSequence {  get; set; }

        public string PickupPoint { get; set; }

        public int Status { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public decimal ReminingAmount { get; set; }
    }
}
