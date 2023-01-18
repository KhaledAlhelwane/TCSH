using System.ComponentModel.DataAnnotations;
namespace TCSH.Models
{
    public class AgeType
    {
        public int AgeTypeId { get; set; }
        [Required]
        [MaxLength(15,ErrorMessage ="Charecter max range to 15")]
        public string Type_Title{ get; set; }
        public ICollection<Clothe> Clothe { get; set; }
    }
}
