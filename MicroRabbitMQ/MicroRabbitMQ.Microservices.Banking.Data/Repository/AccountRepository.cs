using MicroRabbitMQ.Microservices.Banking.Data.Context;
using MicroRabbitMQ.Microservices.Banking.Domain.Interfaces;
using MicroRabbitMQ.Microservices.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbitMQ.Microservices.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _dbContext;

        public AccountRepository(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _dbContext.Accounts.ToListAsync();
        }
    }
}
