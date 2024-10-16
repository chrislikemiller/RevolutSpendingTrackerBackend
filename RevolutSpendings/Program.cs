
using Microsoft.EntityFrameworkCore;
using RevolutSpendings.API.Persistence;
using RevolutSpendings.API.Services;
using System;

namespace RevolutSpendings.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("myfrontend",
					builder => builder
						.WithOrigins("http://localhost:4200")
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});

			builder.Logging.AddDebug();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			AddDependencies(builder);

			var app = builder.Build();
			SetupMigration(app);

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.UseCors("myfrontend");

			app.MapControllers();

			app.Run();
		}

		private static void SetupMigration(WebApplication app)
		{
			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<SpendingContext>();
				dbContext.Database.Migrate();
			}
		}

		private static void AddDependencies(WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<SpendingContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped(typeof(ISpendingService), typeof(SpendingService));
			builder.Services.AddScoped<IDatabaseAccessService>(provider => provider.GetRequiredService<SpendingContext>());
		}
	}
}
