using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.OurIdentity
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage ="Please Enter The Date")]
        //  [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
        [MaxLength(250)][MinLength(20)]
        [Required(ErrorMessage ="Comment Is Required")]
        public string Comment { get; set; }
        [ForeignKey("ApplicationUser")]
        public string User_Id { get; set; }
     
        [ForeignKey("Vendor")]
        public string Vendor_Id { get; set; }
        [ForeignKey("catagory")]
        public int catagory_id { get; set; }

        public bool liked { get; set; }
        public catagory catagory { get; set; }
        public ApplicationUser ApplicationUser { set; get; }
        public ApplicationUser Vendor { set; get; }
        

    }
}
