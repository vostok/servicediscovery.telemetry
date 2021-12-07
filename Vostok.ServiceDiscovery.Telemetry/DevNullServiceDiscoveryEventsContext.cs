using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry
{
    /// <summary>
    /// A trivial implementation of <see cref="IServiceDiscoveryEventsContext"/> that simply does nothing.
    /// </summary>
    [PublicAPI]
    public class DevNullServiceDiscoveryEventsContext : IServiceDiscoveryEventsContext
    {
        public IEnumerable<ServiceDiscoveryEvent> CurrentEvents { get; } = Enumerable.Empty<ServiceDiscoveryEvent>();

        public void Send(ServiceDiscoveryEvent @event)
        {
        }

        public void SendFromContext()
        {
        }
    }
}