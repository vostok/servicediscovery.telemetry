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

        public IServiceDiscoveryEventDescription SetApplication(string application) =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventDescription SetEnvironment(string environment) =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventDescription SetEventKind(ServiceDiscoveryEventKind eventKind) =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventDescription AddProperty(string key, string value) =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventDescription AddReplicas(params string[] replicas) =>
            throw new NotImplementedException();

        public IServiceDiscoveryEventDescription SetDescriptionScope(IDisposable scope) =>
            throw new NotImplementedException();

        #endregion
    }
}