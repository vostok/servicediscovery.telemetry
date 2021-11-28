using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry.Event
{
    [PublicAPI]
    public class ServiceDiscoveryEvent
    {
        public ServiceDiscoveryEvent(
            ServiceDiscoveryEventKind kind,
            [NotNull] string environment,
            [NotNull] string application,
            [NotNull] string replica,
            DateTimeOffset timestamp,
            [NotNull] IReadOnlyDictionary<string, string> properties)
        {
            Kind = kind;

            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
            Application = application ?? throw new ArgumentNullException(nameof(application));
            Replica = replica ?? throw new ArgumentNullException(nameof(replica));

            Timestamp = timestamp;
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        public ServiceDiscoveryEventKind Kind { get; }

        [NotNull]
        public string Environment { get; }

        [NotNull]
        public string Application { get; }

        [NotNull]
        public string Replica { get; }

        public DateTimeOffset Timestamp { get; }

        [NotNull]
        public IReadOnlyDictionary<string, string> Properties { get; }
    }
}