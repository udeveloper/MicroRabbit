using MicroRabbitMQ.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbitMQ.Microservices.Banking.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; } 
        public decimal Ammount { get; protected set; } 
    }
}
