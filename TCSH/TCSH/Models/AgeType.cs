namespace TCSH.Models
{
    public class AgeType
    {
        public int AgeTypeId { get; set; }
        public string Type_Title{ get; set; }
        public string MyProperty { get; set; }
        //public int ClotheId { get; set; }
        public Clothe Clothe { get; set; }
    }
}
