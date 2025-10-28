using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ndjson.AsyncStreams.AspNetCore.Mvc;
using Ndjson.AsyncStreams.AspNetCore.Mvc.Internals;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions methods for configuring services via an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class SystemTextNdjsonServiceCollectionExtensions
    {
        /// <summary>
        /// Configures NDJSON support for async streams.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IServiceCollection AddNdjson(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAddSingleton<INdjsonWriterFactory, SystemTextNdjsonWriterFactory>();
            services.AddSingleton<IConfigureOptions<MvcOptions>, SystemTextNdjsonMvcOptionsSetup>();

            return services;
        }
    }
}
