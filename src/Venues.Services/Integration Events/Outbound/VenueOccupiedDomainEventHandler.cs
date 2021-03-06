﻿using MediatR;
using PingDong.DDD.Services;
using PingDong.Messages;
using PingDong.Newmoon.Venues.DomainEvents;
using PingDong.Newmoon.Venues.Services.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace PingDong.Newmoon.Venues.Services.DomainEvents
{
    public class VenueOccupiedDomainEventHandler : DomainEventHandler, INotificationHandler<VenueOccupiedDomainEvent>
    {
        public VenueOccupiedDomainEventHandler(IMessagePublisher publisher, IMediator mediator)
            : base(publisher, mediator)
        {
        }

        public async Task Handle(VenueOccupiedDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            domainEvent.EnsureNotNull(nameof(domainEvent));

            var integrationEvent = new VenueOccupiedIntegrationEvent(domainEvent.VenueId);
            integrationEvent.AppendTraceMetadata(domainEvent);
            
            await PublishAsync(integrationEvent, domainEvent);
        }
    }
}
