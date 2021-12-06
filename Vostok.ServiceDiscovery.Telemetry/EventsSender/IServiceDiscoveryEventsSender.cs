using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventsSender
{
    /// <summary>
    /// Sends <see cref="ServiceDiscoveryEvent"/>s to a permanent storage.
    /// Implementations are expected to be thread-safe and exception-free.
    /// </summary>
    [PublicAPI]
    public interface IServiceDiscoveryEventsSender
    {
        void Send([NotNull] ServiceDiscoveryEvent @event);
    }
}