using MicroRabbitMQ.Microservices.Banking.Application.Models;
using MicroRabbitMQ.Microservices.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Microservices.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccounts();

        void Transfer(AccountTransfer accountRequest);
    }
}
