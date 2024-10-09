using Newtonsoft.Json;
using RevolutSpendings.API.Models;

namespace RevolutSpendings.API.Services
{
	public class SpendingService
	{
		private IEnumerable<Spending> spendings;

		public SpendingService()
		{
			var json = File.ReadAllText("revolut.json");
			spendings = JsonConvert.DeserializeObject<Spending[]>(json);
		}

		public IEnumerable<Spending> GetAllSpendings()
		{
			return spendings;
		}

		public IEnumerable<Spending> GetSpendingsByMonth(int month)
		{
			return spendings
				.Where(x =>
				{
					var date = DateTime.Parse(x.Date);
					return date.Month == month;
				});
		}
	}
}
