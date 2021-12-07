using System;
using JetBrains.Annotations;
using Vostok.ServiceDiscovery.Telemetry.Event;

namespace Vostok.ServiceDiscovery.Telemetry.EventsBuilder
{
    /// <summary>
    /// <para><see cref="IServiceDiscoveryEventsBuilder"/> purpose is to facilitate easy phased construction of <see cref="ServiceDiscoveryEvent"/>s in applications.</para>
    /// <para>Its state (from setup in <see cref="ServiceDiscoveryEventsContextToken"/> to <see cref="ServiceDiscoveryEventsContextToken.Dispose"/>)
    /// is closely related to <see cref="IServiceDiscoveryEventsContext.CurrentEvents"/>.</para>
    /// <para><see cref="ServiceDiscoveryEvent"/>s are primarily intended to display the history of operations on a replica,
    /// and we have built in sending events to the IServiceDiscoveryManager, so
    /// typical usage of <see cref="IServiceDiscoveryEventsBuilder"/> boils down to this:</para>
    /// <list type="number">
    ///     <item><description>Setup <see cref="IServiceDiscoveryEventsBuilder"/> in <see cref="ServiceDiscoveryEventsContextToken"/>.</description></item>
    ///     <item><description>Perform the desired operation with IServiceDiscoveryManager.</description></item>
    ///     <item><description><see cref="ServiceDiscoveryEventsContextToken.Dispose"/> of the token.</description></item>
    /// </list>
    /// <code>
    ///     using (new ServiceDiscoveryEventContextToken(builder =>
    ///             builder.SetDescription("vostok")))
    ///     {
    ///         serviceDiscoveryManager.AddToBlacklistAsync(..);
    ///     }
    ///     Information about application, replica etc.
    ///     Will be added to the event inside the manager method
    /// </code>
    /// <para>Implementations of this interface are generally <b>not expected to be thread-safe!</b>
    /// Don't use an <see cref="IServiceDiscoveryEventsBuilder"/> instance concurrently from multiple threads.</para>
    /// </summary>
    [PublicAPI]
    public interface IServiceDiscoveryEventsBuilder
    {
        /// <summary>
        /// <para>Overrides constructed event's <see cref="ServiceDiscoveryEvent.Application"/>.</para>
        /// <para>Existing <see cref="ServiceDiscoveryEvent.Application"/> are overwritten with provided values.</para>
        /// </summary>
        [NotNull]
        IServiceDiscoveryEventsBuilder SetApplication([NotNull] string application);

        /// <summary>
        /// <para>Overrides constructed event's <see cref="ServiceDiscoveryEvent.Environment"/>.</para>
        /// <para>Existing <see cref="ServiceDiscoveryEvent.Environment"/> are overwritten with provided values.</para>
        /// </summary>
        [NotNull]
        IServiceDiscoveryEventsBuilder SetEnvironment([NotNull] string environment);

        /// <summary>
        /// <para>Overrides constructed event's <see cref="ServiceDiscoveryEvent.Kind"/>.</para>
        /// <para>Existing <see cref="ServiceDiscoveryEvent.Kind"/> are overwritten with provided values.</para>
        /// </summary>
        [NotNull]
        IServiceDiscoveryEventsBuilder SetKind(ServiceDiscoveryEventKind kind);

        /// <summary>
        /// <para>Add the property with given <paramref name="key"/> and <paramref name="value"/> in constructed event's <see cref="ServiceDiscoveryEvent.Properties"/>.</para>
        /// <para>Existing property are overwritten with provided values.</para>
        /// <para>For add <see cref="ServiceDiscoveryEventWellKnownProperties">well-known property</see> use <see cref="IServiceDiscoveryEventsBuilderExtensions"/>.</para>
        /// </summary>
        [NotNull]
        IServiceDiscoveryEventsBuilder SetProperty([NotNull] string key, [NotNull] string value);

        /// <summary>
        /// <para>Overrides constructed span's <see cref="ServiceDiscoveryEvent.Timestamp"/>.</para>
        /// <para>Only use this if default value (<see cref="IServiceDiscoveryEventsBuilder"/> creation moment) is not sufficient for your needs.</para>
        /// <para>Existing <see cref="ServiceDiscoveryEvent.Timestamp"/> are overwritten with provided values.</para>
        /// </summary>
        [NotNull]
        IServiceDiscoveryEventsBuilder SetTimestamp(DateTimeOffset timestamp);

        /// <summary>
        /// <para>Add the replicas in constructed event's <see cref="ServiceDiscoveryEvent.Replica"/>.</para>
        /// <para>Note <see cref="ServiceDiscoveryEventsBuilder"/> creates separate event for each added replica.</para>
        /// </summary>
        [NotNull]
        IServiceDiscoveryEventsBuilder AddReplicas(params string[] replicas);
    }
}