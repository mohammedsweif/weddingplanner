using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class shop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("product")]
        public int product_id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string user_id { get; set; }

        public int quantity { get; set; }
        public int price { get; set; }

        public bool state {get;set;}
        public DateTime shop_time { get; set; }

        public product product { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
