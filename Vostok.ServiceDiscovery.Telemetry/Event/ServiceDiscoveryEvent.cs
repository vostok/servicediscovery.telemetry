using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry.Event
{
    [PublicAPI]
    public class ServiceDiscoveryEvent
    {
        [NotNull]
        public string Application { get; }
        [NotNull]
        public string Environment { get; }
        [NotNull]
        public string Replica { get; }

        public DateTimeOffset Timestamp { get; }
        public ServiceDiscoveryEventKind ServiceDiscoveryEventKind { get; }

        [NotNull]
        public IReadOnlyDictionary<string, string> Properties { get; }

        public ServiceDiscoveryEvent(
            [NotNull] string application,
            [NotNull] string replica,
            [NotNull] string environment,
            ServiceDiscoveryEventKind eventKind,
            DateTimeOffset timestamp,
            [NotNull] Dictionary<string, string> properties)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
            Replica = replica ?? throw new ArgumentNullException(nameof(replica));
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));

            ServiceDiscoveryEventKind = eventKind;

            Timestamp = timestamp;
            Properties = properties;
        }
    }
}