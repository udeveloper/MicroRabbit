using MediatR;
using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Infra.Bus;
using MicroRabbitMQ.Microservices.Banking.Application.Interfaces;
using MicroRabbitMQ.Microservices.Banking.Application.Services;
using MicroRabbitMQ.Microservices.Banking.Data.Context;
using MicroRabbitMQ.Microservices.Banking.Data.Repository;
using MicroRabbitMQ.Microservices.Banking.Domain.CommandHandlers;
using MicroRabbitMQ.Microservices.Banking.Domain.Commands;
using MicroRabbitMQ.Microservices.Banking.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MicroRabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Cross-Cutting
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();

           
        }
    }
}
