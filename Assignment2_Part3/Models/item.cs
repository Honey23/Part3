using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_Part3.Models
{
    [Table("item")]
    public class item
    {
        [Key]
        public int item_id { get; set; }

        [Required]
        public string item_name { get; set; }

        [Range(0, 100000)]
        public int item_price { get; set; }
        public int item_quantity { get; set; }

    }
}
