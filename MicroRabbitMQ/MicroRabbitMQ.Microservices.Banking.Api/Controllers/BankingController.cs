using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbitMQ.Microservices.Banking.Application.Interfaces;
using MicroRabbitMQ.Microservices.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroRabbitMQ.Microservices.Banking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        private readonly ILogger<BankingController> _logger;

        public BankingController(ILogger<BankingController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }
    }
}
