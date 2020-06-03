using Final_project.Models.OurIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class bookrelation_user
    {
        [ForeignKey("booking")]
        public int BookingId { get; set; }
        public Booking booking{ get; set; }
        [ForeignKey("user")]
        public string UserId { get; set; }       
        public ApplicationUser user { get; set; }
        
    }
}
