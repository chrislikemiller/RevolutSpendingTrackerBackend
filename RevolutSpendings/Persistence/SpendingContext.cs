using Microsoft.EntityFrameworkCore;
using RevolutSpendings.API.Models;

namespace RevolutSpendings.API.Persistence
{
    public class SpendingContext : DbContext
    {
        public DbSet<Spending> Spendings { get; set; }

        public SpendingContext() { }

        public SpendingContext(DbContextOptions options) : base(options)
        {
        }

        public async Task<IEnumerable<Spending>> GetAllSpendings()
        {
            return await Spendings.ToListAsync();
        }

        public async Task<IEnumerable<Spending>> GetSpendingsByMonth(int month)
        {
            return await Spendings
                .AsNoTracking()
                .Where(x => x.Date.Month == month)
                .ToListAsync();
        }
    }
}