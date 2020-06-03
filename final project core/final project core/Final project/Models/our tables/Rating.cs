using Final_project.Models.OurIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class Rating
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage ="Please Enter The Date")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="Rating is required")]
        [Range(1,5)]
        public int Rate { get; set; }
        [ForeignKey("ApplicationUser")]
        public string User_Id { get; set; }
        [ForeignKey("vendor")]
        public string Vendor_Id { get; set; }
        public ApplicationUser ApplicationUser{ set; get;}

        public ApplicationUser vendor{ set; get;}
        [ForeignKey("category")]
        public int Category_Id { get; set; }
       // public category category { get; set; }

    }
}
