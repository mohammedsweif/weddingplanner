using Final_project.Models.OurIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class VendorBusy
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("applicationUser")]
        public string vendor_id { get; set; }
        [ForeignKey("Booking")]
        public int? BookingId { get; set; }
        [DataType(DataType.Date)]
        public DateTime BusyDay { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public Booking Booking { get; set; }
    }
}
