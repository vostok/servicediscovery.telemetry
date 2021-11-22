using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventDescription
{
    [PublicAPI]
    public static class ServiceDiscoveryEventsBuilder
    {
        [NotNull]
        public static IEnumerable<ServiceDiscoveryEvent> FromDescription([NotNull] IServiceDiscoveryEventDescription serviceDiscoveryEventDescription) =>
            throw new NotImplementedException();
    }
}