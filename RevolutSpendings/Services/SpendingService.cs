using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using RevolutSpendings.API.Models;
using RevolutSpendings.API.Persistence;
using System.Diagnostics;

namespace RevolutSpendings.API.Services
{
	public class SpendingService : ISpendingService
	{
		private readonly IDatabaseAccessService databaseAccess;
		private readonly ILogger<ISpendingService> logger;

		public SpendingService(IDatabaseAccessService databaseAccess, ILogger<ISpendingService> logger)
		{
			this.databaseAccess = databaseAccess;
			this.logger = logger;
		}

		public Task<IEnumerable<Spending>> GetAllSpendings()
		{
			try
			{
				return databaseAccess.GetAllSpendings();
			}
			catch (Exception ex)
			{
				logger.LogError(ex, $"Failed to get all spendings");
			}
			return Task.FromResult(Enumerable.Empty<Spending>());
		}

		public async Task<IEnumerable<Spending>> GetSpendingsByMonth(int month)
		{
			var list = new List<Spending>();
			var spendings = await GetAllSpendings();
			foreach (var spending in spendings)
			{
				if (DateTime.TryParse(spending.Date, out var date))
				{
					date = DateTime.Parse(spending.Date);
					if (date.Month == month)
					{
						list.Add(spending);
					}
				}
				else
				{
					logger.LogError($"Failed to parse date for spending {spending.Id}");
				}
			}
			return list;
		}
	}
}
