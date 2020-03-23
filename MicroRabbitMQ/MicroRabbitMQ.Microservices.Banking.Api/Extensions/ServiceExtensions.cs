using MicroRabbitMQ.Microservices.Banking.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MicroRabbitMQ.Microservices.Banking.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo() { Title = "Banking Microservices", Version="V1"});
            });
        }

        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BankingDbConnection"));
            });
        }
    }
}
