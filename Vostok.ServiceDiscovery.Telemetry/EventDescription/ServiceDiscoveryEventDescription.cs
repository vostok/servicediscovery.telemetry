using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventDescription
{
    [PublicAPI]
    public class ServiceDiscoveryEventDescription
    {
        [CanBeNull]
        public string Application { get; private set; }

        [CanBeNull]
        public string Environment { get; private set; }

        [NotNull]
        public IReadOnlyList<Uri> Replicas => replicas;

        public ServiceDiscoveryEventKind EventKind { get; private set; }

        [NotNull]
        public IReadOnlyDictionary<string, string> Properties => properties;

        private readonly Dictionary<string, string> properties = new Dictionary<string, string>();
        private readonly List<Uri> replicas = new List<Uri>();

        [NotNull]
        public ServiceDiscoveryEventDescription SetApplication([NotNull] string application) =>
            throw new NotImplementedException();

        [NotNull]
        public ServiceDiscoveryEventDescription SetEnvironment([NotNull] string environment) =>
            throw new NotImplementedException();

        [NotNull]
        public ServiceDiscoveryEventDescription SetEventKind(ServiceDiscoveryEventKind eventKind) =>
            throw new NotImplementedException();

        [NotNull]
        public ServiceDiscoveryEventDescription AddProperties(params (string key, string value)[] properties) =>
            throw new NotImplementedException();

        [NotNull]
        public ServiceDiscoveryEventDescription AddReplicas(params Uri[] replicas) =>
            throw new NotImplementedException();
    }
}