using MicroRabbitMQ.Microservices.Transfer.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MicroRabbitMQ.Microservices.Transfer.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo() { Title = "Transfer Microservices", Version="V1"});
            });
        }

        public static void ConfigureContextSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TransferDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TransferDbConnection"));
            });
        }
    }
}
