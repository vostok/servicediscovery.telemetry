using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.EventContext;
using Vostok.ServiceDiscovery.Telemetry.EventsBuilder;

namespace Vostok.ServiceDiscovery.Telemetry.Event
{
    /// <summary>
    /// <para><see cref="ServiceDiscoveryEvent"/> is the atomic storage unit of Vostok servicediscovery telemetry.</para>
    /// <para>Each event contains the kind of event <see cref="ServiceDiscoveryEventKind"/>,
    /// time <see cref="Timestamp"/>
    /// and information about the replica with which the event is associated (<see cref="Environment"/>, <see cref="Application"/>, <see cref="Replica"/>).</para>
    /// <para>Events may also contain auxiliary information in <see cref="Properties"/> see <see cref="ServiceDiscoveryWellKnownProperties"/>.</para>
    /// <para><see cref="ServiceDiscoveryEvent"/> instances are immutable.</para>
    /// <para><see cref="ServiceDiscoveryEvent"/>s are not meant to be instantiated manually.
    /// It's recommended to use setup <see cref="IServiceDiscoveryEventsBuilder"/> from <see cref="ServiceDiscoveryEventContextToken"/>.</para>
    /// </summary>
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

        /// <summary>
        /// Kind of event see <see cref="Vostok.ServiceDiscovery.Telemetry.Event.ServiceDiscoveryEventKind"/>.
        /// </summary>
        public ServiceDiscoveryEventKind Kind { get; }

        /// <summary>
        /// Environment in which the <see cref="Replica"/> registered in service discovery.
        /// </summary>
        [NotNull]
        public string Environment { get; }

        /// <summary>
        /// Application in which the <see cref="Replica"/> registered in service discovery.
        /// </summary>
        [NotNull]
        public string Application { get; }

        /// <summary>
        /// Contains replica URL, if the application is a service, or information about the running daemon in the format "Host(ProcessId)".
        /// </summary>
        [NotNull]
        public string Replica { get; }

        /// <summary>
        /// Timestamp denoting the moment when this <see cref="ServiceDiscoveryEvent"/> occurred.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// <para>Set of key-value string pairs that may contain additional information about event.</para>
        /// <para>Contents of <see cref="Properties"/> must match the selected <see cref="ServiceDiscoveryEventKind"/>.</para>
        /// </summary>
        [NotNull]
        public IReadOnlyDictionary<string, string> Properties { get; }
    }
}