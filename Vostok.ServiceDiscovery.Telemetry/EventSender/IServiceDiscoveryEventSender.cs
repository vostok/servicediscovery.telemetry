using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventSender
{
    /// <summary>
    /// Sends <see cref="ServiceDiscoveryEvent"/>s to a permanent storage.
    /// Implementations are expected to be thread-safe and exception-free.
    /// </summary>
    [PublicAPI]
    public interface IServiceDiscoveryEventSender
    {
        void Send([NotNull] ServiceDiscoveryEvent @event);
    }
}