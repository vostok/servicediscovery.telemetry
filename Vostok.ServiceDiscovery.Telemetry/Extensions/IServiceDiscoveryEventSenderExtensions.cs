using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventSender;

namespace Vostok.ServiceDiscovery.Telemetry.Extensions
{
    [PublicAPI]
    public static class IServiceDiscoveryEventSenderExtensions
    {
        public static void Send(this IServiceDiscoveryEventSender eventSender, [NotNull] IEnumerable<ServiceDiscoveryEvent> events)
        {
            foreach (var serviceDiscoveryEvent in events)
                eventSender.Send(serviceDiscoveryEvent);
        }
    }
}