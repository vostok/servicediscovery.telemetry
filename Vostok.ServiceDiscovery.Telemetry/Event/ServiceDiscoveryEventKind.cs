using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry.Event
{
    [PublicAPI]
    public enum ServiceDiscoveryEventKind
    {
        ReplicaStarted = 0,
        ReplicaStopped = 1,

        ReplicaAddedToBlackList = 2,
        ReplicaRemovedFromBlacklist = 3
    }
}