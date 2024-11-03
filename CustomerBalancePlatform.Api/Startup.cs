using CustomerBalancePlatform.Api.Data;
using CustomerBalancePlatform.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerBalancePlatform.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configure services and dependencies
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure SQL Server with Entity Framework
            services.AddDbContext<CustomerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add repository for dependency injection
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Add MVC services
            services.AddControllers();
        }

        // Configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
