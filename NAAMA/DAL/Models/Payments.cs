using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class Payments
    {
        [Key]

        public int PaymentsId { get; set; }
        [ForeignKey("Bookings")]

        public int BookingId { get; set; }

        public decimal Amount { get; set; }

        public int PaymentType { get; set; }

        public int PaymentStatus { get; set; }

        public int PaymentStage { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
