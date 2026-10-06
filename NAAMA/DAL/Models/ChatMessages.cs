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
    public class ChatMessage
    {
        [Key]
        public int MessageId { get; set; }
        [ForeignKey("Users")]

        public int SenderId { get; set; }

        public string MessageText { get; set; }

        public DateTime SentAt { get; set; }
    }
}
