using System;
using System.Collections.Generic;
using System.Linq;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventDescription
{
    internal class ServiceDiscoveryEventDescription : IServiceDiscoveryEventDescription
    {
        public string Application { get; set; }
        public string Environment { get; set; }
        public IReadOnlyList<string> Replicas => replicas;
        public ServiceDiscoveryEventKind EventKind { get; set; }
        public IReadOnlyDictionary<string, string> Properties => properties;

        private readonly Dictionary<string, string> properties;
        private readonly List<string> replicas;
        private IDisposable descriptionScope;

        public ServiceDiscoveryEventDescription()
        {
            replicas = new List<string>();
            properties = new Dictionary<string, string>();
        }

        public ServiceDiscoveryEventDescription(IServiceDiscoveryEventDescription eventDescription)
        {
            Application = eventDescription.Application;
            Environment = eventDescription.Environment;
            EventKind = eventDescription.EventKind;

            replicas = new List<string>(eventDescription.Replicas);
            properties = eventDescription.Properties.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public void Dispose()
        {
            descriptionScope?.Dispose();
        }

        #region Setters

        public IServiceDiscoveryEventDescription SetApplication(string application)
        {
            Application = application;
            return this;
        }

        public IServiceDiscoveryEventDescription SetEnvironment(string environment)
        {
            Environment = environment;
            return this;
        }

        public IServiceDiscoveryEventDescription SetEventKind(ServiceDiscoveryEventKind eventKind)
        {
            EventKind = eventKind;
            return this;
        }

        public IServiceDiscoveryEventDescription AddProperty(string key, string value)
        {
            properties[key] = value;
            return this;
        }

        public IServiceDiscoveryEventDescription AddReplicas(params string[] replicasUri)
        {
            replicas.AddRange(replicasUri);
            return this;
        }

        public IServiceDiscoveryEventDescription SetDescriptionScope(IDisposable scope)
        {
            descriptionScope = scope;
            return this;
        }

        #endregion
    }
}