using Microsoft.AspNetCore.Mvc;
using RevolutSpendings.API.Models;
using RevolutSpendings.API.Services;

namespace RevolutSpendings.API.Controllers
{ 
	[ApiController]
	[Route("[controller]")]
	public class SpendingController : ControllerBase
	{
		private readonly SpendingService spendingService;

		public SpendingController(SpendingService spendingService)
		{
			this.spendingService = spendingService;
		}

		[HttpPost("byMonth")]
		public IActionResult GetSpendingsByMonth(GetSpendingByMonthRequest request)
		{
			var spendings = spendingService.GetSpendingsByMonth(request.Month);
			return Ok(spendings);
		}

		[HttpGet]
		public IActionResult GetSpendings()
		{
			var spendings = spendingService.GetAllSpendings();
			return Ok(spendings);
		}
	}
}
