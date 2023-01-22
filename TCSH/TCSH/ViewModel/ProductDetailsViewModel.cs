namespace TCSH.ViewModel
{
	public class ProductDetailsViewModel
	{
		public int ClotheId { get; set; }
		public string ?Market { get; set; }
		public string ?Title { get; set; }
		public float Price { get; set; }
		public byte[]? productImage { get; set; }
		public string? CareInstruction { get; set; }
		public string? MatrialComposition { get; set; }
		public string? AdditonalInformation { get; set; }
		public string ?AgeType { get; set; }
		public string ?ClotheType { get; set; }
		//Addtional inforamtion 
		public float SaleRate { get; set; }
		public bool MostPopular { get; set; }
	}

}
