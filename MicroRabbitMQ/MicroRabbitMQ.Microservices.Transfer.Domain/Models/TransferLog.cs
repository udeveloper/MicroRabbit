﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbitMQ.Microservices.Transfer.Domain.Models
{
    public class TransferLog
    {
        public int Id { get; set; }
        public int FromAccount {get;set;}
        public int ToAccount { get; set; }
        public decimal Amount { get; set; }
    }
}
