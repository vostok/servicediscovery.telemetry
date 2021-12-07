using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventsBuilder
{
    internal class ServiceDiscoveryEventsBuilder : IServiceDiscoveryEventsBuilder
    {
        private ServiceDiscoveryEventKind kind;

        private string application;
        private string environment;
        private readonly List<string> replicas;

        private DateTimeOffset timestamp;
        private readonly Dictionary<string, string> properties;

        public ServiceDiscoveryEventsBuilder()
            : this(new List<string>(), new Dictionary<string, string>(), DateTimeOffset.Now)
        {
        }

        internal ServiceDiscoveryEventsBuilder([NotNull] List<string> replicas, [NotNull] Dictionary<string, string> properties, DateTimeOffset timestamp)
        {
            this.replicas = replicas;
            this.properties = properties;
            this.timestamp = timestamp;
        }

        #region Setters

        public IServiceDiscoveryEventsBuilder SetApplication(string application)
        {
            this.application = application;
            return this;
        }

        public IServiceDiscoveryEventsBuilder SetEnvironment(string environment)
        {
            this.environment = environment;
            return this;
        }

        public IServiceDiscoveryEventsBuilder SetKind(ServiceDiscoveryEventKind kind)
        {
            this.kind = kind;
            return this;
        }

        public IServiceDiscoveryEventsBuilder SetProperty(string key, string value)
        {
            properties[key] = value;
            return this;
        }

        public IServiceDiscoveryEventsBuilder SetTimestamp(DateTimeOffset timestamp)
        {
            this.timestamp = timestamp;
            return this;
        }

        public IServiceDiscoveryEventsBuilder AddReplicas(params string[] replicasUri)
        {
            replicas.AddRange(replicasUri);
            return this;
        }

        #endregion

        [NotNull]
        public ServiceDiscoveryEventsBuilder Clone() =>
            new ServiceDiscoveryEventsBuilder(new List<string>(replicas), new Dictionary<string, string>(properties), timestamp)
            {
                application = application,
                environment = environment,
                kind = kind,
            };

        [NotNull]
        public IEnumerable<ServiceDiscoveryEvent> BuildEvents()
        {
            if (application == null || environment == null)
                return Enumerable.Empty<ServiceDiscoveryEvent>();

            return replicas.Select(replica => new ServiceDiscoveryEvent(
                    kind,
                    environment,
                    application,
                    replica,
                    timestamp,
                    properties))
                .ToList();
        }
    }
}