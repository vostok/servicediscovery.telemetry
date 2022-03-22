using System;
using System.Threading;
using JetBrains.Annotations;

namespace Vostok.ServiceDiscovery.Telemetry
{
    /// <summary>
    /// <para><see cref="ServiceDiscoveryEventsContextProvider"/> is intended to be used primarily by library developers who must not force their users to explicitly provide <see cref="IServiceDiscoveryEventsContext"/> instances.</para>
    /// <para>It is expected to be configured by a hosting system or just directly in the application entry point.</para>
    /// </summary>
    [PublicAPI]
    public static class ServiceDiscoveryEventsContextProvider
    {
        private static readonly IServiceDiscoveryEventsContext DefaultInstance = new DevNullServiceDiscoveryEventsContext();

        private static volatile IServiceDiscoveryEventsContext instance;

        /// <summary>
        /// Returns <c>true</c> if a global <see cref="IServiceDiscoveryEventsContext"/> instance has already been configured with <see cref="Configure"/> method. Returns <c>false</c> otherwise.
        /// </summary>
        public static bool IsConfigured => instance != null;

        /// <summary>
        /// <para>Returns the global default instance of <see cref="IServiceDiscoveryEventsContext"/> if it's been configured.</para>
        /// <para>If nothing has been configured yet, falls back to an instance of <see cref="DevNullServiceDiscoveryEventsContext"/>.</para>
        /// </summary>
        [NotNull]
        public static IServiceDiscoveryEventsContext Get() => instance ?? DefaultInstance;

        /// <summary>
        /// <para>Configures the global default <see cref="IServiceDiscoveryEventsContext"/> with given instance, which will be returned by all subsequent <see cref="Get"/> calls.</para>
        /// <para>By default, this method fails when trying to overwrite a previously configured instance. This behaviour can be changed with <paramref name="canOverwrite"/> parameter.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException">Provided instance was <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Attempted to overwrite previously configured instance.</exception>
        public static void Configure([NotNull] IServiceDiscoveryEventsContext serviceDiscoveryEventsContext, bool canOverwrite = false)
        {
            if (!TryConfigure(serviceDiscoveryEventsContext, canOverwrite))
                throw new InvalidOperationException($"Can't overwrite existing configured implementation of type '{instance.GetType().Name}'.");
        }

        /// <summary>
        /// <para>Configures the global default <see cref="IServiceDiscoveryEventsContext"/> with given instance, which will be returned by all subsequent <see cref="Get"/> calls.</para>
        /// <para>By default, this method returns <c>false</c> when trying to overwrite a previously configured instance. This behaviour can be changed with <paramref name="canOverwrite"/> parameter.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException">Provided instance was <c>null</c>.</exception>
        public static bool TryConfigure([NotNull] IServiceDiscoveryEventsContext serviceDiscoveryEventsContext, bool canOverwrite = false)
        {
            if (serviceDiscoveryEventsContext == null)
                throw new ArgumentNullException(nameof(serviceDiscoveryEventsContext));

            if (canOverwrite)
            {
                Interlocked.Exchange(ref instance, serviceDiscoveryEventsContext);
                return true;
            }

            return Interlocked.CompareExchange(ref instance, serviceDiscoveryEventsContext, null) == null;
        }
    }
}
