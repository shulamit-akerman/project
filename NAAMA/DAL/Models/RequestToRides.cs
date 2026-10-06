using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class RequestToVehicles
    {
        [Key]
        public string RequestToVehiclesId { get; set; }
        [ForeignKey("Vehicle")]

        public string VehicleId { get; set; }
        [ForeignKey("Request")]

        public string RequestId { get; set; }

    }
}
