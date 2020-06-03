using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.OurIdentity
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [DataType(DataType.Date)]
        public DateTime BookDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RealDate { get; set; }
      
        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public catagory category { get; set; }
        public bool Status { get; set; }
        public int Cost { get; set; }
        [ForeignKey("user")]
        public string UserId { get; set; }
        [ForeignKey("vendor")]
        public string VendorId { get; set; }
        [ForeignKey("Package")]
        public int pack_id { set; get; }
        public Package Package { get; set; }
        public ApplicationUser user { get; set; }
        public ApplicationUser vendor { get; set; }



    }
}
