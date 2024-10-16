using Microsoft.AspNetCore.Mvc;
using RevolutSpendings.API.Models;
using RevolutSpendings.API.Services;

namespace RevolutSpendings.API.Controllers
{ 
	[ApiController]
	[Route("[controller]")]
	public class SpendingController : ControllerBase
	{
		private readonly ISpendingService spendingService;

		public SpendingController(ISpendingService spendingService)
		{
			this.spendingService = spendingService;
		}

		[HttpPost("byMonth")]
		public async Task<IActionResult> GetSpendingsByMonth(GetSpendingByMonthRequest request)
		{
			var spendings = await spendingService.GetSpendingsByMonth(request.Month);
			return Ok(spendings);
		}

		[HttpGet]
		public async Task<IActionResult> GetSpendings()
		{
			var spendings = await spendingService.GetAllSpendings();
			return Ok(spendings);
		}
	}
}
