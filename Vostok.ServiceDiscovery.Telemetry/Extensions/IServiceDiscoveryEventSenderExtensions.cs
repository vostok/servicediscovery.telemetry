using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;
using Vostok.ServiceDiscovery.Telemetry.EventDescription;
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

        public static void Send(this IServiceDiscoveryEventSender eventSender, [NotNull] Action<IServiceDiscoveryEventDescription> descriptionSetup)
        {
            var description = new ServiceDiscoveryEventDescription();
            descriptionSetup(description);

            eventSender.Send(ServiceDiscoveryEventsBuilder.FromDescription(description));
        }

        public static bool TrySendFromContext(this IServiceDiscoveryEventSender eventSender, [NotNull] Action<IServiceDiscoveryEventDescription> descriptionSetup)
        {
            if (ServiceDiscoveryEventDescriptionContext.CurrentDescription == null)
                return false;

            using (ServiceDiscoveryEventDescriptionContext.Continue())
            {
                descriptionSetup(ServiceDiscoveryEventDescriptionContext.CurrentDescription);

                eventSender.Send(ServiceDiscoveryEventsBuilder.FromDescription(ServiceDiscoveryEventDescriptionContext.CurrentDescription));
            }

            return true;
        }
    }
}