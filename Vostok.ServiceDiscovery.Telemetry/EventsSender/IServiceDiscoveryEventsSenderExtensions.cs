using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventsSender
{
    [PublicAPI]
    public static class IServiceDiscoveryEventsSenderExtensions
    {
        public static void Send(this IServiceDiscoveryEventsSender eventsSender, [NotNull] IEnumerable<ServiceDiscoveryEvent> events)
        {
            foreach (var @event in events)
                eventsSender.Send(@event);
        }
    }
}