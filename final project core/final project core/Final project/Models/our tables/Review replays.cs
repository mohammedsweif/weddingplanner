using Final_project.Models.OurIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class Review_replays
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("review")]
        public int Review_Id { get; set; }

        public string PostDate { get; set; }

        
        [Required(ErrorMessage = "Comment Is Required")]
        public string Comment { get; set; }

        [ForeignKey("ApplicationUser")]
        public string User_Id { get; set; }

        [ForeignKey("Vendor")]
        public string Vendor_Id { get; set; }

        public bool liked { get; set; }

        public Review review { set; get; }
        public ApplicationUser ApplicationUser { set; get; }
        public ApplicationUser Vendor { set; get; }
    }
}
