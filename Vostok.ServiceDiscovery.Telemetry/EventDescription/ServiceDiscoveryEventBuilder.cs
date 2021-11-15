using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventDescription
{
    [PublicAPI]
    public static class ServiceDiscoveryEventsBuilder
    {
        [NotNull]
        public static IEnumerable<ServiceDiscoveryEvent> FromDescription([NotNull] ServiceDiscoveryEventDescription serviceDiscoveryEventDescription)
        {
            if (serviceDiscoveryEventDescription.Application == null || serviceDiscoveryEventDescription.Environment == null)
                return Enumerable.Empty<ServiceDiscoveryEvent>();

            return serviceDiscoveryEventDescription.Replicas.Select(replica => new ServiceDiscoveryEvent(
                serviceDiscoveryEventDescription.EventKind,
                serviceDiscoveryEventDescription.Application,
                replica,
                serviceDiscoveryEventDescription.Environment,
                DateTimeOffset.UtcNow,
                serviceDiscoveryEventDescription.Properties));
        }
    }
}