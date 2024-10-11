using Microsoft.AspNetCore.Mvc;
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

		[HttpGet("{month}")]
		public IActionResult GetSpendingsByMonth(int month)
		{
			// todo: transform to presentation objects 
			var spendings = spendingService.GetSpendingsByMonth(month);
			return Ok(spendings);
		}

		[HttpGet]
		public IActionResult GetSpendings()
		{
			// todo: transform to presentation objects 
			var spendings = spendingService.GetAllSpendings();
			return Ok(spendings);
		}
	}
}
