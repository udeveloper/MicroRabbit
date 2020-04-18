using MediatR;
using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Microservices.Banking.Domain.Commands;
using MicroRabbitMQ.Microservices.Banking.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Microservices.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new TransferCreatedEvent(request.From, request.To, request.Ammount));

            return Task.FromResult(true);
        }
    }
}
