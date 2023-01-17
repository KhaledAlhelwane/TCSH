using System.ComponentModel.DataAnnotations;

namespace TCSH.Models
{
    public class Clothe
    {
        public int ClotheId { get; set; }
        public string Market { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public float SaleRate { get; set; }
        public bool MostPopular { get; set; }
        public string CareInstruction { get; set; }
        public string MatrialComposition { get; set; }
        public string AdditonalInformation { get; set; }
        public byte[] productImage { get; set; }
      
        //public  ICollection<AddtionalPicture> addtionalPicture { get; set; }
        //[Required]
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<AddtionalPicture> AddtionalPicture { get; set; }
        public int AgeTypeId { get; set; }
        public AgeType AgeType { get; set; }
        public int TypeOfClotheId { get; set; }
        public TypeOfClothe TypeOfClothe { get; set; }
    }
}
