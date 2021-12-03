using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventSender
{
    [PublicAPI]
    public interface IServiceDiscoveryEventSender
    {
        void Send([NotNull] ServiceDiscoveryEvent @event);
    }
}