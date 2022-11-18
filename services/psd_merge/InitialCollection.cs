using Microsoft.Extensions.DependencyInjection;
using psd_merge.Services;
namespace psd_merge
{
    public static class InitialCollection
    {
        public static IServiceCollection InitialServicesCollections(this IServiceCollection services)
        {
            services.AddScoped<IInitial,Initial>();
            services.AddScoped<IMerge, Merge>();

            return services;
        }
    }
}