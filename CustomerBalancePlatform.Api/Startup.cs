using CustomerBalancePlatform.Api.Data;
using CustomerBalancePlatform.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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

            // Adding Swagger documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Customer Balance Platform API",
                    Version = "v1",
                    Description = "API for managing customer records and balances."
                });
            });
        }

        // HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Balance Platform API V1");
                    c.RoutePrefix = string.Empty; // Swagger UI to root URL
                });
            }


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
