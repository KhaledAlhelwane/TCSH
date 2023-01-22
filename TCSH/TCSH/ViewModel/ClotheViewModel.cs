using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCSH.Models;

namespace TCSH.ViewModel
{
    public class ClotheViewModel
    {
        public int ClotheId { get; set; }
        [Required]
        [MaxLength(15,ErrorMessage ="please charecters numbers must be less or equal 15 charecters")]
        public string Market { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "please charecters numbers must be less or equal 15 charecters")]
        public string Title { get; set; }
        //public string Size { get; set; }
        [Required]
        public float Price { get; set; }
        public float SaleRate { get; set; }
        public bool MostPopular { get; set; }
        public string ?CareInstruction { get; set; }
        public string ?MatrialComposition { get; set; }
        public string ?AdditonalInformation { get; set; }
        
        public byte[]? productImage { get; set; }
        [Required]
        public IFormFile? productImage2 { get; set; }
        public IList<AgeType>? AgeTypeList { get; set; }

        public IList<TypeOfClothe>? TypeOfClotheLiat { get; set; }

        // the user
        public string ApplicationUserId { get; set; }
        //Relations with other tabels{lists}
      
        public int AgeId { get; set; }
      
        public int TypeId { get; set; }

       
    }
}
