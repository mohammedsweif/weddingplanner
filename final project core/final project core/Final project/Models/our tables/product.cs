using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int old_price { get; set; }
        public string description { get; set; }
        public string product_image { get; set; }

        [ForeignKey("productType")]
        public int type_id {get; set;}
        public DateTime Exp_date { get; set; }
        public DateTime Prod_date { get; set; }

        public productType productType { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
