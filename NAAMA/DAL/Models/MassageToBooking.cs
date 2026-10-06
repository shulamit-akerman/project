using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class MassageToBooking
    {
        [Key]
        public int MassageToBookingId { get; set; }
        [ForeignKey("ChatMassages")]
        public int MassageId { get; set;}
        [ForeignKey("Booking")]

        public int BookingId { get; set;}
    }
}
