using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCSH.Models;

namespace TCSH.ViewModel
{
    public class ClotheViewModel
    {
        public int ClotheId { get; set; }
        [Required]
        public string Market { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public float Price { get; set; }
        public float SaleRate { get; set; }
        public bool MostPopular { get; set; }
        public string ?CareInstruction { get; set; }
        public string ?MatrialComposition { get; set; }
        public string ?AdditonalInformation { get; set; }
        public byte[] productImage { get; set; }
        //Relations with other tabels{lists} 
        public int AgeId { get; set; }
        public IList<AgeType> AgeTypeList { get; set; }
        public int TypeId { get; set; }
        public IList<TypeOfClothe> TypeOfClotheLiat { get; set; }

        // the user
        public string ApplicationUserId { get; set; }
    }
}
