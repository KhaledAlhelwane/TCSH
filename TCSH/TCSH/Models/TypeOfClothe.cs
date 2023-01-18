
using System.ComponentModel.DataAnnotations;

namespace TCSH.Models
{
    public class TypeOfClothe
    {
        //for searching purpose for example:jeans,Jacket,Techert..etc
        public int TypeOfClotheId { get; set; }
        [Required]
        public string TypeOfTitle { get; set; }
        public ICollection<Clothe> Clothe { get; set; }
    }
}
