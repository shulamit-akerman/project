using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class Request
    {
        [Key]
        public string RequestId { get; set; }
        public bool HasTrunkSpace { get; set; }
        public bool FitsStroller { get; set; }
        public bool HasChildSeats { get; set; }
        public bool AllowMusic { get; set; }
        public string MusicGenre { get; set; }
    }
}
