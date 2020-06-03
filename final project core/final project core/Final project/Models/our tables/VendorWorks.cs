using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class VendorWorks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Image { get; set; }

        public int category_id { get; set; }
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [ForeignKey("applicationUser")]
        public string vendor_id { get; set; }

        public string last_updated { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
