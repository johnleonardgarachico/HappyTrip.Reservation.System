using HappyTrip.Reservation.System.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HappyTrip.Reservation.System.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            await ApplyMigrations(webHost.Services);

            await webHost.RunAsync();
        }

        private static async Task ApplyMigrations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            await using HappyTripContext dbContext = scope.ServiceProvider.GetRequiredService<HappyTripContext>();

            await dbContext.Database.MigrateAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}