using System;
using JetBrains.Annotations;
using Vostok.Context;
using Vostok.ServiceDiscovery.Telemetry.EventsBuilder;

namespace Vostok.ServiceDiscovery.Telemetry.EventContext
{
    /// <summary>
    /// <para>Creating an instance of <see cref="ServiceDiscoveryEventContextToken"/> sets a new global value of <see cref="IServiceDiscoveryEventsBuilder"/>
    /// in <see cref="FlowingContext"/>, inheriting the configuration of the previous one.</para>
    /// <para>A later <see cref="Dispose"/> call restores old value back.</para>
    /// <para>One should typically want to put created token into <c>using</c> block:</para>
    /// <code>
    /// using (new ServiceDiscoveryEventContextToken(builder =>
    ///             builder.SetDescription("vostok")))
    ///             {
    ///                 .....
    ///             }
    /// </code>
    /// </summary>
    [PublicAPI]
    public class ServiceDiscoveryEventContextToken : IDisposable
    {
        private readonly IDisposable scope;

        /// <summary>
        /// <para>Sets a new global <see cref="IServiceDiscoveryEventsBuilder"/> using the  <paramref name="setup"/>  in <see cref="FlowingContext"/>
        /// inheriting the configuration of the previous one or create new if previous null.</para>
        /// <para>This constructor also captures current <see cref="IServiceDiscoveryEventsBuilder"/> which will be restored later when calling <see cref="Dispose"/>.</para>
        /// </summary>
        public ServiceDiscoveryEventContextToken([NotNull] Action<IServiceDiscoveryEventsBuilder> setup)
        {
            var newBuilder = FlowingContext.Globals.Get<ServiceDiscoveryEventsBuilder>()?.Clone() ?? new ServiceDiscoveryEventsBuilder();
            setup.Invoke(newBuilder);

            scope = FlowingContext.Globals.Use(newBuilder);
        }

        /// <summary>
        /// Restores global <see cref="IServiceDiscoveryEventsBuilder"/> in <see cref="FlowingContext"/> to the one captured in constructor.
        /// </summary>
        public void Dispose()
        {
            scope?.Dispose();
        }
    }
}