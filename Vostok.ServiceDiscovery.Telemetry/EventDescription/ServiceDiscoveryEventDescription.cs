using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventDescription
{
    [PublicAPI]
    public class ServiceDiscoveryEventDescription
    {
        [CanBeNull]
        public string Application { get; set; }

        [CanBeNull]
        public string Environment { get; set; }

        [NotNull]
        public IReadOnlyList<string> Replicas => replicas;

        public ServiceDiscoveryEventKind EventKind { get; set; }

        [NotNull]
        public IReadOnlyDictionary<string, string> Properties => properties;

        private readonly Dictionary<string, string> properties = new Dictionary<string, string>();
        private readonly List<string> replicas = new List<string>();

        #region Setters

        [NotNull]
        public ServiceDiscoveryEventDescription SetApplication([NotNull] string application)
        {
            Application = application;
            return this;
        }

        [NotNull]
        public ServiceDiscoveryEventDescription SetEnvironment([NotNull] string environment)
        {
            Environment = environment;
            return this;
        }

        [NotNull]
        public ServiceDiscoveryEventDescription SetEventKind(ServiceDiscoveryEventKind eventKind)
        {
            EventKind = eventKind;
            return this;
        }

        [NotNull]
        public ServiceDiscoveryEventDescription AddProperties(params (string key, string value)[] properties)
        {
            foreach (var (key, value) in properties)
                this.properties[key] = value;
            return this;
        }

        [NotNull]
        public ServiceDiscoveryEventDescription AddReplicas(params string[] replicasUri)
        {
            replicas.AddRange(replicasUri);
            return this;
        }

        #endregion
    }
}