using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

namespace Models
{
    public class Books
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorFK { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryFK { get; set; }  
        public DateTime PublicationDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
