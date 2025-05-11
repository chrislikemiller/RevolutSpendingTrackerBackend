using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using RevolutSpendings.API.Models;
using RevolutSpendings.API.Persistence;
using System.Diagnostics;

namespace RevolutSpendings.API.Services
{
    public class SpendingService : ISpendingService
    {
        private readonly SpendingContext spendingDb;
        private readonly ILogger<ISpendingService> logger;

        public SpendingService(SpendingContext spendingDb, ILogger<ISpendingService> logger)
        {
            this.spendingDb = spendingDb;
            this.logger = logger;
        }

        public Task<IEnumerable<Spending>> GetAllSpendings()
        {
            try
            {
                return spendingDb.GetAllSpendings();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to get all spendings");
            }
            return Task.FromResult(Enumerable.Empty<Spending>());
        }

        public IEnumerable<Spending> GetSpendingsByMonth(int month)
        {
            try
            {
                return spendingDb.GetSpendingsByMonth(month);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to get spendings by month {month}");
            }
            return Enumerable.Empty<Spending>();
        }
    }
}
