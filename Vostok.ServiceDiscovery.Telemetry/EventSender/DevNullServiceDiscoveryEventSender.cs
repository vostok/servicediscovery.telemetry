using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventSender
{
    /// <summary>
    /// A trivial implementation of <see cref="IServiceDiscoveryEventSender"/> that simply does nothing.
    /// </summary>
    [PublicAPI]
    public class DevNullServiceDiscoveryEventSender : IServiceDiscoveryEventSender
    {
        public void Send(ServiceDiscoveryEvent @event)
        {
        }
    }
}