using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("UserTypeId")]
        public int UserTypeFK { get; set; }
        public Boolean Active { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
