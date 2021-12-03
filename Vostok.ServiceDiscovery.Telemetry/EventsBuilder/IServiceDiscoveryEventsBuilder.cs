using System;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventsBuilder
{
    [PublicAPI]
    public interface IServiceDiscoveryEventsBuilder
    {
        [NotNull]
        IServiceDiscoveryEventsBuilder SetApplication([NotNull] string application);

        [NotNull]
        IServiceDiscoveryEventsBuilder SetEnvironment([NotNull] string environment);

        [NotNull]
        IServiceDiscoveryEventsBuilder SetEventKind(ServiceDiscoveryEventKind eventKind);

        [NotNull]
        IServiceDiscoveryEventsBuilder SetProperty([NotNull] string key, [NotNull] string value);

        [NotNull]
        IServiceDiscoveryEventsBuilder SetTimestamp(DateTimeOffset timestamp);

        [NotNull]
        IServiceDiscoveryEventsBuilder AddReplicas(params string[] replicas);
    }
}