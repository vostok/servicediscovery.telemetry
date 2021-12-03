using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Vostok.Context;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventsBuilder;
using Vostok.ServiceDiscovery.Telemetry.EventSender;

namespace Vostok.ServiceDiscovery.Telemetry.EventContext
{
    [PublicAPI]
    public class ServiceDiscoveryEventContext : IServiceDiscoveryEventContext
    {
        private readonly ServiceDiscoveryEventContextConfig config;

        public ServiceDiscoveryEventContext([NotNull] ServiceDiscoveryEventContextConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public IReadOnlyList<ServiceDiscoveryEvent> CurrentEvents
        {
            get => FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>()?.BuildEvents() ?? new List<ServiceDiscoveryEvent>();
        }

        public void Send(ServiceDiscoveryEvent @event) =>
            config.Sender.Send(@event);

        public bool TrySendFromContext()
        {
            var currentEvents = CurrentEvents;

            if (!currentEvents.Any())
                return false;

            config.Sender.Send(currentEvents);
            return true;
        }
    }
}