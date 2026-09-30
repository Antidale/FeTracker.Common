using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace FeTracker.Common.RazorComponents;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddTrackerServices()
        {
            services.TryAddScoped<TrackerNotifier>();
            return services;
        }
    }
}
