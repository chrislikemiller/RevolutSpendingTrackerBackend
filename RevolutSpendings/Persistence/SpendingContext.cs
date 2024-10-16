using Microsoft.EntityFrameworkCore;
using RevolutSpendings.API.Models;

namespace RevolutSpendings.API.Persistence
{
	public class SpendingContext : DbContext
	{
		public DbSet<Spending> Spendings { get; set; }

		public SpendingContext() 
		{
		}

		public SpendingContext(DbContextOptions options) : base(options)
		{
		}
	}
}
