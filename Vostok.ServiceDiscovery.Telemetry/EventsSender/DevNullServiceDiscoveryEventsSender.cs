using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventsSender
{
    /// <summary>
    /// A trivial implementation of <see cref="IServiceDiscoveryEventsSender"/> that simply does nothing.
    /// </summary>
    [PublicAPI]
    public class DevNullServiceDiscoveryEventsSender : IServiceDiscoveryEventsSender
    {
        public void Send(ServiceDiscoveryEvent @event)
        {
        }
    }
}