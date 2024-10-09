namespace RevolutSpendings.API.Models
{
	public class Spending
	{
		public int Id { get; set; }
		public string Type { get; set; }
		public string Date { get; set; }
		public string Description { get; set; }
		public double Amount { get; set; }
		public double Fee { get; set; }
		public string Currency { get; set; }
		public string Category { get; set; }
		public string Tag { get; set; }
	}

}
