using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class RequestToRide
    {
        [Key]
        public string RequestToRideId { get; set; }
        [ForeignKey("Request")]

        public string RequestId { get; set; }
        [ForeignKey("RideRequests")]

        public string RideId { get; set; }
    }
}
