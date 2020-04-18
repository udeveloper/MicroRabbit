using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Microservices.Banking.Application.Interfaces;
using MicroRabbitMQ.Microservices.Banking.Application.Models;
using MicroRabbitMQ.Microservices.Banking.Domain.Commands;
using MicroRabbitMQ.Microservices.Banking.Domain.Interfaces;
using MicroRabbitMQ.Microservices.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Microservices.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;

        public AccountService (IAccountRepository accountRepository,IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountRequest)
        {
            var createTransferCommand = new CreateTransferCommand(
                    from : accountRequest.FromAccount,
                    to: accountRequest.ToAccount,
                    ammount: accountRequest.TransferAmmount
                );

            _eventBus.SendCommand(createTransferCommand);
        }
    }
}
