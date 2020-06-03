using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models.our_tables;

namespace Final_project.Models.OurIdentity
{
    //الخطوبه 
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }
        
      
       
        public string feature_name {get;set;}

        public string description { get; set; }

        [ForeignKey("catagory")]
        public int catagory_id { get; set; }

        [ForeignKey("Season")]
        public int? season_id { get; set; }
        [ForeignKey("Event")]
        public int? Event_id { get; set; }
        public bool status { get; set; }
        public int PackageCost { get; set; }
        [ForeignKey("ApplicationUser")]
        public string VendorId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public catagory catagory { get; set; }
        public Event Event { get; set; }
        public season Season { get; set; }
        //public packagefeatures packagefeature { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
