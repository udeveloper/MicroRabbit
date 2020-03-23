using MicroRabbitMQ.Microservices.Banking.Application.Interfaces;
using MicroRabbitMQ.Microservices.Banking.Domain.Interfaces;
using MicroRabbitMQ.Microservices.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbitMQ.Microservices.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService (IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
    }
}
