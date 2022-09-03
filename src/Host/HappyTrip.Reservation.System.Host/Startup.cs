using HappyTrip.Reservation.System.Domain;
using HappyTrip.Reservation.System.Repository.DatabaseContext;
using HappyTrip.Reservation.System.Repository.Interfaces;
using HappyTrip.Reservation.System.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace HappyTrip.Reservation.System.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<HappyTripContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                     b => b.MigrationsAssembly(typeof(HappyTripContext).Assembly.FullName));
                
            });

            services.AddScoped<IHappyTripContext, HappyTripContext>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            var x = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
