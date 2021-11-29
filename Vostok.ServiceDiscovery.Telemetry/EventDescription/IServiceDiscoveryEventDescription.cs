using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventDescription
{
    [PublicAPI]
    public interface IServiceDiscoveryEventDescription : IDisposable
    {
        [CanBeNull]
        string Application { get; }

        [CanBeNull]
        string Environment { get; }

        [NotNull]
        IReadOnlyList<string> Replicas { get; }

        ServiceDiscoveryEventKind EventKind { get; }

        [NotNull]
        IReadOnlyDictionary<string, string> Properties { get; }

        [NotNull]
        IServiceDiscoveryEventDescription SetApplication([NotNull] string application);

        [NotNull]
        IServiceDiscoveryEventDescription SetEnvironment([NotNull] string environment);

        [NotNull]
        IServiceDiscoveryEventDescription SetEventKind(ServiceDiscoveryEventKind eventKind);

        [NotNull]
        IServiceDiscoveryEventDescription SetProperty([NotNull] string key, [NotNull] string value);

        [NotNull]
        IServiceDiscoveryEventDescription AddReplicas(params string[] replicas);
    }
}