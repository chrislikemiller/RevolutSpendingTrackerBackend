using RevolutSpendings.API.Models;

namespace RevolutSpendings.API.Persistence
{
    public interface IDatabaseAccessService
    {
		Task<IEnumerable<Spending>> GetAllSpendings();

	}
}
