using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using RevolutSpendings.API.Models;
using RevolutSpendings.API.Persistence;
using System.Diagnostics;

namespace RevolutSpendings.API.Services
{
	public class SpendingService
	{
		private readonly SpendingContext spendingContext;

		// todo: introduce logger
		public SpendingService(SpendingContext spendingContext)
		{
			this.spendingContext = spendingContext;

			// temp
			//	var json = File.ReadAllText("revolut.json");
			//	var temp = JsonConvert.DeserializeObject<Spending[]>(json);
			//	AddDatabase(temp);
		}

		public IEnumerable<Spending> GetAllSpendings()
		{
			return spendingContext.Spendings;
		}

		public IEnumerable<Spending> GetSpendingsByMonth(int month)
		{
			var spendings = spendingContext.Spendings;

			foreach (var spending in spendings)
			{
				DateTime date = new();
				try
				{
					date = DateTime.Parse(spending.Date);
				}
				catch (Exception ex)
				{
					Trace.WriteLine(ex);
					yield break;
				}
				if (date.Month == month + 1) // angular counts 0 as January, .NET counts it as 1
				{
					yield return spending;
				}
			}
		}


		//private void AddDatabase(IEnumerable<Spending> spendings)
		//{
		//	try
		//	{
		//		foreach (var spending in spendings)
		//		{
		//			spendingContext.Spendings.Add(spending);
		//			spendingContext.SaveChanges();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		Trace.WriteLine(ex);
		//	}
		//}

	}
}
