using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.OurIdentity
{
    public class catagory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cat_Id { get; set; }
        [Required]
        public string cat_Name { get; set; }
        public List<Booking> bookings { get; set; }
        public List<Package> packages { get; set; }
        public List<Rating> ratings { get; set; }
        public List<Review> reviews { get; set; }
        public List<Vendor> vendors { get; set; }
        // public List<ApplicationUser> user { get; set; }
    }

}
