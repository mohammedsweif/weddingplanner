using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class toDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Vendors")]
        public string Vendor_Id { get; set; }
        [Required]
        public string Description { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime date { get; set; }
        public ApplicationUser Vendors { get; set; }

    }
}
