using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [ForeignKey ("Users")]

        public int DriverId { get; set; }

        public string LicensePlate { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int AvailableSeats { get; set; }
    }
}
