using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_Part3.Models
{

    [Table("store")]
    public class store
    {
        [Key]
        
        public int book_id { get; set; }

        [Required]
       
        public string book_name { get; set; }

        [Range(0, 100000)]
       
        public int book_price { get; set; }

        [Required]
        
        public string author_name { get; set; }

        public int year_published { get; set; }
    }
}
