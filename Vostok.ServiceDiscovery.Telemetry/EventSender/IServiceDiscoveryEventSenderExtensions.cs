using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventSender
{
    [PublicAPI]
    public static class IServiceDiscoveryEventSenderExtensions
    {
        public static void Send(this IServiceDiscoveryEventSender eventSender, [NotNull] IEnumerable<ServiceDiscoveryEvent> events)
        {
            foreach (var @event in events)
                eventSender.Send(@event);
        }
    }
}