using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.OurIdentity
{
    public class Vendor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Website { get; set; }
        public string FacebookLink { get; set; }
        public string Twitterr { get; set; }
        public string Instgram { get; set; }
        [Required]
        public string PersonalImage { get; set; }
        [Required]
        [ForeignKey("category")]
        public int catt_id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string vendor_id { get; set; }

        
        public catagory category { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
