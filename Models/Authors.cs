using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Authors
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
        public Boolean LifeStatus { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
