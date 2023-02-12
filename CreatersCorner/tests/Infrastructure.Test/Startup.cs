using CreatersCorner.WebApi.Application.Common.Interfaces;
using CreatersCorner.WebApi.Application.Common.Persistence;
using CreatersCorner.WebApi.Infrastructure.Caching;
using CreatersCorner.WebApi.Infrastructure.Common.Services;
using CreatersCorner.WebApi.Infrastructure.Localization;
using CreatersCorner.WebApi.Infrastructure.Persistence.ConnectionString;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Test;

public class Startup
{
    public void ConfigureHost(IHostBuilder host) =>
        host.ConfigureHostConfiguration(config => config.AddJsonFile("appsettings.json"));

    public void ConfigureServices(IServiceCollection services, HostBuilderContext context) =>
        services
            .AddTransient<IMemoryCache, MemoryCache>()
            .AddTransient<LocalCacheService>()
            .AddTransient<IDistributedCache, MemoryDistributedCache>()
            .AddTransient<ISerializerService, NewtonSoftService>()
            .AddTransient<DistributedCacheService>()

            .AddPOLocalization(context.Configuration)

            .AddTransient<IConnectionStringSecurer, ConnectionStringSecurer>();
}