using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class RideRequest
    {
        [Key]

        public int RequestId { get; set; }
        [ForeignKey("Users")]

        public int PassengerId { get; set; }

        public string PickupName { get; set; }

        public string DropoffName { get; set; }
        public decimal PickupLat { get; set; }
        public decimal DropoffLat { get; set; }

        public DateTime RequestedTime { get; set; }

        public int Status { get; set; }
    }
}
