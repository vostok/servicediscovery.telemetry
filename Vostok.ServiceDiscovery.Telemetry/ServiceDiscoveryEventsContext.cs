using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Vostok.Context;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventsBuilder;
using Vostok.ServiceDiscovery.Telemetry.EventsSender;

namespace Vostok.ServiceDiscovery.Telemetry
{
    [PublicAPI]
    public class ServiceDiscoveryEventsContext : IServiceDiscoveryEventsContext
    {
        private readonly ServiceDiscoveryEventsContextConfig config;

        public ServiceDiscoveryEventsContext([NotNull] ServiceDiscoveryEventsContextConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public IEnumerable<ServiceDiscoveryEvent> CurrentEvents
        {
            get => FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>()?.BuildEvents() ?? Enumerable.Empty<ServiceDiscoveryEvent>();
        }

        public void Send(ServiceDiscoveryEvent @event) =>
            config.Sender.Send(@event);

        public void SendFromContext() =>
            config.Sender.Send(CurrentEvents);
    }
}