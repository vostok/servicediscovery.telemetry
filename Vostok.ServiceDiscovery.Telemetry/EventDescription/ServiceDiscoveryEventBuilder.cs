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
        public static IEnumerable<ServiceDiscoveryEvent> FromDescription([NotNull] IServiceDiscoveryEventDescription serviceDiscoveryEventDescription)
        {
            if (serviceDiscoveryEventDescription.Application == null || serviceDiscoveryEventDescription.Environment == null)
                return Enumerable.Empty<ServiceDiscoveryEvent>();

            return serviceDiscoveryEventDescription.Replicas.Select(replica => new ServiceDiscoveryEvent(
                serviceDiscoveryEventDescription.EventKind,
                serviceDiscoveryEventDescription.Environment,
                serviceDiscoveryEventDescription.Application,
                replica,
                DateTimeOffset.Now,
                serviceDiscoveryEventDescription.Properties));
        }
    }
}