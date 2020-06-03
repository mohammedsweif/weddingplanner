using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.OurIdentity
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Article Title Is Required")]
        [MaxLength(50)][MinLength(20)]
        public string Article_Title { get; set; }
        [Required(ErrorMessage = "Article  Is Required")]
        [MaxLength(1000)]
        [MinLength(50)]
        public string Article_Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
        [ForeignKey("applicationUser")]
        public string user_id { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
