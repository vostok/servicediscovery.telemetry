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
        public Dictionary<string, string> Properties { get; }

        public ServiceDiscoveryEvent(
            [NotNull] string application,
            [NotNull] string replica,
            ServiceDiscoveryEventKind eventKind,
            [NotNull] string environment = "default",
            [CanBeNull] DateTimeOffset? timestamp = null,
            [CanBeNull] Dictionary<string, string> properties = null)
        {
            Application = application;
            Replica = replica;
            Environment = environment;

            ServiceDiscoveryEventKind = eventKind;
            
            Timestamp = timestamp ?? DateTimeOffset.UtcNow;
            Properties = properties ?? new Dictionary<string, string>();
        }
    }
}