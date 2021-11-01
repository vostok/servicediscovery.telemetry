﻿using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry.EventDescription
{
    [PublicAPI]
    public static class ServiceDiscoveryEventDescriptionExtensions
    {
        [NotNull]
        public static ServiceDiscoveryEventDescription SetDescription(this ServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string description) =>
            serviceDiscoveryEventDescription.AddProperties((ServiceDiscoveryEventKeys.EventDescription, description));
        
        [NotNull]
        public static ServiceDiscoveryEventDescription SetUserId(this ServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string userId) =>
            serviceDiscoveryEventDescription.AddProperties((ServiceDiscoveryEventKeys.EventCreatorId, userId));

        [NotNull]
        public static ServiceDiscoveryEventDescription SetDependencies(this ServiceDiscoveryEventDescription serviceDiscoveryEventDescription, [NotNull] string dependencies) =>
            serviceDiscoveryEventDescription.AddProperties((ServiceDiscoveryEventKeys.Dependencies, dependencies));
    }
}