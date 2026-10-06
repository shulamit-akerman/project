using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class Users
    {
        [Key]

        public int UserId { get; set; }
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Phone { get; set; }

            public string Email { get; set; }

            public string PasswordHash { get; set; }

            public int UserType { get; set; }
        public bool IsPhoneVerified { get; set; }

            public DateTime CreatedAt { get; set; }
       
    }
}

