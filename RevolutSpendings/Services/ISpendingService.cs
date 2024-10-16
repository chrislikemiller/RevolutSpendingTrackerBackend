using RevolutSpendings.API.Models;

namespace RevolutSpendings.API.Services
{
	public interface ISpendingService
	{
		Task<IEnumerable<Spending>> GetAllSpendings();
		Task<IEnumerable<Spending>> GetSpendingsByMonth(int month);
	}
}