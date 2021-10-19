using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventSender
{
    [PublicAPI]
    public class DevNullServiceDiscoveryEventSender : IServiceDiscoveryEventSender
    {
        public void Send(ServiceDiscoveryEvent serviceDiscoveryEvent)
        {
        }
    }
}